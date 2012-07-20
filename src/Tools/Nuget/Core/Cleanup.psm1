function Cleanup-Project($doc, $namespace) {
    $nodeList = Select-Xml "//msb:Project/msb:Import[contains(@Project,'ScriptSharp.targets')]" $doc -Namespace @{msb = $namespace}
    if ($nodeList) {
        foreach ($nodeItem in $nodeList) {
            $nodeItem.Node.ParentNode.RemoveChild($nodeItem.Node)
        }
    }
}
