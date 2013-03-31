/*! Script# Loader
 * Designed and licensed for use and distribution with Script#-generated scripts.
 * Copyright (c) 2012, Nikhil Kothari, and the Script# Project.
 * More information at http://scriptsharp.com
 */

"use strict";
(function(global) {
  // Helpers

  function each(items, action) {
    var results = [];
    if (items) {
      for (var i = 0, len = items.length; i < len; i++) {
        results.push(action(items[i], i));
      }
    }
    return results;
  }

  // Script management
  // Each script has a name, and an associated url or script text.
  // Scripts can be registered in advance using script tags on the page,
  // either with a url:
  // <script type="text/script" data-name="..." data-src="..."></script>
  // or with text:
  // <script type="text/script" data-name="...">...</script>
  // The use of text/script ensures the script does not run immediately.
  //
  // If a script has not been explicitly registered, a url can be created
  // using a convention. The current convention is simply:
  // /scripts/<scriptname>.js.
  //
  // Script registration provides additional capabilities:
  // Auto-loading:  If data-autoload is set to true, then the script is
  //                automatically loaded on startup.
  // Pre-loading:   If data-preload="true" is set, then after all startup
  //                scripts have been loaded, any preloadable scripts are
  //                loaded (but not executed).
  //                Pre-loading is only supported on scripts from the same
  //                domain.
  // Local storage: If data-store is set on a script with inline text with
  //                the version of the script, it is saved to local storage.
  //                A scripts cookie is updated to indicate the client has
  //                a copy of the script, allowing the server to generate
  //                a script tag with data-store set to 'load'. This allows
  //                inlining the script on the first request which saves
  //                roundtrips, and not paying the price of inlining on
  //                subsequent requests.
  //
  // Scripts not following the AMD patten can be shimmed by explicitly
  // specifying the exported object using data-export. Optionally dependencies
  // can be specified as well, using the data-requires attribute.
  //
  // TODO: Provide ability to plug in other types of loaders (like for css
  //       and templates).

  var _xdomainRegex = /^https?:\/\/.*/;

  var _scripts = {};
  var _startupScripts = [];
  var _deferredScripts = [];
  function _getScript(name) {
    var script = _scripts[name];
    if (!script) {
      // Create a script object with a url based on convention
      script = _scripts[name] = {
        name: name, amd: true,
        src: define.config.scriptPath.replace('{name}', name)
      };
    }
    return script;
  }
  function _loadScriptConfiguration() {
    var scriptElements = document.getElementsByTagName('script');
    for (var i = 0, count = scriptElements.length; i < count; i++) {
      var scriptElement = scriptElements[i];
      if (scriptElement.type == 'text/script') {
        var name = scriptElement.getAttribute('data-name');
        var inline = false;
        if (!name) {
          // If there was no name set, assume this script has inline text,
          // generate a name, so it can be managed, and include it as a
          // startup script that is auto-loaded.

          name = 's' + (new Date()).valueOf();
          inline = true;
        }

        var script = _scripts[name] = {
          name: name,
          amd: true,
          src: scriptElement.getAttribute('data-src')
        };

        if (!script.src) {
          // No src was specified, so use script text instead.
          var text;

          var storage = define.config.localStore ? scriptElement.getAttribute('data-store') : null;
          if (storage == 'load') {
            // Storage was set to load, so load script text from local storage.
            text = _loadLocalScript(name);
          }
          else {
            // Use the inlined script text.
            text = scriptElement.text;
            if (storage) {
              // Storage was specified, so save the text to local storage for use
              // on a subsequent page load, and use the value of the storage attribute
              // as the version marker to communicate to the server that we
              // have a particular script in storage.

              _saveLocalScript(name, text, storage);
            }
          }

          if (inline) {
            // Assumption is if the name wasn't specified on the script tag, then
            // it wasn't specified in the define call either. Patch up the script
            // text to use the auto-generated module name for the module name
            // specified in the call to define (so that the callbacks associated
            // with this module get invoked when the script executes).

            text = text.replace('define([', 'define(\'' + script.name + '\', [');
          }
          script.text = text;
          script.useText = true;
        }
        else {
          var exp = scriptElement.getAttribute('data-export');
          if (exp) {
            script.amd = false;
            script.exp = exp;

            var requires = scriptElement.getAttribute('data-requires');
            if (requires) {
              script.requires = requires.split(',');
            }
          }
        }

        if (inline || scriptElement.hasAttribute('data-autoload')) {
          _startupScripts.push(script.name);
        }
        if (!_xdomainRegex.test(script.src) && scriptElement.hasAttribute('data-preload')) {
          _deferredScripts.push(script.name);
        }
      }
    }
  }

  // Local storage
  // Scripts are stored in local storage with a key = script.<name of script>.
  // Additionally a script.$ key is stored containing the versions of all scripts
  // that have been saved to storage. This is also set as the cookie value, so
  // a server can detect which scripts exist on the client.
  function _loadLocalScript(name) {
    return localStorage['script.' + name];
  }
  function _saveLocalScript(name, text, version) {
    localStorage['script.' + name] = text;

    // Save the fact that we have stored this script into the local storage
    // by updating the index with the new script information, and using
    // the index as the value of the cookie sent to the server as well.
    var scriptIndex = localStorage['script.$'];

    scriptIndex = scriptIndex ? JSON.parse(scriptIndex) : {};
    scriptIndex[name] = version;

    scriptIndex = JSON.stringify(scriptIndex);
    localStorage['script.$'] = scriptIndex;

    // A cookie with 180 days = 60 * 60 * 24 * 180 seconds
    document.cookie = define.config.cookie + '=' + encodeURIComponent(scriptIndex) +
                      '; max-age=15552000; path=/';
  }
  function _downloadScript(name) {
    var script = _scripts[name];

    var downloader = new XMLHttpRequest();
    downloader.onreadystatechange = function() {
      if (downloader.readyState == 4) {
        downloader.onreadystatechange = null;

        if (downloader.status == 200) {
          script.useText = true;
          script.text = downloader.responseText;
        }
      }
    };
    downloader.open('GET', script.src, true);
    downloader.send();
  }


  // Script loading
  // Scripts are loaded by creating script elements and inserting
  // into the document's head element.
  // Scripts can either be loaded from a url (using the src attribute)
  // or loaded from previously loaded script text (using the text property).
  //
  // The assumption is the script uses the AMD pattern, so doesn't need
  // to be tracked - the call to define will indicate the script has been
  // loaded and executed.
  //
  // TODO: Provide ability to plug in a shim for scripts that don't follow
  //       the AMD pattern.

  var _head = document.getElementsByTagName('head')[0];
  function _loadScript(scriptName) {
    var script = _getScript(scriptName);
    if (script.amd) {
      // We don't listen to load events, since the expectation is an AMD
      // compatible script will call into define(). Consequently, we require
      // define() calls to include the leading module identifier to
      // know which module was just loaded.

      var scriptElement = document.createElement('script');
      scriptElement.type = 'text/javascript';
      if (script.useText) {
        scriptElement.text = script.text;
      }
      else {
        scriptElement.src = script.src;
      }

      _head.appendChild(scriptElement);
    }
    else {
      script.requires ?
        require(script.requires, function() { _loadNonAMDScript(script); }) :
        _loadNonAMDScript(script);
    }
  }

  function _loadNonAMDScript(script) {
    // Listen the loaded/readystatechange events to figure out when the
    // script is loaded, and when has, evaluate the export expression to
    // get a reference to the object that will be treated as the module
    // object.

    var scriptElement = document.createElement('script');
    scriptElement.type = 'text/javascript';
    scriptElement.src = script.src;

    scriptElement.onload = scriptElement.onreadystatechange = function() {
      var rs = scriptElement.readyState;
      if (rs && rs != 'complete' && rs != 'loaded') {
        return;
      }

      scriptElement.onload = scriptElement.onreadystatechange = null;
      try {
        _completeModule(script.name, eval(script.exp));
      }
      catch (e) {
      }
    }
    _head.appendChild(scriptElement);
  }


  // Module management

  var _modules = {};
  function _getModule(name) {
    return _modules[name] ||
           (_modules[name] = { name: name, exports: null, callbacks: [], loading: false });
  }
  function _loadModule(name, callback) {
    var module = _getModule(name);

    if (module.callbacks) {
      // Module hasn't loaded yet, since we're still hanging on
      // to dependents, so add this callback to the list.

      module.callbacks.push(callback);

      if (!module.loading) {
        // Kick off loading the module if this is the first dependent.
        module.loading = true;
        _loadScript(name);
      }

      return 0;
    }

    // Module is already loaded, so invoke the callback but use a
    // setTimeout to mimic how the callback is invoked asynchronously
    // in the usual case when the module hasn't already been loaded.
    return setTimeout(callback, 0);
  }
  function _completeModule(name, exports) {
    var module = _modules[name];

    var callbacks = module.callbacks;
    module.callbacks = null;

    module.exports = exports;
    module.loading = false;

    each(callbacks, function(callback) {
      callback();
    });
  }


  // Exported APIs
  // As per the AMD pattern, we're exporting require and define.
  // Our version of define only works with explicitly specified
  // module names (which is anyway true if individual modules are
  // combined into a single script on the server).

  function require(dependencyNames, callback) {
    dependencyNames = dependencyNames || [];

    var dependencyCount = dependencyNames.length;
    if (dependencyCount == 0) {
      // No dependencies, so go ahead and invoke the callback
      // immediately, but do so in an async way to mimic how
      // it would have been invoked if there were dependencies.
      setTimeout(callback, 0);
      return;
    }

    var dependenciesAvailable = 0;
    var localCallback = function() {
      dependenciesAvailable++;
      if (dependenciesAvailable == dependencyCount) {
        var dependencies = each(dependencyNames, function(dependencyName) {
          return _getModule(dependencyName).exports;
        });

        callback.apply(global, dependencies);
      }
    };

    each(dependencyNames, function(dependencyName) {
      _loadModule(dependencyName, localCallback);
    });
  }

  function define(name, dependencyNames, callback) {
    var m = _getModule(name);
    if (!m.callbacks) {
      // Looks like a module is being reloaded... for now, just
      // ignore, i.e. don't execute the script. This is because we already
      // have an object representing this module that might have been handed
      // out as a depedency to other modules.
      return;
    }
    m.loading = true;
    require(dependencyNames, function() {
      _completeModule(name, callback.apply(global, arguments));
    });
  }

  // Enable using this loader to load jQuery (1.7+) as well.
  define.amd = { jQuery: true };

  // Customizable configuration
  define.config = {
    scriptPath: '/scripts/{name}.js',
    cookie: 'scripts',
    localStore: !!global.localStorage
  };

  // Export define and require as API additions on the global object
  global.require = require;
  global.define = define;

  // Bootstrapping
  // If the document has already loaded (i.e. when this script was
  // dynamically added to the DOM), go ahead and run startup immediately.
  // Otherwise hookup to the DOMContentLoaded event on the document
  // which is when the DOM is ready for programmatic access, or if
  // this is an older browser, simply do the next best thing - wait for
  // the page to be loaded completely.

  function _startup() {
    _loadScriptConfiguration();
    require(_startupScripts, function(startupObjects) {
      each(_deferredScripts, function(name) {
        _downloadScript(name);
      });
    });
  }

  if (document.addEventListener) {
    var rs = document.readyState;
    rs == 'complete' || rs == 'interactive' ?
      setTimeout(_startup, 0) :
      document.addEventListener('DOMContentLoaded', _startup, false);
  }
  else if (global.attachEvent) {
    global.attachEvent('onload', function() {
      _startup();
    });
  }
})(window);
