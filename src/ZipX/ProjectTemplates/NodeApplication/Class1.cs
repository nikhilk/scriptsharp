// Class1.cs
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using NodeApi;
using NodeApi.Network;

[ScriptModule]
internal static class Class1 {

    static Class1() {
        // A basic Hello-World app. Replace with your own application...

        Http.CreateServer(delegate(HttpServerRequest request, HttpServerResponse response) {
            response.WriteHead(HttpStatusCode.OK,
                               new Dictionary<string, string>("Content-Type", "text/html"));
            response.End("Hello Node.js World, from Script#!");
        }).Listen(1337, "127.0.0.1");

        Debug.WriteLine("Server running at http://127.0.0.1:1337/");
    }
}
