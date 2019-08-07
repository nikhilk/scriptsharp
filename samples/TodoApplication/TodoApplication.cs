using System;
using System.Html;
using ComponentLibrary;

namespace TodoApplication
{
    public class TodoApplication : IApplication
    {
        private ButtonComponent helloWorldButton;

        public void Run()
        {
            LoadView();
        }

        private void LoadView()
        {
            helloWorldButton = new ButtonComponent(RootElement.Root, null);
            helloWorldButton.Text = "Press to say hello!";
            helloWorldButton.ButtonPressed += SayHello;
        }

        private void SayHello()
        {
            Window.Alert("Hello World!");
        }

        public void Dispose()
        {
            if (helloWorldButton != null)
            {
                helloWorldButton.ButtonPressed -= SayHello;
            }
        }
    }
}
