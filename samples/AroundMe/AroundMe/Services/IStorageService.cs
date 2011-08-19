// IStorageService.cs
//

using System;

namespace AroundMe.Services {

    internal interface IStorageService {

        string GetValue(string key);

        void SetValue(string key, string value);
    }
}
