// MockFlickrService.cs
//

using System;
using System.Collections.Generic;
using AroundMe.Services;

namespace AroundMe.Tests {

    public class MockFlickrService : IFlickrService {

        private Action<IEnumerable<PhotoResult>> _searchCallback;
        private int _searchCount;

        public MockFlickrService() {
            _searchCount = 0;
        }

        public int SearchCount {
            get {
                return _searchCount;
            }
        }

        public void InvokeCallback(IEnumerable<PhotoResult> results) {
            _searchCallback(results);
        }

        public void SearchLocation(string tags, double latitude, double longitude, Action<IEnumerable<PhotoResult>> searchCallback) {
            _searchCallback = searchCallback;
            _searchCount++;
        }

        public void SearchRegion(string text, double latitude1, double longitude1, double latitude2, double longitude2, Action<IEnumerable<PhotoResult>> searchCallback) {
            _searchCallback = searchCallback;
            _searchCount++;
        }
    }
}
