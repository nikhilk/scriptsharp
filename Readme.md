# Script# Project #

Script# is a development tool that generates JavaScript by compiling C# source code. It is especially interesting for scripting-in-the-large scenarios that is commonplace in the current generation of HTML5, node.js and script-based Web applications.

The driving principle behind Script# is that JavaScript is the "assembly language of the Web" ... the idea isn't to dislike JavaScript, but rather appreciate it for its flexibility and ubiquity, while bringing the productivity and familiarity of C# when building large scale (large codebase, large team or project over a longer period) application where stronger tools, more maintainable codebases are of utmost importance. You might have heard of this described as "application scale".

Specifically, Script# lets you leverage the experience of C# (intellisense, build-time error checking, natural language syntax for OOP constructs), the power Visual Studio IDE and standard .NET tools ecosystem (such as msbuild, refactoring, unit testing, static analysis, code visualization, fxcop). Script# brings all this to you without abstracting the runtime environment - you're still authoring plain-old JavaScript and incorporating the best practices and idioms of JavaScript, just with a different set of tools.

You can even use Script# to work against other existing frameworks and APIs such as jQuery, jQuery plugins and Knockout, and can be extended to work against other existing script.

Script# requires .NET 4.0 and Visual Studio 2012. You can also use one of the free Express tools instead such as [Visual Studio 2012 Express for Web](http://www.microsoft.com/visualstudio/eng/downloads#d-express-web) or [Visual Studio 2012 Express for Windows Desktop](http://www.microsoft.com/visualstudio/eng/downloads#d-express-windows-desktop).

## More Information ##
The following set of links are relevant if you're using Script# and want to learn more or ask questions, or stay up-to-date.

* [Script# Project page](http://scriptsharp.com)
* [Latest released build](http://bit.ly/ssrelease) (packaged as a Visual Studio extension containing Script# project and item templates)
* [Issues, suggestions](https://github.com/nikhilk/scriptsharp/issues) here on GitHub. Also, check this out to participate in future design questions, calls for feedback, etc.
* For general discussion and Q&A, use [StackOverflow](http://stackoverflow.com/questions/tagged/scriptsharp)
* Follow [@scriptsharp](http://twitter.com/scriptsharp) and [@nikhilk](http://twitter.com/nikhilk) on twitter to keep up with updates and announcements.

The [Script# Wiki](https://github.com/nikhilk/scriptsharp/wiki/Wiki) contains the following bits of information if you're checking out the repository, are interested in creating a private build, or even better, looking to contribute to the project.

* [Repository Contents](https://github.com/nikhilk/scriptsharp/wiki/Repository)
* [Status](https://github.com/nikhilk/scriptsharp/wiki/Status), including roadmap and some thoughts about areas of contribution
* [Building, installing and testing](https://github.com/nikhilk/scriptsharp/wiki/Building,-Installing-and-Testing) the sources, and information on using private as well as incremental pre-release builds
* [Coding guidelines](https://github.com/nikhilk/scriptsharp/wiki/Coding-Guidelines)
* [Release notes](https://github.com/nikhilk/scriptsharp/wiki/Release-Notes) for a changelog and any version to version migration details.

### Credits ###

Script# builds on the excellent Mono.Cecil project. Thanks to Jb Evain.

Thanks to [all the contributors](https://github.com/nikhilk/scriptsharp/graphs/contributors) who have contributed to Script# over time. Your contributions are welcome, and appreciated. Let me know how you can help - whether its in the form of a feature, a sample, or some evangelizing/spreading the word, or via a suggestion. See the [status page](https://github.com/nikhilk/scriptsharp/wiki/Status) in the wiki for roadmap, plans, and some thoughts about possible contributions.

### License ###
Copyright (c) 2012, Script# Project.
Script# is licensed under the Apache 2.0 License.
