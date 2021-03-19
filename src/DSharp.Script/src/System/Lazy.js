function Lazy(factory)
{
    this.factory = factory;
    this.isValueCreated = false;
    this.value = undefined;
}

var Lazy$ = {
    $get_IsValueCreated: function () {
        return this.isValueCreated;
    },
    $get_Value: function () {
        if (!this.isValueCreated) {
            this.value = this.factory();
            this.isValueCreated = true;
        }
        return this.value;
    }
}