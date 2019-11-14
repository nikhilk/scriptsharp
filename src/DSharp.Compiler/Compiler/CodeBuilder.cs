using System.Collections.Generic;
using System.Diagnostics;
using DSharp.Compiler.Errors;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler.Compiler
{
    internal sealed class CodeBuilder
    {
        private readonly IErrorHandler errorHandler;

        private readonly CompilerOptions options;

        private List<SymbolImplementation> implementations;

        public CodeBuilder(CompilerOptions options, IErrorHandler errorHandler)
        {
            this.options = options;
            this.errorHandler = errorHandler;
        }

        public ICollection<SymbolImplementation> BuildCode(SymbolSet symbols)
        {
            implementations = new List<SymbolImplementation>();

            foreach (NamespaceSymbol namespaceSymbol in symbols.Namespaces)
            {
                if (namespaceSymbol.HasApplicationTypes == false)
                {
                    continue;
                }

                foreach (TypeSymbol type in namespaceSymbol.Types)
                {
                    if (type.IsApplicationType == false)
                    {
                        continue;
                    }

                    switch (type.Type)
                    {
                        case SymbolType.Class:
                            BuildCode((ClassSymbol)type);

                            break;
                        case SymbolType.Record:

                            if (((RecordSymbol)type).Constructor != null)
                            {
                                BuildCode(((RecordSymbol)type).Constructor);
                            }

                            break;
                    }
                }
            }

            return implementations;
        }

        private void BuildCode(ClassSymbol classSymbol)
        {
            if (classSymbol.Constructor != null)
            {
                BuildCode(classSymbol.Constructor);
            }

            if (classSymbol.StaticConstructor != null)
            {
                BuildCode(classSymbol.StaticConstructor);
            }

            if (classSymbol.Indexer != null)
            {
                BuildCode(classSymbol.Indexer);
            }

            foreach (MemberSymbol memberSymbol in classSymbol.Members)
                switch (memberSymbol.Type)
                {
                    case SymbolType.Event:
                        BuildCode((EventSymbol)memberSymbol);

                        break;
                    case SymbolType.Field:
                        BuildCode((FieldSymbol)memberSymbol);

                        break;
                    case SymbolType.Method:
                        BuildCode((MethodSymbol)memberSymbol);

                        break;
                    case SymbolType.Property:
                        BuildCode((PropertySymbol)memberSymbol);

                        break;
                }
        }

        private void BuildCode(EventSymbol eventSymbol)
        {
            if (eventSymbol.IsAbstract || eventSymbol.DefaultImplementation)
            {
                return;
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(options, errorHandler);

            eventSymbol.AddImplementation(implBuilder.BuildEventAdd(eventSymbol), /* adder */ true);
            eventSymbol.AddImplementation(implBuilder.BuildEventRemove(eventSymbol), /* adder */ false);

            implementations.Add(eventSymbol.AdderImplementation);
            implementations.Add(eventSymbol.RemoverImplementation);

            if (eventSymbol.AnonymousMethods != null)
            {
                foreach (AnonymousMethodSymbol anonymousMethod in eventSymbol.AnonymousMethods)
                {
                    Debug.Assert(anonymousMethod.Implementation != null);

                    implementations.Add(anonymousMethod.Implementation);
                }
            }
        }

        private void BuildCode(FieldSymbol fieldSymbol)
        {
            ImplementationBuilder implBuilder = new ImplementationBuilder(options, errorHandler);
            SymbolImplementation implementation = implBuilder.BuildField(fieldSymbol);

            if (implementation != null)
            {
                fieldSymbol.AddImplementation(implementation);
                implementations.Add(fieldSymbol.Implementation);
            }
        }

        private void BuildCode(IndexerSymbol indexerSymbol)
        {
            if (indexerSymbol.IsAbstract)
            {
                return;
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(options, errorHandler);

            indexerSymbol.AddImplementation(implBuilder.BuildIndexerGetter(indexerSymbol), /* getter */ true);
            implementations.Add(indexerSymbol.GetterImplementation);

            if (indexerSymbol.IsReadOnly == false)
            {
                implBuilder.TryBuildPropertySetter(indexerSymbol, out var implementation);
                indexerSymbol.AddImplementation(implementation, false);
                implementations.Add(indexerSymbol.SetterImplementation);
            }

            if (indexerSymbol.AnonymousMethods != null)
            {
                foreach (AnonymousMethodSymbol anonymousMethod in indexerSymbol.AnonymousMethods)
                {
                    Debug.Assert(anonymousMethod.Implementation != null);

                    implementations.Add(anonymousMethod.Implementation);
                }
            }
        }

        private void BuildCode(MethodSymbol methodSymbol)
        {
            if (methodSymbol.IsAbstract)
            {
                return;
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(options, errorHandler);
            methodSymbol.AddImplementation(implBuilder.BuildMethod(methodSymbol));

            implementations.Add(methodSymbol.Implementation);

            if (methodSymbol.AnonymousMethods != null)
            {
                foreach (AnonymousMethodSymbol anonymousMethod in methodSymbol.AnonymousMethods)
                {
                    Debug.Assert(anonymousMethod.Implementation != null);

                    implementations.Add(anonymousMethod.Implementation);
                }
            }
        }

        private void BuildCode(PropertySymbol propertySymbol)
        {
            if (propertySymbol.IsAbstract || propertySymbol.IsAutoProperty())
            {
                return;
            }

            ImplementationBuilder implBuilder = new ImplementationBuilder(options, errorHandler);

            if (implBuilder.TryBuildPropertyGetter(propertySymbol, out SymbolImplementation getter))
            {
                propertySymbol.AddImplementation(getter, /* getter */ true);
                implementations.Add(getter);
            }

            if (implBuilder.TryBuildPropertySetter(propertySymbol, out SymbolImplementation setter))
            {
                propertySymbol.AddImplementation(setter, /* getter */ false);
                implementations.Add(setter);
            }

            if (propertySymbol.AnonymousMethods != null)
            {
                foreach (AnonymousMethodSymbol anonymousMethod in propertySymbol.AnonymousMethods)
                {
                    Debug.Assert(anonymousMethod.Implementation != null);

                    implementations.Add(anonymousMethod.Implementation);
                }
            }
        }
    }
}
