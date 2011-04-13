function FeedsManager() {
    try {
        return new ActiveXObject('Microsoft.FeedsManager');
    }
    catch (ex) {
    }
    return null;
}
