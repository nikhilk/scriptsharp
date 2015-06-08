﻿// AssemblyInfo.cs
//

using System;
using System.Reflection;
using System.Runtime.CompilerServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Todo")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Script# Samples")]
[assembly: AssemblyCopyright("Copyright © 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: ScriptAssembly("Todo")]
[assembly: ScriptTemplate(@"
/*! {name}.js
 *  Todo Sample Application
 */

'use strict';
define('{name}', [{requires}], function({dependencies}) {
  var $global = this;

  {script}
});

/*! Generated with Script# */
")]
