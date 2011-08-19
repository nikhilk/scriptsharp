// IFlickrService.cs
//

using System;
using System.Collections.Generic;

namespace AroundMe.Services {

    interface IFlickrService {
    
        void SearchLocation(string tags, double latitude, double longitude, Action<IEnumerable<PhotoResult>> searchCallback);

        void SearchRegion(string text, double latitude1, double longitude1, double latitude2, double longitude2, Action<IEnumerable<PhotoResult>> searchCallback);
    }
}
