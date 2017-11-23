function Assembly(assemblyName, exportedTypes) {
    this._assemblyName = assemblyName;

    createPropertyGet(this, "ExportedTypes", function () {
        return exportedTypes;
    });
    createPropertyGet(this, "FullName", function () {
        return this._assemblyName.toString();
    });
}


var Assembly$ = {
    getName: function () {
        return this._assemblyName;
    }
};

function AssemblyName(name, version) {
    this._version = version || {};
    this._name = name || "";

    createPropertyGet(this, 'Version', function () {
        return this._version;
    });
    createPropertySet(this, 'Version', function (value) {
        return this._version = value;
    });
    createPropertyGet(this, 'Name', function () {
        return this._name;
    });
    createPropertySet(this, 'Name', function (value) {
        return this._name = value;
    });
}
var AssemblyName$ = {
    toString: function () {
        var name = this.Name;

        if (!this._version) {
            return "[" + name + "]";
        }

        return "[" + name + ", Version=" + this._version.toString() + "]";
    }
};

function Version(major, minor, build, revision) {
    major = assignDefault(major, 0);
    minor = assignDefault(minor, 0);
    build = assignDefault(build, -1);
    revision = assignDefault(revision, -1);

    createPropertyGet(this, "Major", function () {
        return major;
    });
    createPropertyGet(this, "Minor", function () {
        return minor;
    });
    createPropertyGet(this, "Build", function () {
        return build;
    });
    createPropertyGet(this, "Revision", function () {
        return revision;
    });

    function assignDefault(value, defaultValue) {
        if (!value || isNaN(value)) {
            return defaultValue;
        }

        return value;
    }
}
var Version$ = {
    toString: function () {
        var version = this.Major + "." + this.Minor;
        if (this.Build >= 0) {
            version += "." + this.Build;
        }
        if (this.Revision >= 0) {
            version += "." + this.Revision;
        }

        return version;
    }
}

Version.Parse = function (versionString) {
    var components = versionString.split(".");

    var major = parseInt(components[0]);
    var minor = parseInt(components[1]);
    var build = parseInt(components[2]);
    var revision = parseInt(components[3]);

    return new Version(major, minor, build, revision);
}