// IPhotoService.cs
//

using System;
using System.Collections.Generic;
using jQueryApi;

namespace Flickr {

    public interface IPhotoService {

        IDeferred<IEnumerable<Photo>> SearchPhotos(string tags, int count);
    }
}
