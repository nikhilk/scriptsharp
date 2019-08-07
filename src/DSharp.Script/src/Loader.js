"use strict";

(function (global) {
  function _ss() {
    {{body}}

    return extend(module('ss', null, {
        IDisposable: defineInterface(IDisposable),
        IEnumerable: defineInterface(IEnumerable),
        IEnumerator: defineInterface(IEnumerator),
        EventArgs: defineClass(EventArgs, {}, [], null),
        CancelEventArgs: defineClass(CancelEventArgs, {}, [], null),
        StringBuilder: defineClass(StringBuilder, StringBuilder$, [], null),
        Stack: defineClass(Stack, Stack$, [], null),
        Queue: defineClass(Queue, Queue$, [], null),
        Guid: defineClass(Guid, Guid$, [], null),
        DateTime: defineClass(DateTime, {}, [], null)
    }), {
            version: {{version}},
            isValue: isValue,
            value: value,
            extend: extend,
            keys: keys,
            keyCount: keyCount,
            keyExists: keyExists,
            clearKeys: clearKeys,
            enumerate: enumerate,
            array: toArray,
            remove: removeItem,
            boolean: parseBoolean,
            regexp: parseRegExp,
            number: parseNumber,
            date: parseDate,
            truncate: truncate,
            now: now,
            today: today,
            compareDates: compareDates,
            error: error,
            string: string,
            emptyString: emptyString,
            whitespace: whitespace,
            format: format,
            compareStrings: compareStrings,
            startsWith: startsWith,
            endsWith: endsWith,
            padLeft: padLeft,
            padRight: padRight,
            trim: trim,
            trimStart: trimStart,
            trimEnd: trimEnd,
            insertString: insertString,
            removeString: removeString,
            replaceString: replaceString,
            bind: bind,
            bindAdd: bindAdd,
            bindSub: bindSub,
            bindExport: bindExport,
            paramsGenerator: paramsGenerator,
            createPropertyGet: createPropertyGet,
            createPropertySet: createPropertySet,

            module: module,
            modules: _modules,

            isClass: isClass,
            isInterface: isInterface,
            typeOf: typeOf,
            type: type,
            typeName: typeName,
            canCast: canCast,
            safeCast: safeCast,
            canAssign: canAssign,
            instanceOf: instanceOf,
            baseProperty: baseProperty,
            defineClass: defineClass,
            defineInterface: defineInterface,
            getConstructorParams: getConstructorParams,
            createInstance: paramsGenerator(1, createInstance),

            culture: {
                neutral: neutralCulture,
                current: currentCulture
            },

            fail: fail,

            contains: contains,
            insert: insert,
            clear: clear,
            addRange: addRange,
            getItem: getItem,
            setItem: setItem,
            removeAt: removeAt,
            removeItem: removeItem
        });
  }


  function _export() {
    var ss = _ss();
    typeof exports == 'object' ? ss.extend(exports, ss) : global.ss = ss;
  }

  global.define ? global.define('ss', [], _ss) : _export();
})(this);