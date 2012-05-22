///////////////////////////////////////////////////////////////////////////////
// IEnumerator

ss.IEnumerator = function#? DEBUG IEnumerator$##() { };
#if DEBUG
ss.IEnumerator.prototype = {
    get_current: null,
    moveNext: null,
    reset: null
}
#endif // DEBUG

ss.IEnumerator.getEnumerator = function#? DEBUG ss_IEnumerator$getEnumerator##(enumerable) {
    if (enumerable) {
        return enumerable.getEnumerator ? enumerable.getEnumerator() : new ss.ArrayEnumerator(enumerable);
    }
    return null;
}

ss.IEnumerator.registerInterface('IEnumerator');
