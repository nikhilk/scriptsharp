// Server.cs
//

using System;
using System.Diagnostics;
using NodeApi;
using NodeApi.ExpressJS;
using Cellar;
using Cellar.Controllers;

[ScriptModule]
internal static class Server {

    static Server() {
        string dbUrl = Node.Process.Arguments[2];
        if (String.IsNullOrEmpty(dbUrl)) {
            Debug.WriteLine("Usage: node cellar.server.js <database url>");
            Debug.WriteLine("Format of database url:");
            Debug.WriteLine("  mongodb://user:password@host:port/database");
            Debug.WriteLine(String.Empty);
            return;
        }

        CellarApplication cellarApplication = new CellarApplication();
        cellarApplication.Initialize(dbUrl, delegate(Exception initializationError) {
            if (initializationError != null) {
                Debug.WriteLine(initializationError.ToString());
                return;
            }

            Debug.WriteLine("Starting web application on port 8080...");
            string path = (string)Script.Literal("__dirname");

            ExpressApplication app = Express.Application();
            app.Use(Express.Static(path + "\\Content"));
            app.Get("/wines/:id", delegate(ExpressServerRequest request, ExpressServerResponse response) {
                   WinesController controller = cellarApplication.CreateWinesController();
                   controller.LookupWine(request, response);
               })
               .Get("/wines", delegate(ExpressServerRequest request, ExpressServerResponse response) {
                   WinesController controller = cellarApplication.CreateWinesController();
                   controller.QueryWines(request, response);
               });

            app.Listen(8080);
        });
    }
}
