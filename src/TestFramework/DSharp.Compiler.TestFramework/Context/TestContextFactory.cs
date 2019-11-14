using System;
using System.Collections.Generic;
using System.IO;
using DSharp.Compiler.TestFramework.Data;
using Mapster;

namespace DSharp.Compiler.TestFramework.Context
{
    public class TestContextFactory : ITestContextFactory
    {
        private const string REFERENCES_FOLDER = "references";

        private readonly string rootDirectory;
        private readonly ITestDataProvider testDataProvider;

        public TestContextFactory(string rootDirectory, ITestDataProvider testDataProvider)
        {
            this.rootDirectory = rootDirectory;
            this.testDataProvider = testDataProvider;

            testDataProvider.LoadDefinitions();
        }

        public ITestContext GetContext(string category, string testName)
        {
            TestDefinition testData = testDataProvider.GetCategoryTest(category, testName);
            if (testData == null)
            {
                throw new InvalidOperationException($"Unable to execute test {testName} for {category} as there was no defined test data");
            }

            string testFolder = !string.IsNullOrEmpty(testData?.SourceFolder)
                ? testData.SourceFolder
                : testName;

            string testFilesPath = Path.Combine(rootDirectory, category, testFolder);

            List<FileInfo> sourceFiles = GetSourceFiles(testData, testFilesPath);
            List<FileInfo> referenceFiles = GetReferenceFiles(testData, testFilesPath);
            List<FileInfo> resourceFiles = GetResourceFiles(testData, testFilesPath);

            FileInfo comparisonFile = GetComparisonFile(testData, testFilesPath);
            FileInfo commentFile = GetCommentFile(testData, testFilesPath);

            return new TestContext
            {
                SourceFiles = sourceFiles.ToArray(),
                Defines = testData.Defines,
                References = referenceFiles.ToArray(),
                ExpectedOutput = comparisonFile,
                CommentFile = commentFile,
                StreamSourceResolver = new LocalTestContextStreamResolver(new DirectoryInfo(testFilesPath)),
                Resources = resourceFiles.ToArray(),
                CompilationOptions = testData.Options.Adapt<TestContextCompliationOptions>()
            };
        }

        public IList<string> GetTestSourceFiles(string category, string testName)
        {
            string testFilesPath = Path.Combine(rootDirectory, category, testName);
            return Directory.GetFiles(testFilesPath, "*.cs", SearchOption.TopDirectoryOnly);
        }

        private static FileInfo GetCommentFile(TestDefinition testData, string testFilesPath)
        {
            FileInfo commentFile = null;
            if (!string.IsNullOrEmpty(testData.DocumentCommentFile))
            {
                commentFile = new FileInfo(Path.Combine(testFilesPath, testData.DocumentCommentFile));
                if (!commentFile.Exists)
                {
                    throw new FileNotFoundException($"Missing comment file file: {commentFile.FullName}");
                }
            }

            return commentFile;
        }

        private static FileInfo GetComparisonFile(TestDefinition testData, string testFilesPath)
        {
            FileInfo comparisonFile = new FileInfo(Path.Combine(testFilesPath, testData.ComparisonFile));
            if (!comparisonFile.Exists)
            {
                throw new FileNotFoundException($"Missing comparison file: {comparisonFile.FullName}");
            }

            return comparisonFile;
        }

        private static List<FileInfo> GetSourceFiles(TestDefinition testData, string testFilesPath)
        {
            List<FileInfo> sourceFiles = new List<FileInfo>();

            foreach (string fileName in testData.SourceFiles)
            {
                FileInfo filePath = new FileInfo(Path.Combine(testFilesPath, fileName));

                if (!filePath.Exists)
                {
                    throw new FileNotFoundException($"Missing source file: {filePath.FullName}");
                }

                sourceFiles.Add(filePath);
            }

            return sourceFiles;
        }

        private static List<FileInfo> GetReferenceFiles(TestDefinition testData, string testFilesPath)
        {
            List<FileInfo> assemblyFiles = new List<FileInfo>();

            foreach (string assemblyFileName in testData.References ?? Array.Empty<string>())
            {
                string assemblyFilePath = Path.Combine(testFilesPath, assemblyFileName);

                if (!File.Exists(assemblyFilePath))
                {
                    assemblyFilePath = Path.Combine(Directory.GetCurrentDirectory(), REFERENCES_FOLDER, assemblyFileName);
                    if (!File.Exists(assemblyFilePath))
                    {
                        throw new FileNotFoundException($"Unable to find assembly file at either {Path.Combine(testFilesPath, assemblyFileName)} or {assemblyFilePath}");
                    }
                }

                assemblyFiles.Add(new FileInfo(assemblyFilePath));
            }

            return assemblyFiles;
        }

        private static List<FileInfo> GetResourceFiles(TestDefinition testData, string testFilesPath)
        {
            List<FileInfo> resourceFiles = new List<FileInfo>();

            foreach (string fileName in testData.Resources ?? Array.Empty<string>())
            {
                FileInfo filePath = new FileInfo(Path.Combine(testFilesPath, fileName));

                if (!filePath.Exists)
                {
                    throw new FileNotFoundException($"Missing resource file: {filePath.FullName}");
                }

                resourceFiles.Add(filePath);
            }

            return resourceFiles;
        }
    }
}
