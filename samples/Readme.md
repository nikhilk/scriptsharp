# Getting Started

The following solution hosts a simple Todo application which presents a simple and basic application using DSharp with a loader.

## Running / Demo

Currently you need to manually load the libraries in order due to no bootstrapping

## Testing between builds

When you build an SDK Against a specific version you need to run the `./resetNugetSdkCache.ps1` to ensure when restoring the packages in the solution gets the latest versions - This only happens because the SDK version doesn't change between builds.  

## Work left

Due to the current version of DSharp being a stripped out version it no longer has a sample application project.
This needs to be added into DSharp so we can bootstrap simple applications and load all scripts without an issues.

- Create new bootstrapping JS which loads modules and their dependencies
- Update template to use this
- Create new project templates which allow you to make new modules, new applications and styles.