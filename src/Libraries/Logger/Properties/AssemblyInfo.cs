// AssemblyInfo.cs
//

using System;
using System.Reflection;
using System.Runtime.CompilerServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Logger")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Logger")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: ScriptAssembly("Logger")]

// A script template providing an AMD pattern-based structure around
// the generated script.
[assembly: ScriptTemplate(@"
/*! {name}.js {version}
 * {description}
 */

""use strict"";

define('{name}', [{requires}], function({dependencies}) {
  var $global = this;

  {script}
  return $exports;
});
")]
