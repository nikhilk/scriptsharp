using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DSharp.Compiler.TestFramework.Data
{
    public class TestDataProvider : ITestDataProvider
    {
        private readonly string filePath;
        private readonly List<TestCategoryDefinition> testCategoryDefinitions = new List<TestCategoryDefinition>();

        public TestDataProvider(string filePath)
        {
            this.filePath = Path.IsPathRooted(filePath)
                ? filePath
                : Path.GetFullPath(filePath);
        }

        public IEnumerable<TestCategoryDefinition> GetCategories()
        {
            return testCategoryDefinitions;
        }

        public TestDefinition GetCategoryTest(string category, string testName)
        {
            return testCategoryDefinitions
                .FirstOrDefault((testCategory) => string.Equals(category, testCategory.Name, StringComparison.CurrentCultureIgnoreCase))
                .Tests
                .FirstOrDefault((test) => string.Equals(testName, test.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        public void LoadDefinitions()
        {
            FileInfo configurationFile = new FileInfo(filePath);

            if (!configurationFile.Exists)
            {
                throw new FileNotFoundException($"Missing configuration file: {configurationFile.FullName}");
            }

            TestCategoryDefinition[] definitions = null;
            JsonSerializer jsonSerializer = new JsonSerializer();

            using (JsonReader reader = new JsonTextReader(configurationFile.OpenText()))
            {
                definitions = jsonSerializer.Deserialize<TestCategoryDefinition[]>(reader);
            }

            testCategoryDefinitions.AddRange(definitions ?? Array.Empty<TestCategoryDefinition>());
        }
    }
}