using System.Collections.Generic;
using System.IO;

namespace DSharp.Compiler.TestFramework.Context
{
    public interface ITestContextFactory
    {
        ITestContext GetContext(string category, string testName);

        IList<string> GetTestSourceFiles(string category, string testName);
    }
}
