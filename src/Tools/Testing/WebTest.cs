// WebTest.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using ScriptSharp.Testing.WebServer;

namespace ScriptSharp.Testing {

    public sealed class WebTest {

        private WebTestHttpServer _server;
        private Uri _rootUri;

        public Uri CreateContent(string virtualPath, string content, string contentType) {
            if (_server == null) {
                throw new InvalidOperationException("The server has not been started.");
            }
            if (String.IsNullOrEmpty(virtualPath)) {
                throw new ArgumentNullException("virtualPath");
            }
            if (String.IsNullOrEmpty(content)) {
                throw new ArgumentNullException("content");
            }
            if (String.IsNullOrEmpty(contentType)) {
                throw new ArgumentNullException("contentType");
            }

            _server.RegisterContent(virtualPath, content, contentType);
            return GetTestUri(virtualPath);
        }

        public Uri GetTestUri(string virtualPath, params string[] testModules) {
            if (_server == null) {
                throw new InvalidOperationException("The server has not been started.");
            }
            if (String.IsNullOrEmpty(virtualPath)) {
                throw new ArgumentNullException("virtualPath");
            }

            string path = virtualPath;

            if ((testModules != null) && (testModules.Length != 0)) {
                StringBuilder uriBuilder = new StringBuilder(virtualPath);
                uriBuilder.Append("?");

                int moduleIndex = 0;
                foreach (string m in testModules) {
                    if (moduleIndex != 0) {
                        uriBuilder.Append(",");
                    }
                    uriBuilder.Append(m);
                    moduleIndex++;
                }

                path = uriBuilder.ToString();
            }

            return new Uri(_rootUri, path);
        }

        public WebTestResult RunTest(Uri testUri) {
            return RunTest(testUri, WebBrowser.InternetExplorer, TimeSpan.FromMinutes(1));
        }

        public WebTestResult RunTest(Uri testUri, WebBrowser browser) {
            return RunTest(testUri, browser, TimeSpan.FromMinutes(1));
        }

        public WebTestResult RunTest(Uri testUri, WebBrowser browser, TimeSpan timeout) {
            if (_server == null) {
                throw new InvalidOperationException("The server has not been started.");
            }

            if (testUri == null) {
                throw new ArgumentNullException("testUri");
            }
            if (testUri.IsAbsoluteUri == false) {
                throw new ArgumentException("URI must be absolute.", "testUri");
            }
            if (browser == null) {
                throw new ArgumentNullException("browser");
            }
            if (String.IsNullOrEmpty(browser.ExecutablePath)) {
                throw new InvalidOperationException("The specified browser could not be located.");
            }

            if (timeout.TotalMilliseconds == 0) {
                timeout = TimeSpan.FromMinutes(1);
            }

            AutoResetEvent waitHandle = new AutoResetEvent(/* initialSignaledState */ false);
            WebTestResult result = null;
            Process browserProcess = null;

            EventHandler<WebTestLogEventArgs> logEventHandler = null;
            logEventHandler = delegate(object sender, WebTestLogEventArgs e) {
                _server.Log -= logEventHandler;

                result = new WebTestResult(e.Succeeded, e.Log);
                waitHandle.Set();
            };

            try {
                string arguments = browser.Arguments + testUri.AbsoluteUri;

                ProcessStartInfo psi = new ProcessStartInfo(browser.ExecutablePath, arguments);
                psi.UseShellExecute = true;
                psi.WindowStyle = ProcessWindowStyle.Minimized;

                _server.Log += logEventHandler;
                browserProcess = Process.Start(psi);
            }
            catch (Exception) {
                _server.Log -= logEventHandler;
                return new WebTestResult(/* succeeded */ false, String.Empty);
            }

            bool signaled = waitHandle.WaitOne(timeout);
            if (browserProcess != null) {
                try {
                    browserProcess.CloseMainWindow();
                    browserProcess.Kill();
                    browserProcess.WaitForExit(1000);
                }
                catch {
                }
                finally {
                    browserProcess.Close();
                }
                browserProcess = null;
            }

            if (signaled == false) {
                return new WebTestResult();
            }
            else {
                return result;
            }
        }

        public bool StartWebServer(int port, params string[] webRoots) {
            if (_server != null) {
                throw new InvalidOperationException("The server has already been started.");
            }
            if (webRoots == null) {
                throw new ArgumentNullException("webRoots");
            }

            foreach (string webRoot in webRoots) {
                if (Directory.Exists(webRoot) == false) {
                    throw new ArgumentException("Invalid directory specified as the web root: '" + webRoot + "'");
                }
            }

            bool started = false;
            try {
                WebTestHttpServer server = new WebTestHttpServer(webRoots);
                server.Start(port);

                _server = server;
                started = true;
            }
            catch (Exception e) {
                throw new InvalidOperationException("Failed to start server.", e);
            }

            if (started) {
                UriBuilder uriBuilder = new UriBuilder();
                uriBuilder.Scheme = "http";
                uriBuilder.Host = "localhost";
                uriBuilder.Port = port;

                _rootUri = uriBuilder.Uri;
            }

            return started;
        }

        public bool StopWebServer() {
            bool stopped = false;

            if (_server != null) {
                try {
                    _server.Stop();
                    stopped = true;
                }
                catch {
                }
                _server = null;
            }
            return stopped;
        }
    }
}
