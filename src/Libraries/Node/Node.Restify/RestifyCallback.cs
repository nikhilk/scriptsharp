// RestifyCallback.cs
// Script#/Libraries/Node/Restify
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace NodeApi.Restify {

    public delegate void RestifyCallback(RestifyError error, RestifyRequest request, RestifyResponse response, object content);
}
