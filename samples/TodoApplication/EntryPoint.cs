using System;
using System.Html;

namespace TodoApplication
{
    internal static class EntryPoint
    {
        private static IApplication application;

        static EntryPoint()
        {
            application = new TodoApplication();
            application.Run();

            Window.AddEventListener("onbeforeunload", HandleApplicationExit);
        }

        private static void HandleApplicationExit(ElementEvent e)
        {
            application.Dispose();
            application = null;
        }
    }
}
