// AssemblyInfo.cs
// Script#/FX/Sharpen/Core
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle("Sharpen")]
[assembly: AssemblyDescription("Sharpen Framework for HTML5 Single Page Apps")]
[assembly: AssemblyConfiguration("http://www.scriptsharp.com")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Script# Sharpen Framework")]
[assembly: AssemblyCopyright("Copyright © 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: ScriptAssembly("sharpen")]

[assembly: ScriptTemplate(@"
/*! {name}.js {version}
 * {description}
 */

""use strict"";

define('{name}', [{requires}], function({dependencies}) {
  var $global = this;

  {script}

{include:Properties\TemplateEngine.js}

  return $exports;
});
")]
