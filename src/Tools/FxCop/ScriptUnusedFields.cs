// ScriptInvalidSelector.cs
// Script#/Tools/FxCop
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using Microsoft.FxCop.Sdk;

namespace ScriptSharp.FxCop {

    public sealed class ScriptUnusedFields : BaseIntrospectionRule {

        private TypeNode _importedAttributeType;
        private TypeNode _recordType;

        public ScriptUnusedFields() :
            base(typeof(ScriptUnusedFields).Name,
                 typeof(ScriptUnusedFields).Namespace + ".RuleData",
                 typeof(ScriptUnusedFields).Assembly) {
        }

        public override TargetVisibilities TargetVisibility {
            get {
                return (TargetVisibilities.Overridable | TargetVisibilities.ExternallyVisible);
            }
        }

        public override void BeforeAnalysis() {
            base.BeforeAnalysis();

            _importedAttributeType =
                FrameworkAssemblies.Mscorlib.GetType(Identifier.For("System.Runtime.CompilerServices"),
                                                     Identifier.For("ImportedAttribute"));
            _recordType =
                FrameworkAssemblies.Mscorlib.GetType(Identifier.For("System"),
                                                     Identifier.For("Record"));
        }

        public override ProblemCollection Check(Member member) {
            if (!(member is Field) || member.IsStatic || member.IsPrivate) {
                return null;
            }

            // If the declaring type has [Imported] applied, we have no choice but to allow the field to exist
            if (RuleUtilities.HasCustomAttribute(member.DeclaringType, _importedAttributeType)) {
                return null;
            }

            // If the type derives from Record, allow the field to exist
            if (member.DeclaringType.BaseType == _recordType) {
                return null;
            }

            Problems.Add(new Problem(base.GetResolution(new object[] { member })));
            return Problems;
        }
    }
}
