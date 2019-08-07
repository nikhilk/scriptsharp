using System.Collections.Generic;

namespace DSharp.Compiler.TestFramework.Data
{
    public interface ITestDataProvider
    {
        IEnumerable<TestCategoryDefinition> GetCategories();

        TestDefinition GetCategoryTest(string category, string testName);

        void LoadDefinitions();
    }
}