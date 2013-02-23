// AssemblyInfo.cs
//

using System;
using System.Reflection;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("WebREPL")]
[assembly: AssemblyDescription("WebREPL Sample for Script#")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("WebREPL")]
[assembly: AssemblyCopyright("Copyright © 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: ScriptAssembly("WebREPL")]

// A script template allows customization of the generated script.
[assembly: ScriptTemplate(@"
// {name}.js {version}

{dependenciesLookup}
var $global = this;

{script}
")]
