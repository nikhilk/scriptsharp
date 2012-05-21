// WebBrowser.cs
// Script#/Tools/Testing
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.IO;
using Microsoft.Win32;

namespace ScriptSharp.Testing {

    public sealed class WebBrowser {

        public static readonly WebBrowser InternetExplorer = new WebBrowser("Internet Explorer", "iexplore.exe", "-noframemerging ");
        public static readonly WebBrowser Chrome = new WebBrowser("Chrome", GetChromeExecutablePath(), "--new-window ");
        public static readonly WebBrowser Firefox = new WebBrowser("Firefox", GetFirefoxExecutablePath(), "-new-window ");
        public static readonly WebBrowser Safari = new WebBrowser("Safari", GetSafariExecutablePath(), String.Empty);

        private string _name;
        private string _executablePath;
        private string _arguments;

        private WebBrowser(string name, string executablePath, string arguments) {
            _name = name;
            _executablePath = executablePath;
            _arguments = arguments;
        }

        internal string Arguments {
            get {
                return _arguments;
            }
        }

        internal string ExecutablePath {
            get {
                return _executablePath;
            }
        }

        public string Name {
            get {
                return _name;
            }
        }

        private static string GetChromeExecutablePath() {
            string path = null;

            RegistryKey chromeKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\Google Chrome\");
            if (chromeKey != null) {
                path = Path.Combine((string)chromeKey.GetValue("InstallLocation"), "chrome.exe");
                if (!File.Exists(path)) {
                    path = null;
                }
            }

            return path;
        }

        private static string GetFirefoxExecutablePath() {
            string path = null;

            RegistryKey mozillaKey = Registry.LocalMachine.OpenSubKey(@"Software\Mozilla\Mozilla Firefox");
            if (mozillaKey != null) {
                string currentVersion = (string)mozillaKey.GetValue("CurrentVersion");
                if (String.IsNullOrEmpty(currentVersion) == false) {
                    RegistryKey currentMain = mozillaKey.OpenSubKey(String.Format(@"{0}\Main", currentVersion));
                    if (currentMain != null) {
                        path = (string)currentMain.GetValue("PathToExe");
                        if (File.Exists(path) == false) {
                            path = null;
                        }
                    }
                }
            }
            else {
                string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Mozilla FireFox\FireFox.exe");
                if (File.Exists(tempPath)) {
                    path = tempPath;
                }
                else {
                    tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + " (x86)", @"Mozilla FireFox\FireFox.exe");
                    if (File.Exists(tempPath) == false) {
                        path = tempPath;
                    }
                }
            }

            return path;
        }

        private static string GetSafariExecutablePath() {
            string path = null;

            RegistryKey safariKey = Registry.LocalMachine.OpenSubKey(@"Software\Apple Computer, Inc.\Safari");
            if (safariKey != null) {
                path = (string)safariKey.GetValue("BrowserExe");
                if (!File.Exists(path)) {
                    path = null;
                }
            }

            return path;
        }
    }
}
