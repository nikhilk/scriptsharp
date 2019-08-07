# DSharp Sdk

DSharp.Sdk builds upon the Sdk format in msbuild to simplify the project structure and customisation of DSharp projects.

## Multi-targeting

DSharp.Sdk supports multi-targeting using the following convention:

***net framework*** builds be treated as DSharp, adding references to the dsharp custom mscorlib, invoking the transpiler and producing .js files. This is identified as any TFM beginning with net followed by 2 or 3 digits (net40, net471 etc)

all other build targets will compile as normal, with framework references pointing to netstandard or netcoreapp as usual.

## Usage

To create a new DSharp project is now as simple as updating the Sdk attribute in a standard project file.

### Example Project File

```xml

<Project Sdk="DSharp.Sdk" Version="1.2.3">
  <PropertyGroup>
    <TargetFrameworks>net40;netstandard2.0</TargetFrameworks>
  </PropertyGroup>
</Project>

```

### Versioning via global.json

Sdk versions can be specified globally using a global.json file. If you are using global.json, do not also specify a version as a project attribute.

## example

```json

{
  "msbuild-sdks": {
    "DSharp.Sdk": "1.2.3",
  }
}

```

### MsBuild Properties

The following msbuild properties can be used to customise the DSharp build:

| Property Name           | Description                                                                                                                                                                                                                                                 | Default Value                                                                                                                  | Example                                                                   |
|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------|
| MinimumFrameworkVersion | Ensures that the build targets a net framework version equal to or higher than the specified value                                                                                                                                                          | `4.0`                                                                                                                          | `<MinimumFrameworkVersion>4.0</MinimumFrameworkVersion>`                  |
| IsImportLibrary         | Specifies that the library is used for importing metadata only. Import libraries reference the custom DSharp mscorlib but do not produce any javascript. Combine with *ScriptName* if your downstream libraries require a reference to a javascript object. | `false`                                                                                                                        | `<IsImportLibrary>true</IsImportLibrary>`                                 |
| ScriptName              | Specifies the name of the generated script, both the javascript object and the output file name                                                                                                                                                             | AssemblyName with all `.` characters transformed to `_` characters [for non-import libraries] `empty` [for import libraries]   | `<ScriptName>My_Library</ScriptName>`                                     |
| ExcludeCoreLib          | Set to disable references to the DSharp custom mscorlib                                                                                                                                                                                                     | `false `                                                                                                                       | `<ExcludeCoreLib>true</ExcludeCoreLib>`                                   |
| ScriptTemplatePath      | Path to a custom DSharp module template file                                                                                                                                                                                                                | `<empty>`                                                                                                                      | `<ScriptTemplatePath>$(ProjectDir)moduletemplate.js</ScriptTemplatePath>` |

### MsBuild Items

The following MsBuild items have been defined:

| Property Name           | Description                                                                          | Custom Metadata                                                               |
|-------------------------|--------------------------------------------------------------------------------------|-------------------------------------------------------------------------------|
| PackagedScript          | Identifies a .js file which needs to be included in the output package               | Minify (true|false) - specifies whether to minify the script prior to packing |


## Implementation Details

The entrypoints to the Sdk are Sdk.props and Sdk.targets.

### Sdk.props

Sdk.props determines if the build is to be transpiled by assessing the TargetFramework property. Any TFM matching `net\d{2,3}` will be treated as a DSharp project.
the sdk uses this to determine whether to import props for dsharp or netstandard.

#### DSharp.props

DSharp.props sets default values, sets properties telling msbuild not to reference the usual mscorlib and adds a reference to the custom DSharp mscorlib.

#### Netstandard.props

### Sdk.targets

#### DSharp.targets

DSharp.targets imports targets specific to DSharp builds; it defines the following targets:

| Target                | description                                         | comments                                                   |
|-----------------------|-----------------------------------------------------|------------------------------------------------------------|
| BuildScript           | invokes the transpiler                              |                                                            |
| GenerateResourcesCode | generates resources from resx                       |                                                            |
| CopyScripts           | copies the runtime script (ss.js) to the lib folder | ss.js should be moved to the DSharp.MsCorlib nuget package |
| CleanScripts          | deletes generated scripts from the output folder    |                                                            |

#### Pack.targets

Pack.targets ensures the the nuspec file is generated correctly; it defines the following targets:

| Target               | description                                                                                                                                                                 | comments                                     |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------|
| GetTfmOutputDirs     | determines all output folders, taking TargetFramework into account | this is implemented by calling a new MSBuild per TFM, specifying _GetTfmOutputDirs as the build target |                                              |
| GetScriptOutputPath  | determines the source and destination for the generated js                                                                                                                  |                                              |
| PackPackagedScripts  | adds items to ensure that any files defined as PackagedScript are included in the output package, including a minified copy if the `<minify>` metadata is set               |                                              |
| PackScripts          | adds items to ensure that the module output script is included in the output package, including a minified copy if applicable                                               |                                              |
| _GetTfmOutputDirs    | determines the output folder for each target framework                                                                                                                      | called as an inner build by GetTfmOutputDirs |

### Multi-Targeting

Multi-targeting is enabled when projects specify 1 or more valid target framework moniker in the `<TargetFrameworks>` property.
MsBuild will start a child build specifying the target framework for each TFM specified.

### Avoiding diamond dependencies

To avoid diamond dependencies we keep track of which custom Sdks we have loaded in the `ImportedSdks` property. Any Sdks built on top of this one should add to this property (see DSharp.Web for an example).
