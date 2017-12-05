// MetadataSource.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ScriptSharp;
using ScriptSharp.Importer.IL;

namespace ScriptSharp.Importer {

    internal sealed class MetadataSource {

        private static readonly string CoreAssemblyName = "mscorlib";

        private List<string> _assemblyPaths;
        private string _coreAssemblyPath;

        private Dictionary<string, AssemblyDefinition> _assemblyMap;
        private AssemblyDefinition _coreAssembly;

        public ICollection<string> Assemblies {
            get {
                return _assemblyPaths;
            }
        }

        public string CoreAssemblyPath {
            get {
                return _coreAssemblyPath;
            }
        }

        public AssemblyDefinition CoreAssemblyMetadata {
            get {
                return _coreAssembly;
            }
        }

        public AssemblyDefinition GetMetadata(string assembly) {
            return _assemblyMap[assembly];
        }

        public bool LoadReferences(ICollection<string> references, IErrorHandler errorHandler) {
            bool hasLoadErrors = false;

            AssemblySet assemblySet = new AssemblySet();

            foreach (string referencePath in references) {
                string assemblyFilePath = Path.GetFullPath(referencePath);
                if (File.Exists(assemblyFilePath) == false) {
                    errorHandler.ReportError("The referenced assembly '" + referencePath + "' could not be located.", String.Empty);
                    hasLoadErrors = true;
                    continue;
                }

                string referenceName = Path.GetFileNameWithoutExtension(assemblyFilePath);
                if (assemblySet.IsReferenced(referenceName)) {
                    errorHandler.ReportError("The referenced assembly '" + referencePath + "' is a duplicate reference.", String.Empty);
                    hasLoadErrors = true;

                    continue;
                }

                try {
                    AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyFilePath);
                    if (assembly == null) {
                        errorHandler.ReportError("The referenced assembly '" + referencePath + "' could not be loaded as an assembly.", String.Empty);
                        hasLoadErrors = true;
                        continue;
                    }

                    if (referenceName.Equals(CoreAssemblyName, StringComparison.OrdinalIgnoreCase)) {
                        if (_coreAssemblyPath != null) {
                            errorHandler.ReportError("The core runtime assembly, mscorlib.dll must be referenced only once.", String.Empty);
                            hasLoadErrors = true;

                            continue;
                        }
                        else {
                            _coreAssemblyPath = assemblyFilePath;
                            _coreAssembly = assembly;
                        }
                    }
                    else {
                        assemblySet.AddAssembly(assemblyFilePath, referenceName, assembly);
                    }
                }
                catch (Exception e) {
                    Debug.Fail(e.ToString());

                    errorHandler.ReportError("The referenced assembly '" + referencePath + "' could not be loaded as an assembly.", String.Empty);
                    hasLoadErrors = true;
                }
            }

            if (_coreAssembly == null) {
                errorHandler.ReportError("The 'mscorlib' assembly must be referenced.", String.Empty);
                hasLoadErrors = true;
            }
            else {
                if (VerifyScriptAssembly(_coreAssembly) == false) {
                    errorHandler.ReportError("The assembly '" + _coreAssemblyPath + "' is not a valid script assembly.", String.Empty);
                    hasLoadErrors = true;
                }
            }

            foreach (KeyValuePair<string, AssemblyDefinition> assemblyReference in assemblySet.Assemblies) {
                if (VerifyScriptAssembly(assemblyReference.Value) == false) {
                    errorHandler.ReportError("The assembly '" + assemblyReference.Key + "' is not a valid script assembly.", String.Empty);
                    hasLoadErrors = true;
                }
            }

            _assemblyMap = assemblySet.Assemblies;
            _assemblyPaths = assemblySet.GetAssemblyPaths();

            return hasLoadErrors;
        }

        private bool VerifyScriptAssembly(AssemblyDefinition assembly) {
            foreach (CustomAttribute attribute in assembly.CustomAttributes) {
                if (String.CompareOrdinal(attribute.Constructor.DeclaringType.FullName, "System.ScriptAssemblyAttribute") == 0) {
                    return true;
                }
            }

            return false;
        }


        private sealed class AssemblySet {

            private Dictionary<string, AssemblyDefinition> _assemblies;
            private HashSet<string> _assemblyNames;

            public AssemblySet() {
                _assemblies = new Dictionary<string, AssemblyDefinition>(StringComparer.Ordinal);
                _assemblyNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            public Dictionary<string, AssemblyDefinition> Assemblies {
                get {
                    return _assemblies;
                }
            }

            public void AddAssembly(string path, string referenceName, AssemblyDefinition assembly) {
                _assemblies[path] = assembly;
                _assemblyNames.Add(referenceName);
            }

            public List<string> GetAssemblyPaths() {
                // Perform a topological sort to get the list of assemblies in order
                // to cause loading of dependencies to happen before an assembly
                // that references them.

                List<AssemblyReference> references = new List<AssemblyReference>();
                Dictionary<string, AssemblyReference> referenceMap =
                    new Dictionary<string, AssemblyReference>(StringComparer.Ordinal);

                foreach (KeyValuePair<string, AssemblyDefinition> assembly in _assemblies) {
                    AssemblyReference reference = new AssemblyReference(assembly.Key, assembly.Value);
                    references.Add(reference);
                    referenceMap[reference.FullName] = reference;
                }

                List<AssemblyReference> sortedReferences = new List<AssemblyReference>();
                references.ForEach(r => VisitReference(r, referenceMap, sortedReferences));

                return sortedReferences.Select(r => r.Path).ToList();
            }

            public bool IsReferenced(string referenceName) {
                return _assemblyNames.Contains(referenceName);
            }

            private void VisitReference(AssemblyReference reference, Dictionary<string, AssemblyReference> referenceMap, List<AssemblyReference> referenceList) {
                if (reference.Visited) {
                    return;
                }

                reference.Visit();
                foreach (string dependencyName in reference.Dependencies) {
                    AssemblyReference dependencyReference;
                    if (referenceMap.TryGetValue(dependencyName, out dependencyReference)) {
                        VisitReference(dependencyReference, referenceMap, referenceList);
                    }
                }

                referenceList.Add(reference);
            }
        }

        private sealed class AssemblyReference {

            private string _path;
            private List<string> _dependencies;
            private AssemblyDefinition _assembly;

            private bool _visited;

            public AssemblyReference(string path, AssemblyDefinition assembly) {
                _path = path;
                _assembly = assembly;

                _dependencies = assembly.MainModule.AssemblyReferences.Select(a => a.FullName).ToList();
            }

            public string FullName {
                get {
                    return _assembly.FullName;
                }
            }

            public string Path {
                get {
                    return _path;
                }
            }

            public IEnumerable<string> Dependencies {
                get {
                    return _dependencies;
                }
            }

            public bool Visited {
                get {
                    return _visited;
                }
            }

            public void Visit() {
                _visited = true;
            }
        }
    }
}
