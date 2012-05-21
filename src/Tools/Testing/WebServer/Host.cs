// Host.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Hosting;

namespace ScriptSharp.Testing.WebServer {

    internal sealed class Host : MarshalByRefObject, IRegisteredObject {

        private Server _server;

        private int _port;
        private volatile int _pendingCallsCount;
        private string _virtualPath;
        private string _lowerCasedVirtualPath;
        private string _lowerCasedVirtualPathWithTrailingSlash;
        private string _physicalPath;
        private string _installPath;

        public Host() {
            HostingEnvironment.RegisterObject(this);
        }

        public override object InitializeLifetimeService() {
            // never expire the license
            return null;
        }

        public void Configure(Server server, int port, string virtualPath, string physicalPath) {
            _server = server;

            _port = port;
            _installPath = null;
            _virtualPath = virtualPath;

            _lowerCasedVirtualPath = CultureInfo.InvariantCulture.TextInfo.ToLower(_virtualPath);
            _lowerCasedVirtualPathWithTrailingSlash = virtualPath.EndsWith("/", StringComparison.Ordinal) ? virtualPath : virtualPath + "/";
            _lowerCasedVirtualPathWithTrailingSlash = CultureInfo.InvariantCulture.TextInfo.ToLower(_lowerCasedVirtualPathWithTrailingSlash);
            _physicalPath = physicalPath;
        }

        public void ProcessRequest(Connection conn) {
            // Add a pending call to make sure our thread doesn't get killed
            AddPendingCall();

            try {
                Request request = new Request(_server, this, conn);
                request.Process();
            }
            finally {
                RemovePendingCall();
            }
        }

        private void WaitForPendingCallsToFinish() {
            for (;;) {
                if (_pendingCallsCount <= 0) {
                    break;
                }

                Thread.Sleep(250);
            }
        }

        private void AddPendingCall() {
#pragma warning disable 0420
            Interlocked.Increment(ref _pendingCallsCount);
#pragma warning restore 0420
        }

        private void RemovePendingCall() {
#pragma warning disable 0420
            Interlocked.Decrement(ref _pendingCallsCount);
#pragma warning restore 0420
        }

        public void Shutdown() {
            HostingEnvironment.InitiateShutdown();
        }

        void IRegisteredObject.Stop(bool immediate) {
            // Unhook the Host so Server will process the requests in the new appdomain.
            if (_server != null) {
                _server.HostStopped();
            }

            // Make sure all the pending calls complete before this Object is unregistered.
            WaitForPendingCallsToFinish();

            HostingEnvironment.UnregisterObject(this);
        }

        public string InstallPath {
            get {
                return _installPath;
            }
        }

        public string NormalizedVirtualPath {
            get {
                return _lowerCasedVirtualPathWithTrailingSlash;
            }
        }

        public string PhysicalPath {
            get {
                return _physicalPath;
            }
        }

        public int Port {
            get {
                return _port;
            }
        }

        public string VirtualPath {
            get {
                return _virtualPath;
            }
        }

        public bool IsVirtualPathInApp(string path) {
            if (path == null) {
                return false;
            }

            if (_virtualPath == "/" && path.StartsWith("/", StringComparison.Ordinal)) {
               return true;
            }

            path = CultureInfo.InvariantCulture.TextInfo.ToLower(path);

            if (path.StartsWith(_lowerCasedVirtualPathWithTrailingSlash, StringComparison.Ordinal)) {
                return true;
            }

            if (path == _lowerCasedVirtualPath) {
                return true;
            }

            return false;
        }

        public bool IsVirtualPathAppPath(string path) {
            if (path == null) {
                return false;
            }

            path = CultureInfo.InvariantCulture.TextInfo.ToLower(path);
            return (path == _lowerCasedVirtualPath || path == _lowerCasedVirtualPathWithTrailingSlash);
        }
    }
}
