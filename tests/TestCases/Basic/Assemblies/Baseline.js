"use strict";

define('test', ['ss'], function(ss) {
  var $global = this;

  // BasicTests.App

  function App() {
    var objectType = Object;
    var fullname = objectType.$fullName;
    var nameSpace = objectType.$namespace;
    var assembly = objectType.$assembly;
    var assemblyFullName = assembly.FullName;
    var exportedTypes = assembly.ExportedTypes;
    var assemblyName = assembly.getName();
    var assemblyNameName = assemblyName.Name;
    var assemblyVersion = assemblyName.Version;
    var major = assemblyVersion.Major;
    var minor = assemblyVersion.Minor;
    var build = assemblyVersion.Build;
    var revision = assemblyVersion.Revision;
  }
  var App$ = {

  };


  var ns_BasicTests = "BasicTests";

  var $exports = ss.module('test', '', null,
    {
      App: ss.defineClass(App, App$, [], null, [], ns_BasicTests)
    });


  return $exports;
});
