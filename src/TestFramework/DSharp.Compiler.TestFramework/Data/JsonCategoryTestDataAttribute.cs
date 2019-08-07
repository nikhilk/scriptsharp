using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace DSharp.Compiler.TestFramework.Data
{
    public class JsonCategoryTestDataAttribute : DataAttribute
    {
        private readonly ITestDataProvider testDataProvider;

        public JsonCategoryTestDataAttribute(string filePath)
            : base()
        {
            testDataProvider = new TestDataProvider(filePath);

        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            testDataProvider.LoadDefinitions();

            List<object[]> categoryTests = new List<object[]>();

            foreach (TestCategoryDefinition category in testDataProvider.GetCategories())
            {
                if (!string.IsNullOrEmpty(category?.Name))
                {
                    foreach (TestDefinition test in category.Tests)
                    {
                        if (!string.IsNullOrEmpty(test.Name))
                        {
                            categoryTests.Add(new object[] { category.Name, test.Name });
                        }
                    }
                }
            }

            return categoryTests;
        }
    }
}
