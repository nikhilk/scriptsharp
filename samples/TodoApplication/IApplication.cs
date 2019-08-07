using System;

namespace TodoApplication
{
    public interface IApplication : IDisposable
    {
        void Run();
    }
}
