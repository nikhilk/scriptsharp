// HttpMessage.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ScriptSharp.Testing.WebServer {

    internal sealed class HttpMessage {

        private const int MaximumPostSize = 10 * 1024 * 1024; // 10MB
        private const int BufferSize = 4096;

        private HttpServer _server;
        private TcpClient _client;

        private Action<HttpMessage> _getHandler;
        private Action<HttpMessage> _postHandler;

        private string _method;
        private string _path;
        private Dictionary<string, string> _headers;

        private Stream _requestStream;
        private Stream _responseStream;

        internal HttpMessage(HttpServer server, Action<HttpMessage> getHandler, Action<HttpMessage> postHandler) {
            _server = server;
            _getHandler = getHandler;
            _postHandler = postHandler;
        }

        public string Method {
            get {
                return _method;
            }
        }

        public string Path {
            get {
                return _path;
            }
        }

        public Stream RequestStream {
            get {
                return _requestStream;
            }
        }

        public Stream ResponseStream {
            get {
                return _responseStream;
            }
        }

        private void ParseRequest(Stream inputStream) {
            string request = ReadLine(inputStream);

            string[] tokens = request.Split(' ');
            if (tokens.Length != 3) {
                throw new Exception("Invalid HTTP request");
            }

            _method = tokens[0].ToUpper();
            _path = tokens[1];
        }

        private void ParseRequestHeaders(Stream inputStream) {
            _headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            string line;
            while ((line = ReadLine(inputStream)) != null) {
                if (line.Equals("")) {
                    // Finished reading headers
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1) {
                    throw new Exception("Invalid HTTP header: " + line);
                }

                string name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' ')) {
                    // Strip any spaces
                    pos++;
                }

                string value = line.Substring(pos, line.Length - pos);
                if (String.IsNullOrEmpty(value)) {
                    throw new Exception("Invalid HTTP header: " + line);
                }

                _headers[name] = value;
            }
        }

        private void ParseRequestBody(Stream inputStream) {
            MemoryStream ms = new MemoryStream();

            int contentLength;
            string contentLengthValue;
            if (_headers.TryGetValue("Content-Length", out contentLengthValue) &&
                Int32.TryParse(contentLengthValue, out contentLength)) {
                if (contentLength > MaximumPostSize) {
                    throw new Exception("Request is too large");
                }

                int bytesToRead = contentLength;

                byte[] buffer = new byte[BufferSize];
                while (bytesToRead > 0) {
                    int bytesRead = inputStream.Read(buffer, 0, Math.Min(BufferSize, bytesToRead));
                    if (bytesRead == 0) {
                        if (bytesToRead == 0) {
                            break;
                        }
                        else {
                            throw new Exception("Client disconnected");
                        }
                    }

                    bytesToRead -= bytesRead;
                    ms.Write(buffer, 0, bytesRead);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }

            _requestStream = ms;
        }

        public void ProcessClient(TcpClient client) {
            _client = client;

            Thread messageThread = new Thread(Run);
            messageThread.Start();
        }

        private string ReadLine(Stream inputStream) {
            int nextByte;

            string data = "";
            while (true) {
                nextByte = inputStream.ReadByte();

                if (nextByte == '\n') {
                    break;
                }
                if (nextByte == '\r') {
                    continue;
                }
                if (nextByte == -1) {
                    Thread.Sleep(1);
                    continue;
                };

                data += Convert.ToChar(nextByte);
            }

            return data;
        }

        private void Run() {
            NetworkStream tcpStream = _client.GetStream();

            BufferedStream tcpReadStream = new BufferedStream(tcpStream);
            BufferedStream tcpSendStream = new BufferedStream(tcpStream);

            _responseStream = tcpSendStream;

            try {
                ParseRequest(tcpReadStream);
                ParseRequestHeaders(tcpReadStream);

                bool processed = false;
                if (_method.Equals("GET")) {
                    if (_getHandler != null) {
                        _getHandler(this);

                        processed = true;
                    }
                }
                else if (_method.Equals("POST")) {
                    if (_postHandler != null) {
                        ParseRequestBody(tcpReadStream);
                        _postHandler(this);

                        processed = true;
                    }
                }

                if (processed == false) {
                    WriteStatus(HttpStatusCode.MethodNotAllowed);
                }
            }
            catch (Exception) {
                WriteStatus(HttpStatusCode.InternalServerError);
            }

            _responseStream.Flush();

            _client.Close();
        }

        public void WriteContent(string content, string contentType) {
            StreamWriter writer = new StreamWriter(_responseStream);

            writer.WriteLine("HTTP/1.0 200 OK");
            writer.WriteLine("Content-Type: " + contentType);
            writer.WriteLine("Connection: close");
            writer.WriteLine("");
            writer.Write(content);

            writer.Flush();
        }

        public void WriteFile(string path, string contentType) {
            StreamWriter writer = new StreamWriter(_responseStream);

            writer.WriteLine("HTTP/1.0 200");
            writer.WriteLine("Content-Type: " + contentType);
            writer.WriteLine("Connection: close");
            writer.WriteLine("");
            writer.Flush();

            using (Stream fileStream = File.OpenRead(path)) {
                byte[] buffer = new byte[BufferSize];

                int bytesRead = 0;
                do {
                    bytesRead = fileStream.Read(buffer, 0, BufferSize);
                    if (bytesRead != 0) {
                        _responseStream.Write(buffer, 0, bytesRead);
                    }
                }
                while (bytesRead != 0);
            }
        }

        public void WriteStatus(HttpStatusCode statusCode) {
            StreamWriter writer = new StreamWriter(_responseStream);

            writer.WriteLine("HTTP/1.0 " + (int)statusCode);
            writer.WriteLine("Connection: close");
            writer.WriteLine("");

            writer.Flush();
        }
    }
}
