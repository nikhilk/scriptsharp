function FileSystemObject() {
    try {
        return new ActiveXObject('Scripting.FileSystemObject');
    }
    catch (ex) {
    }
    return null;
}
