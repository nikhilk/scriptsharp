using System;
using System.Collections.Generic;
using DSharp.Compiler.TestFramework.Compilation.Sources;
using DSharp.Compiler.TestFramework.Context;

namespace DSharp.Compiler.TestFramework.Compilation
{
    public static class CompilationUnitBuilderExtensions
    {
        public static ICompilationUnitBuilder AddReferences(this ICompilationUnitBuilder compilationUnitBuilder, params string[] references)
        {
            ICollection<string> compilationReferences = compilationUnitBuilder.Options.References;

            foreach (string reference in references ?? Array.Empty<string>())
            {
                compilationReferences.Add(reference);
            }

            return compilationUnitBuilder;
        }

        public static ICompilationUnitBuilder AddSourceFiles(this ICompilationUnitBuilder compilationUnitBuilder, params string[] sourceFiles)
        {
            ICollection<IStreamSource> sources = compilationUnitBuilder.Options.Sources;

            foreach (string sourcePath in sourceFiles ?? Array.Empty<string>())
            {
                IStreamSource inputSource = new FileInputSource(sourcePath);
                sources.Add(inputSource);
            }

            return compilationUnitBuilder;
        }

        public static ICompilationUnitBuilder AddResources(this ICompilationUnitBuilder compilationUnitBuilder, params string[] resourceFiles)
        {
            ICollection<IStreamSource> resources = compilationUnitBuilder.Options.Resources;

            foreach (string resourceFile in resourceFiles ?? Array.Empty<string>())
            {
                resources.Add(new FileInputSource(resourceFile));
            }

            return compilationUnitBuilder;
        }

        public static ICompilationUnitBuilder AddDefines(this ICompilationUnitBuilder compilationUnitBuilder, params string[] defines)
        {
            ISet<string> configuredDefines = compilationUnitBuilder.Options.Defines as ISet<string>;

            foreach (string define in defines ?? Array.Empty<string>())
            {
                configuredDefines?.Add(define);
            }

            return compilationUnitBuilder;
        }

        public static ICompilationUnitBuilder AddCommentFile(this ICompilationUnitBuilder compilationUnitBuilder, string filePath)
        {
            if(!string.IsNullOrEmpty(filePath))
            {
                compilationUnitBuilder.Options.DocCommentFile = new FileInputSource(filePath);
            }

            return compilationUnitBuilder;
        }

        public static ICompilationUnitBuilder AddMetadataFile(this ICompilationUnitBuilder compilationUnitBuilder, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                compilationUnitBuilder.Options.MetadataFile = new InMemoryStream();
            }

            return compilationUnitBuilder;
        }

        public static ICompilationUnitBuilder AddStreamResolver(this ICompilationUnitBuilder compilationUnitBuilder, IStreamSourceResolver streamSourceResolver)
        {
            compilationUnitBuilder.Options.IncludeResolver = streamSourceResolver;

            return compilationUnitBuilder;
        }

        public static ICompilationUnitBuilder WithCompilationOptions(this ICompilationUnitBuilder compilationUnitBuilder, TestContextCompliationOptions compliationOptions)
        {
            if(compliationOptions != null)
            {
                compilationUnitBuilder.Options.Minimize = compliationOptions.Minimize;
            }

            return compilationUnitBuilder;
        }
    }
}
