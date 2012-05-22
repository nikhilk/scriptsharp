///////////////////////////////////////////////////////////////////////////////
// Array Extensions

Array.__typeName = 'Array';
Array.__interfaces = [ ss.IEnumerable ];

Array.prototype.add = function#? DEBUG Array$add##(item) {
    this[this.length] = item;
}

Array.prototype.addRange = function#? DEBUG Array$addRange##(items) {
    this.push.apply(this, items);
}

Array.prototype.aggregate = function#? DEBUG Array$aggregate##(seed, callback, instance) {
    var length = this.length;
    for (var i = 0; i < length; i++) {
        if (i in this) {
            seed = callback.call(instance, seed, this[i], i, this);
        }
    }
    return seed;
}

Array.prototype.clear = function#? DEBUG Array$clear##() {
    this.length = 0;
}

Array.prototype.clone = function#? DEBUG Array$clone##() {
    if (this.length === 1) {
        return [this[0]];
    }
    else {
        return Array.apply(null, this);
    }
}

Array.prototype.contains = function#? DEBUG Array$contains##(item) {
    var index = this.indexOf(item);
    return (index >= 0);
}

Array.prototype.dequeue = function#? DEBUG Array$dequeue##() {
    return this.shift();
}

Array.prototype.enqueue = function#? DEBUG Array$enqueue##(item) {
    // We record that this array instance is a queue, so we
    // can implement the right behavior in the peek method.
    this._queue = true;
    this.push(item);
}

Array.prototype.peek = function#? DEBUG Array$peek##() {
    if (this.length) {
        var index = this._queue ? 0 : this.length - 1;
        return this[index];
    }
    return null;
}

if (!Array.prototype.every) {
    Array.prototype.every = function#? DEBUG Array$every##(callback, instance) {
        var length = this.length;
        for (var i = 0; i < length; i++) {
            if (i in this && !callback.call(instance, this[i], i, this)) {
                return false;
            }
        }
        return true;
    }
}

Array.prototype.extract = function#? DEBUG Array$extract##(index, count) {
    if (!count) {
        return this.slice(index);
    }
    return this.slice(index, index + count);
}

if (!Array.prototype.filter) {
    Array.prototype.filter = function#? DEBUG Array$filter##(callback, instance) {
        var length = this.length;    
        var filtered = [];
        for (var i = 0; i < length; i++) {
            if (i in this) {
                var val = this[i];
                if (callback.call(instance, val, i, this)) {
                    filtered.push(val);
                }
            }
        }
        return filtered;
    }
}

if (!Array.prototype.forEach) {
    Array.prototype.forEach = function#? DEBUG Array$forEach##(callback, instance) {
        var length = this.length;
        for (var i = 0; i < length; i++) {
            if (i in this) {
                callback.call(instance, this[i], i, this);
            }
        }
    }
}

Array.prototype.getEnumerator = function#? DEBUG Array$getEnumerator##() {
    return new ss.ArrayEnumerator(this);
}

Array.prototype.groupBy = function#? DEBUG Array$groupBy##(callback, instance) {
    var length = this.length;
    var groups = [];
    var keys = {};
    for (var i = 0; i < length; i++) {
        if (i in this) {
            var key = callback.call(instance, this[i], i);
            if (String.isNullOrEmpty(key)) {
                continue;
            }
            var items = keys[key];
            if (!items) {
                items = [];
                items.key = key;

                keys[key] = items;
                groups.add(items);
            }
            items.add(this[i]);
        }
    }
    return groups;
}

Array.prototype.index = function#? DEBUG Array$index##(callback, instance) {
    var length = this.length;
    var items = {};
    for (var i = 0; i < length; i++) {
        if (i in this) {
            var key = callback.call(instance, this[i], i);
            if (String.isNullOrEmpty(key)) {
                continue;
            }
            items[key] = this[i];
        }
    }
    return items;
}

if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function#? DEBUG Array$indexOf##(item, startIndex) {
        startIndex = startIndex || 0;
        var length = this.length;
        if (length) {
            for (var index = startIndex; index < length; index++) {
                if (this[index] === item) {
                    return index;
                }
            }
        }
        return -1;
    }
}

Array.prototype.insert = function#? DEBUG Array$insert##(index, item) {
    this.splice(index, 0, item);
}

Array.prototype.insertRange = function#? DEBUG Array$insertRange##(index, items) {
    if (index === 0) {
        this.unshift.apply(this, items);
    }
    else {
        for (var i = 0; i < items.length; i++) {
            this.splice(index + i, 0, items[i]);
        }
    }
}

if (!Array.prototype.map) {
    Array.prototype.map = function#? DEBUG Array$map##(callback, instance) {
        var length = this.length;
        var mapped = new Array(length);
        for (var i = 0; i < length; i++) {
            if (i in this) {
                mapped[i] = callback.call(instance, this[i], i, this);
            }
        }
        return mapped;
    }
}

Array.parse = function#? DEBUG Array$parse##(s) {
    return eval('(' + s + ')');
}

Array.prototype.remove = function#? DEBUG Array$remove##(item) {
    var index = this.indexOf(item);
    if (index >= 0) {
        this.splice(index, 1);
        return true;
    }
    return false;
}

Array.prototype.removeAt = function#? DEBUG Array$removeAt##(index) {
    this.splice(index, 1);
}

Array.prototype.removeRange = function#? DEBUG Array$removeRange##(index, count) {
    return this.splice(index, count);
}

if (!Array.prototype.some) {
    Array.prototype.some = function#? DEBUG Array$some##(callback, instance) {
        var length = this.length;
        for (var i = 0; i < length; i++) {
            if (i in this && callback.call(instance, this[i], i, this)) {
                return true;
            }
        }
        return false;
    }
}

Array.toArray = function#? DEBUG Array$toArray##(obj) {
    return Array.prototype.slice.call(obj);
}
