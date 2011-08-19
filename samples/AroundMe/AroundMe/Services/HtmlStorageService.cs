// HtmlStorageService.cs
//

using System;
using System.Html;

namespace AroundMe.Services {

    internal sealed class HtmlStorageService : IStorageService {

        public string GetValue(string key) {
            return (string)Window.LocalStorage[key];
        }

        public void SetValue(string key, string value) {
            Window.LocalStorage[key] = value;
        }
    }
}
