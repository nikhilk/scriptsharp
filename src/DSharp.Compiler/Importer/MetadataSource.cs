// MetadataSource.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DSharp.Compiler.Errors;
using Mono.Cecil;

namespace DSharp.Compiler.Importer
{
    internal sealed class MetadataSource
    {
        private static readonly string CoreAssemblyName = DSharpStringResources.DSHARP_MSCORLIB_ASSEMBLY_NAME;

        private Dictionary<string, AssemblyDefinition> assemblyMap;

        private List<string> assemblyPaths;

        public ICollection<string> Assemblies => assemblyPaths;

        public string CoreAssemblyPath { get; private set; }

        public AssemblyDefinition CoreAssemblyMetadata { get; private set; }

        public AssemblyDefinition GetMetadata(string assembly)
        {
            return assemblyMap[assembly];
        }

        public bool LoadReferences(ICollection<string> references, IErrorHandler errorHandler)
        {
            bool hasLoadErrors = false;

            AssemblySet assemblySet = new AssemblySet();

            foreach (string referencePath in references)
            {
                string assemblyFilePath = Path.GetFullPath(referencePath);

                if (File.Exists(assemblyFilePath) == false)
                {
                    errorHandler.ReportMissingAssemblyReferenceError(referencePath);
                    hasLoadErrors = true;

                    continue;
                }

                string referenceName = Path.GetFileNameWithoutExtension(assemblyFilePath);

                if (assemblySet.IsReferenced(referenceName))
                {
                    errorHandler.ReportDuplicateAssemblyReferenceError(referenceName, referencePath);
                    hasLoadErrors = true;

                    continue;
                }

                try
                {
                    AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyFilePath);

                    if (assembly == null)
                    {
                        errorHandler.ReportAssemblyLoadError(referenceName, referencePath);
                        hasLoadErrors = true;

                        continue;
                    }

                    if (referenceName.Equals(CoreAssemblyName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (CoreAssemblyPath != null)
                        {
                            errorHandler.ReportDuplicateAssemblyReferenceError(referenceName, referencePath);
                            hasLoadErrors = true;
                        }
                        else
                        {
                            CoreAssemblyPath = assemblyFilePath;
                            CoreAssemblyMetadata = assembly;
                        }
                    }
                    else
                    {
                        assemblySet.AddAssembly(assemblyFilePath, referenceName, assembly);
                    }
                }
                catch (Exception e)
                {
                    Debug.Fail(e.ToString());

                    errorHandler.ReportAssemblyLoadError(referenceName, referencePath);
                    hasLoadErrors = true;
                }
            }

            if (CoreAssemblyMetadata == null)
            {
                errorHandler.ReportMissingAssemblyReferenceError(CoreAssemblyName);
                hasLoadErrors = true;
            }

            assemblyMap = assemblySet.Assemblies;
            assemblyPaths = assemblySet.GetAssemblyPaths();

            return hasLoadErrors;
        }

        private sealed class AssemblySet
        {
            private readonly HashSet<string> assemblyNames;

            public AssemblySet()
            {
                Assemblies = new Dictionary<string, AssemblyDefinition>(StringComparer.Ordinal);
                assemblyNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            public Dictionary<string, AssemblyDefinition> Assemblies { get; }

            public void AddAssembly(string path, string referenceName, AssemblyDefinition assembly)
            {
                Assemblies[path] = assembly;
                assemblyNames.Add(referenceName);
            }

            public List<string> GetAssemblyPaths()
            {
                // Perform a topological sort to get the list of assemblies in order
                // to cause loading of dependencies to happen before an assembly
                // that references them.

                List<AssemblyReference> references = new List<AssemblyReference>();
                Dictionary<string, AssemblyReference> referenceMap =
                    new Dictionary<string, AssemblyReference>(StringComparer.Ordinal);

                foreach (KeyValuePair<string, AssemblyDefinition> assembly in Assemblies)
                {
                    AssemblyReference reference = new AssemblyReference(assembly.Key, assembly.Value);
                    references.Add(reference);
                    referenceMap[reference.FullName] = reference;
                }

                List<AssemblyReference> sortedReferences = new List<AssemblyReference>();
                references.ForEach(r => VisitReference(r, referenceMap, sortedReferences));

                return sortedReferences.Select(r => r.Path).ToList();
            }

            public bool IsReferenced(string referenceName)
            {
                return assemblyNames.Contains(referenceName);
            }

            private void VisitReference(AssemblyReference reference, Dictionary<string, AssemblyReference> referenceMap,
                                        List<AssemblyReference> referenceList)
            {
                if (reference.Visited)
                {
                    return;
                }

                reference.Visit();

                foreach (string dependencyName in reference.Dependencies)
                {
                    if (referenceMap.TryGetValue(dependencyName, out AssemblyReference dependencyReference))
                    {
                        VisitReference(dependencyReference, referenceMap, referenceList);
                    }
                }

                referenceList.Add(reference);
            }
        }

        private sealed class AssemblyReference
        {
            private readonly AssemblyDefinition assembly;
            private readonly List<string> dependencies;

            public AssemblyReference(string path, AssemblyDefinition assembly)
            {
                Path = path;
                this.assembly = assembly;

                dependencies = assembly.MainModule.AssemblyReferences.Select(a => a.FullName).ToList();
            }

            public string FullName => assembly.FullName;

            public string Path { get; }

            public IEnumerable<string> Dependencies => dependencies;

            public bool Visited { get; private set; }

            public void Visit()
            {
                Visited = true;
            }
        }
    }
}
