///////////////////////////////////////////////////////////////////////////////
// CancelEventArgs

ss.CancelEventArgs = function#? DEBUG CancelEventArgs$##() {
    ss.CancelEventArgs.initializeBase(this);
    this.cancel = false;
}
ss.CancelEventArgs.registerClass('CancelEventArgs', ss.EventArgs);
