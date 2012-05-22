///////////////////////////////////////////////////////////////////////////////
// IEnumerable

ss.IEnumerable = function#? DEBUG IEnumerable$##() { };
#if DEBUG
ss.IEnumerable.prototype = {
    getEnumerator: null
}
#endif // DEBUG
ss.IEnumerable.registerInterface('IEnumerable');
