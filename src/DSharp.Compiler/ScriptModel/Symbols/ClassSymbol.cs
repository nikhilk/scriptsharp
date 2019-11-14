// ClassSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal class ClassSymbol : TypeSymbol
    {
        private ClassSymbol baseClass;

        private ConstructorSymbol constructor;

        private IndexerSymbol indexer;
        private int inheritanceDepth;
        private ICollection<InterfaceSymbol> interfaces;
        private int minimizationDepth;

        private ClassSymbol primaryPartialClass;
        private bool staticClass;
        private ConstructorSymbol staticConstructor;
        private int transformationCookie;

        public ClassSymbol(string name, NamespaceSymbol parent)
            : this(SymbolType.Class, name, parent)
        {
        }

        protected ClassSymbol(SymbolType type, string name, NamespaceSymbol parent)
            : base(type, name, parent)
        {
            inheritanceDepth = -1;
            minimizationDepth = -1;
            transformationCookie = -1;
        }

        public ClassSymbol BaseClass
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.BaseClass;
                }

                return baseClass;
            }
        }

        public ConstructorSymbol Constructor
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.Constructor;
                }

                return constructor;
            }
        }

        public override string GeneratedName
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.GeneratedName;
                }

                return base.GeneratedName;
            }
        }

        public IndexerSymbol Indexer
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.Indexer;
                }

                return indexer;
            }
        }

        public int InheritanceDepth
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.InheritanceDepth;
                }

                if (inheritanceDepth == -1)
                {
                    if (baseClass != null)
                    {
                        inheritanceDepth = baseClass.InheritanceDepth + 1;
                    }
                    else
                    {
                        inheritanceDepth = 0;
                    }
                }

                return inheritanceDepth;
            }
        }

        public ICollection<InterfaceSymbol> Interfaces
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.Interfaces;
                }

                return interfaces;
            }
        }

        public bool IsStaticClass
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.IsStaticClass;
                }

                return staticClass;
            }
        }

        public int MinimizationDepth
        {
            get
            {
                // This is like InheritanceDepth but not the same. It is specific for
                // use by the minimization process.
                //
                // - For imported types this matches actual inheritance depth.
                // - When the base class is an imported type, then we also go ahead
                //   and use matches inheritance depth as well.
                // - Special case: When this type and the base type are both application
                //   types, they both have the same minimization depth. (This is done to
                //   keep inheritance depth to 0 as much as possible, since this
                //   reduces size of minimized identifiers).

                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.MinimizationDepth;
                }

                if (minimizationDepth == -1)
                {
                    if (baseClass != null)
                    {
                        if (IsApplicationType && baseClass.IsApplicationType)
                        {
                            minimizationDepth = baseClass.MinimizationDepth;
                        }
                        else
                        {
                            minimizationDepth = baseClass.MinimizationDepth + 1;
                        }
                    }
                    else
                    {
                        minimizationDepth = 0;
                    }
                }

                return minimizationDepth;
            }
        }

        public ClassSymbol PrimaryPartialClass
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass;
                }

                return this;
            }
        }

        public ConstructorSymbol StaticConstructor
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.StaticConstructor;
                }

                return staticConstructor;
            }
        }

        public int TransformationCookie
        {
            get
            {
                if (primaryPartialClass != null)
                {
                    return primaryPartialClass.TransformationCookie;
                }

                if (transformationCookie == -1 &&
                    baseClass != null)
                {
                    // If this classes members did not get transformed,
                    // return the base classes transformation cookie.
                    //
                    // The transformation cookie is accessed when transforming
                    // members of a derived class, so by then this classes
                    // members would have been transformed if they needed
                    // to be. The fact that the transformation cookie is unset
                    // implies no members on this class needed to be transformed.

                    return baseClass.TransformationCookie;
                }

                return transformationCookie;
            }
            set
            {
                if (primaryPartialClass != null)
                {
                    primaryPartialClass.TransformationCookie = value;
                }

                transformationCookie = value;
            }
        }

        public override void AddMember(MemberSymbol memberSymbol)
        {
            if (primaryPartialClass != null)
            {
                primaryPartialClass.AddMember(memberSymbol);

                return;
            }

            Debug.Assert(memberSymbol != null);

            if (memberSymbol.Type == SymbolType.Constructor)
            {
                if ((memberSymbol.Visibility & MemberVisibility.Static) == 0)
                {
                    Debug.Assert(constructor == null);
                    constructor = (ConstructorSymbol) memberSymbol;
                }
                else
                {
                    Debug.Assert(staticConstructor == null);
                    staticConstructor = (ConstructorSymbol) memberSymbol;
                }
            }
            else if (memberSymbol.Type == SymbolType.Indexer)
            {
                Debug.Assert(IsApplicationType == false || indexer == null);
                indexer = (IndexerSymbol) memberSymbol;
            }
            else
            {
                base.AddMember(memberSymbol);
            }
        }

        public override TypeSymbol GetBaseType()
        {
            if (primaryPartialClass != null)
            {
                return primaryPartialClass.GetBaseType();
            }

            return baseClass;
        }

        public IndexerSymbol GetIndexer()
        {
            if (primaryPartialClass != null)
            {
                return primaryPartialClass.GetIndexer();
            }

            ClassSymbol classSymbol = this;
            IndexerSymbol indexer = classSymbol.Indexer;

            while (indexer == null)
            {
                classSymbol = (ClassSymbol) classSymbol.GetBaseType();

                if (classSymbol == null)
                {
                    break;
                }

                indexer = classSymbol.Indexer;
            }

            return indexer;
        }

        public override MemberSymbol GetMember(string name)
        {
            if (primaryPartialClass != null)
            {
                return primaryPartialClass.GetMember(name);
            }

            return base.GetMember(name);
        }

        public void SetInheritance(ClassSymbol baseClass, ICollection<InterfaceSymbol> interfaces)
        {
            // Inheritance should only be assigned to a primary partial class.
            Debug.Assert(primaryPartialClass == null);

            this.baseClass = baseClass;
            this.interfaces = interfaces;
        }

        public void SetPrimaryPartialClass(ClassSymbol primaryPartialClass)
        {
            Debug.Assert(this.primaryPartialClass == null);
            Debug.Assert(primaryPartialClass != null);

            this.primaryPartialClass = primaryPartialClass;
        }

        public void SetStaticClass()
        {
            if (primaryPartialClass != null)
            {
                primaryPartialClass.SetStaticClass();

                return;
            }

            staticClass = true;
        }
    }
}
