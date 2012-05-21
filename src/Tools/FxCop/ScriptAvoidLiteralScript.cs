// ScriptAvoidLiteralScript.cs
// Script#/Tools/FxCop
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using Microsoft.FxCop.Sdk;

namespace ScriptSharp.FxCop {

    public sealed class ScriptAvoidLiteralScript : BaseIntrospectionRule {

        public ScriptAvoidLiteralScript() :
            base(typeof(ScriptAvoidLiteralScript).Name,
                 typeof(ScriptAvoidLiteralScript).Namespace + ".RuleData",
                 typeof(ScriptAvoidLiteralScript).Assembly) {
        }

        public override ProblemCollection Check(Member member) {
            Visit(member);
            return Problems;
        }

        public override void VisitMethodCall(MethodCall call) {
            Method method = ((MemberBinding)call.Callee).BoundMember as Method;

            if ((method != null) &&
                (method.DeclaringType.FullName == "System.Script") &&
                (method.Name.Name == "Literal")) {
                Problems.Add(new Problem(GetResolution(), call.SourceContext));
            }
        }
    }
}
