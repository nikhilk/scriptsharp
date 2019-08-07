using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSharp.Compiler.TestFramework.Data
{
    public class TestCategoryDefinition
    {
        [JsonProperty("Category")]
        public string Name { get; set; }

        public List<TestDefinition> Tests { get; set; }
    }
}