function Lazy(factory)
{
    this.factory = factory;
    this.isValueCreated = false;
    this.value = undefined;
}

createPropertyGet(Lazy.prototype, 'IsValueCreated', function () {
    return this.isValueCreated;
});

createPropertyGet(Lazy.prototype, 'Value', function () {
    if (!this.isValueCreated) {
        this.value = this.factory();
        this.isValueCreated = true;
    }
    return this.value;
});
