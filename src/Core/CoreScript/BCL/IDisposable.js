///////////////////////////////////////////////////////////////////////////////
// IDisposable

ss.IDisposable = function#? DEBUG IDisposable$##() { };
#if DEBUG
ss.IDisposable.prototype = {
    dispose: null
}
#endif // DEBUG
ss.IDisposable.registerInterface('IDisposable');
