// AssemblyInfo.cs
//

using System;
using System.Reflection;
using System.Runtime.CompilerServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Cellar")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Cellar Sample for Script#")]
[assembly: AssemblyCopyright("Copyright © 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: ScriptAssembly("cellar")]
[assembly: ScriptReference("knockout", Path="knockout-2.1.0")]

// A script template using an AMD pattern for declaring dependencies consumed
// by the generated script.
[assembly: ScriptTemplate(@"
/*! {name}.js {version}
 * {description}
 */

""use strict"";

require([{requires}], function({dependencies}) {
  var $global = this;

  {script}
});
")]
