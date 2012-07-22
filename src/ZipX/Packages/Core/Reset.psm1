function Reset-Project($msbuild) {
  $imports = $msbuild.Xml.Imports

  if ($imports.Count -gt 0) {
    foreach ($import in $imports) {
      if ($import.Project.IndexOf("ScriptSharp.targets") -gt 0) {
        $msbuild.Xml.RemoveChild($import)
      }
    }
  }
}
