function Shell() {
    try {
        return new ActiveXObject('WScript.Shell');
    }
    catch (ex) {
    }
    return null;
}
