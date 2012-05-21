// Connection.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using ScriptSharp.Testing.WebServer.Content;

namespace ScriptSharp.Testing.WebServer {

    internal sealed class Connection : MarshalByRefObject {

        private static string _localServerIP;

        private Server _server;
        private Socket _socket;

        internal Connection(Server server, Socket socket) {
            _server = server;
            _socket = socket;
        }

        public override object InitializeLifetimeService() {
            // never expire the license
            return null;
        }

        internal bool Connected {
            get {
                return _socket.Connected;
            }
        }

        internal bool IsLocal {
            get {
                string remoteIP = RemoteIP;

                if (remoteIP.Equals("127.0.0.1")) {
                    return true;
                }

                return LocalServerIP.Equals(remoteIP);
            }
        }

        private static string LocalServerIP {
            get {
                if (_localServerIP == null) {
                    IPHostEntry hostEntry = Dns.GetHostEntry(Environment.MachineName);
                    IPAddress localAddress = hostEntry.AddressList[0];
                    _localServerIP = localAddress.ToString();
                }

                return _localServerIP;
            }
        }

        internal string LocalIP {
            get {
                IPEndPoint endPoint = (IPEndPoint)_socket.LocalEndPoint;
                if ((endPoint != null) && (endPoint.Address != null)) {
                    return endPoint.Address.ToString();
                }
                else {
                    return "127.0.0.1";
                }
            }
        }

        internal string RemoteIP {
            get {
                IPEndPoint endPoint = (IPEndPoint)_socket.RemoteEndPoint;
                if ((endPoint != null) && (endPoint.Address != null)) {
                    return endPoint.Address.ToString();
                }
                else {
                    // REVIEW: Is this correct? If RemoteEndPoint is not
                    //         set, we end up returning 127.0.0.1 which is
                    //         treated as localhost, and may not be what
                    //         we want.
                    return "127.0.0.1";
                }
            }
        }

        internal void Close() {
            try {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
            catch {
            }
            finally {
                _socket = null;
            }
        }

        private static string MakeResponseHeaders(int statusCode, string moreHeaders, int contentLength, bool keepAlive) {
            StringBuilder sb = new StringBuilder();

            sb.Append("HTTP/1.1 " + statusCode + " " + HttpWorkerRequest.GetStatusDescription(statusCode) + "\r\n");
            sb.Append("Server: ASP.NET/" + Messages.VersionString + "\r\n");
            sb.Append("Date: " + DateTime.Now.ToUniversalTime().ToString("R", DateTimeFormatInfo.InvariantInfo) + "\r\n");
            if (contentLength >= 0) {
                sb.Append("Content-Length: " + contentLength + "\r\n");
            }
            if (moreHeaders != null) {
                sb.Append(moreHeaders);
            }
            if (!keepAlive) {
                sb.Append("Connection: Close\r\n");
            }
            sb.Append("\r\n");

            return sb.ToString();
        }

        private static string MakeContentTypeHeader(string fileName) {
            Debug.Assert(File.Exists(fileName));
            string contentType = null;

            FileInfo info = new FileInfo(fileName);
            string extension = info.Extension.ToLowerInvariant();

            switch (extension) {
                case ".css":
                    contentType = "text/css";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".ico":
                    contentType = "image/x-icon";
                    break;
                case ".htm":
                case ".html":
                    contentType = "text/html";
                    break;
                case ".jpe":
                case ".jpeg":
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".js":
                    contentType = "application/x-javascript";
                    break;
                default:
                    break;
            }

            if (contentType == null) {
                return null;
            }

            return "Content-Type: " + contentType + "\r\n";
        }

        private string GetErrorResponseBody(int statusCode, string message) {
            string body = Messages.FormatErrorMessageBody(statusCode, _server.VirtualPath);
            if (message != null && message.Length > 0) {
                body += "\r\n<!--\r\n" + message + "\r\n-->";
            }
            return body;
        }

        internal byte[] ReadRequestBytes(int maxBytes) {
            try {
                if (WaitForRequestBytes() == 0) {
                    return null;
                }

                int numBytes = _socket.Available;
                if (numBytes > maxBytes)
                    numBytes = maxBytes;

                int numReceived = 0;
                byte[] buffer = new byte[numBytes];

                if (numBytes > 0) {
                    numReceived = _socket.Receive(buffer, 0, numBytes, SocketFlags.None);
                }

                if (numReceived < numBytes) {
                    byte[] tempBuffer = new byte[numReceived];

                    if (numReceived > 0) {
                        Buffer.BlockCopy(buffer, 0, tempBuffer, 0, numReceived);
                    }

                    buffer = tempBuffer;
                }

                return buffer;
            }
            catch {
                return null;
            }
        }

        internal void Write100Continue() {
            WriteEntireResponseFromString(100, null, null, true);
        }

        internal void Write200Continue() {
            WriteEntireResponseFromString(200, null, String.Empty, true);
        }

        internal void WriteBody(byte[] data, int offset, int length) {
            try {
                _socket.Send(data, offset, length, SocketFlags.None);
            }
            catch (SocketException) {
            }
        }

        internal void WriteEntireResponseFromString(int statusCode, string extraHeaders, string body, bool keepAlive) {
            try {
                int bodyLength = (body != null) ? Encoding.UTF8.GetByteCount(body) : 0;
                string headers = MakeResponseHeaders(statusCode, extraHeaders, bodyLength, keepAlive);

                _socket.Send(Encoding.UTF8.GetBytes(headers + body));
            }
            catch (SocketException) {
            }
            finally {
                if (!keepAlive) {
                    Close();
                }
            }
        }

        internal void WriteEntireResponseFromFile(string fileName, bool keepAlive) {
            if (!File.Exists(fileName)) {
                WriteErrorAndClose(404);
                return;
            }

            // Deny the request if the contentType cannot be recognized.
            string contentTypeHeader = MakeContentTypeHeader(fileName);
            if (contentTypeHeader == null) {
                WriteErrorAndClose(403);
                return;
            }

            bool completed = false;
            FileStream fs = null;

            try {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                int len = (int)fs.Length;
                byte[] fileBytes = new byte[len];
                int bytesRead = fs.Read(fileBytes, 0, len);

                string headers = MakeResponseHeaders(200, contentTypeHeader, bytesRead, keepAlive);
                _socket.Send(Encoding.UTF8.GetBytes(headers));
                _socket.Send(fileBytes, 0, bytesRead, SocketFlags.None);

                completed = true;
            }
            catch (SocketException) {
            }
            finally {
                if (!keepAlive || !completed) {
                    Close();
                }

                if (fs != null) {
                    fs.Close();
                }
            }
        }

        internal void WriteErrorAndClose(int statusCode, string message) {
            WriteEntireResponseFromString(statusCode, null, GetErrorResponseBody(statusCode, message), false);
        }

        internal void WriteErrorAndClose(int statusCode) {
            WriteErrorAndClose(statusCode, null);
        }

        internal void WriteErrorWithExtraHeadersAndKeepAlive(int statusCode, string extraHeaders) {
            WriteEntireResponseFromString(statusCode, extraHeaders, GetErrorResponseBody(statusCode, null), true);
        }

        internal int WaitForRequestBytes() {
            int availBytes = 0;

            try {
                if (_socket.Available == 0) {
                    // poll until there is data
                    _socket.Poll(100000 /* 100ms */, SelectMode.SelectRead);
                    if (_socket.Available == 0 && _socket.Connected) {
                        _socket.Poll(30000000 /* 30sec */, SelectMode.SelectRead);
                    }
                }

                availBytes = _socket.Available;
            }
            catch {
            }

            return availBytes;
        }

        internal void WriteHeaders(int statusCode, string extraHeaders) {
            string headers = MakeResponseHeaders(statusCode, extraHeaders, -1, false);

            try {
                _socket.Send(Encoding.UTF8.GetBytes(headers));
            }
            catch (SocketException) {
            }
        }
    }
}
