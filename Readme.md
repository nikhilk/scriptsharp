# DSharp Project #

DSharp is a development tool that generates JavaScript by compiling C# source code. It is especially interesting for scripting-in-the-large scenarios that is commonplace in the current generation of HTML5, node.js and script-based Web applications.

The driving principle behind DSharp is that JavaScript is the "assembly language of the Web" ... the idea isn't to dislike JavaScript, but rather appreciate it for its flexibility and ubiquity, while bringing the productivity and familiarity of C# when building large scale (large codebase, large team or project over a longer period) application where stronger tools, more maintainable codebases are of utmost importance. You might have heard of this described as "application scale".

Specifically, DSharp lets you leverage the experience of C# (intellisense, build-time error checking, natural language syntax for OOP constructs), the power Visual Studio IDE and standard .NET tools ecosystem (such as msbuild, refactoring, unit testing, static analysis, code visualization, fxcop). Script# brings all this to you without abstracting the runtime environment - you're still authoring plain-old JavaScript and incorporating the best practices and idioms of JavaScript, just with a different set of tools.

You can even use DSharp to work against other existing frameworks and APIs such as jQuery, jQuery plugins and Knockout, and can be extended to work against other existing script.

DSharp requires .NET 4.0 and Visual Studio 2012.

### Credits ###

DSharp is a fork of the excellent Script#  project.

### License ###
Copyright (c) 2015, DSharp Project.
DSharp is licensed under the Apache 2.0 License.