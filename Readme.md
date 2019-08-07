# DSharp Project #

DSharp is a development tool that generates JavaScript by compiling C# source code. It is especially interesting for scripting-in-the-large scenarios that is commonplace in the current generation of HTML5, node.js and script-based Web applications.

The driving principle behind DSharp is that JavaScript is the "assembly language of the Web" ... the idea isn't to dislike JavaScript, but rather appreciate it for its flexibility and ubiquity, while bringing the productivity and familiarity of C# when building large scale (large codebase, large team or project over a longer period) application where stronger tools, more maintainable codebases are of utmost importance. You might have heard of this described as "application scale".

Specifically, DSharp lets you leverage the experience of C# (intellisense, build-time error checking, natural language syntax for OOP constructs), the power Visual Studio IDE and standard .NET tools ecosystem (such as msbuild, refactoring, unit testing, static analysis, code visualization, fxcop). Script# brings all this to you without abstracting the runtime environment - you're still authoring plain-old JavaScript and incorporating the best practices and idioms of JavaScript, just with a different set of tools.

You can even use DSharp to work against other existing frameworks and APIs such as jQuery, jQuery plugins and Knockout, and can be extended to work against other existing script.

## Compatibility ##

The current solution `DSharp.sln` is compatible with .NET 4.0 and Visual Studio 2017 for Windows.

## Compiler Implementation ##

- ### Core

    - **Build:** Generators and Tasks for the build system

    - **Compiler:** Compiler implementation

      - Lexer: Converts source code into `Tokens`

      - Parser: Converts `Tokens` into `ParseNodes`

      - Validator: Compile-time conditions for the parser

      - Importer: Extracts the `TypeSymbols` from the assemblies (using Mono.Cecil) and generates `Metadata` for them
        > f.e: create all MethodSymbols for a declared `ClassSymbol`

      - Builder: Transforms `ParseNodes` into `Metadata`
        > f.e: create a Expression tree from a node

      - Generator: Transforms `Symbols` and `Metadata` into output (javascript)

    - **Mscorlib:** Dummy interfaces and classes that emulate the original `mscorlib.dll`. Having the same signatures of the original mscorlib enables cross-compilation.

    - **Scripts:** Javascript implementations of mscorlib. It mostly includes helper methods and class implementations. The compiler binds C# code to JS implementation by using `ScriptAttributes`.

    - **Web:** Web-specific abstractions that can be used when targeting DSharp. This is an extension library and isn't available in normal C#.

    - **Shell:** Shell utility for invoking the compiler.

- ### SDK

    - Crosscompilation for DSharp and NetStandard
    - Support for modern `csproj` syntax

- ### Tests

    - **Framework:** Implementation of the JS test framework.
    - **Compiler.Tests:** Tests for the compiler.

## Writing Tests ##

Testing the compiler is quite straightforward: define an input c# file `Code.cs` and the expected result in `Baseline.txt`. The test runner will compare the result with the expected one.

In order to create a new  you need to:

1. Create the test files `Code.cs` and `Baseline.txt` in a relevant subdirectory under the `Source` folder.
2. Add your test to `CompilerTests.json` pointing to the right files. The categories represent subdirectories inside the `Source` folder.

## Debugging ##

There are two ways of debugging the project: debugging a test or a shell that invokes the compiler.

### Prerequisites ###

- #### Enable all Common Language Runtime Exceptions
  This can be done under `Debug` -> `Windows` -> `Exception Settings (Ctrl+Alt+E)` and ticking all `Common Language Runtime Exceptions`.

### Debugging a Test ###

Debugging a test is currently non-deterministic (it works depending on the computer, and it may display some artifacts on Visual Studio) but it's worth trying. This is due to xUnit runtime confusing Visual Studio.

In order to debug a test you need to:

1. Rebuild All
2. In the test explorer, `Right Click` -> `Debug Selected Tests`

### Debugging the Shell ###

Debugging the Shell requires a bit of configuration: setting up the arguments for the invokation.

In order to debug the shell you need to:

1. Rebuild All
2. In the `Core/DSharp.Shell` project, `Right Click` -> `Properties` -> `Debug` -> `Application arguments` and set the following:

    ```console
    /ref:C:\Working\dsharp\src\DSharp.Mscorlib\bin\Debug\net461\DSharp.Mscorlib.dll
    /out:out.js
    C:\Working\dsharp\src\DSharp.Compiler.Tests\Source\Mscorlib\DateTime\Code.cs
    ```
    > update the paths to match the ones in your pc
3. F5 in debug mode

## Useful Links ##

- ### mscorlib
  Being compliant with latest implementations of `mscorlib` is extremely important for cross-compiling. These can be checked in the following links:

  - [Reference Source](https://referencesource.microsoft.com/): Official source reference from Microsoft with nice search and navigation
  - [Source Dot Net](https://source.dot.net): Unofficial source reference for .NET Core
  - [.NET Core GitHub](https://github.com/dotnet/coreclr/tree/master/src/System.Private.CoreLib): Latests previews for .NET Core
  - [.NET Standard GitHub](https://github.com/dotnet/standard)

### Credits ###

DSharp is a fork of the Script# project.

### License ###
Copyright (c) 2015, DSharp Project.
DSharp is licensed under the Apache 2.0 License.

[![Build status](https://ci.appveyor.com/api/projects/status/57jvqrtyj1v3re45/branch/master?svg=true)](https://ci.appveyor.com/project/fred-perkins/dsharp/branch/master)
