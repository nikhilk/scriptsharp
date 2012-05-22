(function () {
  var _head = document.getElementsByTagName('head')[0];

  var _downloaderType = navigator.userAgent.indexOf('MSIE') > 0 ? 'img' : 'object';
  var _xdomainRegex = /^https?:\/\/.*/;

  // Storage cookie defaults to 'scripts', but can be overriden via a scriptCookie
  // expando on the document.
  var _storageCookie = document.scriptCookie || 'scripts';

  // Debuggable scripts defaults to false, but can be overriden via a scriptDebugging
  // flag set to true on the document object.
  var _debuggableScripts = document.scriptDebugging || false;

  // The script loader provides functionality to download scripts from the network
  // and load/save from/to local storage. A script loader can be specified on the
  // document, and if not a default implementation if used here.
  var _scriptLoader = document.scriptLoader ||
    {
      download: function (script, callback) {
        // Use the x-domain loader if the script is x-domain, or we're
        // in debug mode (when using the x-domain loader, we end up
        // inserting an actual script element to subsequently load the script
        // into the page, enabling debugging)

        if (_debuggableScripts || _xdomainRegex.test(script.src)) {
          // Downloads script using an img tag (in IE) or an object tag (in other
          // browsers).
          var downloader = document.createElement(_downloaderType);
          downloader.style.width = downloader.style.height = '0px';
          downloader.onload = downloader.onerror = function () {
            downloader.onload = downloader.onerror = null;
            callback();
          };
          downloader.src = downloader.data = script.src;
          document.body.appendChild(downloader);
        }
        else {
          // Downloads script using an XHR object. This allows us to retrieve the
          // content of the script and thereby allow us to subsequently use the
          // script text to insert a script element into the page, when the time
          // comes to load the script.
          var downloader = new XMLHttpRequest();
          downloader.onreadystatechange = function () {
            if (downloader.readyState == 4) {
              downloader.onreadystatechange = null;

              script.useText = true;
              script.text = downloader.responseText;
              callback();
            }
          };
          downloader.open('GET', script.src, true);
          downloader.send();
        }
      },

      canStore: !!window.localStorage,

      load: function (name) {
        return window.localStorage['script.' + name];
      },

      save: function (name, version, text) {
        window.localStorage['script.' + name] = text;

        // Save the fact that we have stored this script into the local storage
        // by updating the index with the new script information, and using
        // the index as the value of the cookie sent to the server as well.
        var scriptIndex = window.localStorage['script.$'];

        scriptIndex = scriptIndex ? JSON.parse(scriptIndex) : {};
        scriptIndex[name] = version;

        scriptIndex = JSON.stringify(scriptIndex);
        window.localStorage['script.$'] = scriptIndex;

        // A cookie with 180 days = 60 * 60 * 24 * 180 seconds
        document.cookie = _storageCookie + '=' + encodeURIComponent(scriptIndex) +
                          '; max-age=15552000; path=/';
      }
    };

  var _initCallbacks = [];
  var _readyCallbacks = [];
  var _registeredScripts = {};
  var _started = false;

  // Checks if the specified required scripts have been loaded.
  function checkScripts(name, requiredNames) {
    if (requiredNames) {
      requiredNames.split(',').forEach(function (s) {
        if (!_registeredScripts[s] || !_registeredScripts[s].loaded) {
          console.error(s + ' has not been loaded before ' + name);
        }
      });
    }
  }

  // Loads the specified script or scripts (identified by their registered
  // names) and invokes the specified callback (along with optional context)
  // when the scripts have been loaded.
  function loadScripts(scriptNames, callback, context) {
    scriptNames = scriptNames['push'] ? scriptNames : [scriptNames];
    _loadScripts(scriptNames, callback, context);
  }

  // Registers a callback to be invoked before script initialization occurs.
  // This is raised in response to the DOMContentLoaded event.
  // If initialization is complete, the callback is immediately invoked.
  function registerInitCallback(callback) {
    _initCallbacks ? _initCallbacks.push(callback) : setTimeout(callback, 0);
  }

  // Registers a callback to be invoked once startup scripts have been loaded
  // into the page, and any inline scripts have been executed.
  // If the page is ready, the callback is immediately invoked.
  function registerReadyCallback(callback) {
    _readyCallbacks ? _readyCallbacks.push(callback) : setTimeout(callback, 0);
  }

  // Registers a script programmatically. A script object has the following
  // structure:
  // {
  //   name: <name of script>,
  //   src: <url of script>,
  //   requires: <optional array of script dependencies>
  // }
  function registerScript(script) {
    script.loaded = false;
    _registeredScripts[script.name] = script;
  }

  // Downloads the script into the browser's cache, and invokes the specified
  // callback (optional) upon completion. The script is not loaded into the page,
  // i.e. it is not executed just yet.
  function _downloadScript(script, callback) {
    if (script.downloaded) {
      // Already downloaded, so invoke the callback immediately.
      if (callback) {
        callback(script);
      }
      return;
    }
    if (script.store && _scriptLoader.canStore) {
      if (script.store == 'load') {
        // Load the script content from local storage using the script name
        // as a key into local storage.
        script.useText = true;
        script.text = _scriptLoader.load(script.name);
      }
      else {
        // Save the inline script content using specified version into local
        // storage, using the name as a key. The value of data-store on the
        // script element is interpreted as the version identifier.

        script.useText = true;
        _scriptLoader.save(script.name, script.store, script.text);
      }

      script.downloaded = true;
      if (callback) {
        callback(script);
      }
      return;
    }
    if (script.downloading) {
      // The script is already being downloaded, so just tack on the
      // callback to the script element.
      if (callback) {
        if (!script.downloadCallbacks) {
          script.downloadCallbacks = [callback];
        }
        else {
          script.downloadCallbacks.push(callback);
        }
      }
      return;
    }

    script.downloading = true;

    var cb = function () {
      script.downloaded = true;
      script.downloading = false;
      if (callback) {
        callback(script);
      }
      if (script.downloadCallbacks) {
        script.downloadCallbacks.forEach(function (cb) {
          cb(script);
        });
        delete script.downloadCallbacks;
      }
    };

    _scriptLoader.download(script, cb);
  }

  // Loads the script into the page, by inserting an actual script element,
  // and invoking the specified callback once the script has been loaded.
  function _execScript(script, callback) {
    if (script.loaded) {
      // Already loaded. Invoke the callback immediately.
      callback(script);
      return;
    }

    var s = document.createElement('script');
    s.type = 'text/javascript';
    if (script.useText) {
      // Load the script with script content inline. This allows us to load script
      // while making sure another download is not incurred.
      s.text = script.text;
      setTimeout(function () {
        script.loaded = true;
        callback(script);
      }, 0);
    }
    else {
      // Load the script with its src. This ensures the script is debuggable, i.e. listed
      // within the browser's loaded scripts.
      s.onload = s.onreadystatechange = function () {
        if (s.readyState && s.readyState != 'complete' && s.readyState != 'loaded') {
          return;
        }
        s.onload = s.onreadystatechange = null;
        script.loaded = true;
        callback(script);
      };
      s.src = script.src;
    }
    _head.appendChild(s);
  }

  // Loads script with script content inline.
  function _evalScript(script) {
    var s = document.createElement('script');
    s.type = 'text/javascript';
    s.text = script.text;
    _head.appendChild(s);
  }

  // Helper to invoke a set of callbacks.
  function _invokeCallbacks(callbacks) {
    if (callbacks && callbacks.length) {
      callbacks.forEach(function (callback) {
        callback();
      });
    }
  }

  // Loads a set of scripts and invokes the specified callback along
  // with specified context.
  function _loadScripts(scriptNames, callback, context) {
    if (scriptNames.length == 0) {
      callback(context);
      return;
    }

    var loadCount = 0;
    var downloaded = [];

    // This is invoked everytime a script has been loaded/executed within the page.
    function scriptLoaded(script) {
      loadCount++;
      if (scriptNames.length == loadCount) {
        // All scripts have been loaded, so now invoke the passed in callback.
        callback(context);
      }
      else {
        if (downloaded.length) {
          // Try to process any downloads that need to be downloaded, as this
          // script might have been the dependency of one of those pending scripts.
          processDownloaded();
        }
      }
    }

    // This is invoked everytime a script has been downloaded. We add it to the list
    // of downloaded scripts and attempt to process it further.
    function scriptDownloaded(script) {
      downloaded.push(script);
      processDownloaded();
    }

    // This processes a set of downloaded scripts. Any scripts whose dependencies
    // have also been loaded will be executed.
    function processDownloaded() {
      // Hold on to the list of downloaded scripts needing to be processed
      // in this iteration.
      var scripts = downloaded;
      if (scripts.length) {
        // Reset the downloaded scripts array, so scripts can be added to it
        // for being processed in a subsequent iteration.
        downloaded = [];
        scripts.forEach(function (script) {
          var load = true;
          if (script.requires) {
            // Check if all dependencies have been loaded to determine if this
            // script should now be loaded into the page.
            load = script.requires.every(function (dependencyName) {
              return _registeredScripts[dependencyName].loaded;
            });
          }
          if (load) {
            _execScript(script, scriptLoaded);
          }
          else {
            // A dependency has not yet been loaded, so re-add it to
            // the list of downloads. The list of downloads will be
            // re-examined when another script is downloaded or loaded
            // into the page.
            downloaded.push(script);
          }
        });
      }
    }

    // Expand the list of script names to include any dependencies not
    // already included in the list that haven't already been loaded.
    var scriptMap = {};
    scriptNames.forEach(function (name) {
      scriptMap[name] = name;
    });

    var i = 0;
    do {
      var script = _registeredScripts[scriptNames[i++]];
      if (script.requires) {
        for (var j = script.requires.length - 1; j >= 0; j--) {
          var dependencyName = script.requires[j];
          if (!scriptMap[dependencyName] && !_registeredScripts[dependencyName].loaded) {
            // Found a dependency that needs to be included into the list
            // of scripts to be loaded, since it is a required dependency.
            scriptNames.push(dependencyName);
            scriptMap[dependencyName] = dependencyName;
          }
        }
      }
    } while (i < scriptNames.length);

    // Kick off downloading any scripts that need to be downloaded.
    // For those scripts that have been loaded, we don't need to attempt
    // downloading/loading them, but we do need to track them, so we know when
    // all required scripts have been loaded so as to invoke the passed in
    // callback.
    var done = true;
    scriptNames.forEach(function (name) {
      var script = _registeredScripts[name];
      if (script.loaded) {
        loadCount++;
      }
      else {
        _downloadScript(script, scriptDownloaded);
        done = false;
      }
    });

    // If we're done, i.e. all scripts were already loaded, then just go ahead
    // and invoke the passed in callback.
    if (done) {
      callback(context);
    }
  }

  // Invoke any ready callbacks that have been registered.
  function _raiseReady(deferredScripts) {
    // Kick off downloads for any deferred scripts (but don't load them into the
    // page just yet).
    deferredScripts.forEach(function (name) {
      var script = _registeredScripts[name];
      if (script.loaded) {
        return;
      }
      _downloadScript(script);
    });

    var readyCallbacks = _readyCallbacks;
    _readyCallbacks = null;
    _invokeCallbacks(readyCallbacks);
  }

  // Perform the page startup logic (in response to the DOMContentLoaded
  // notification raised by the DOM document, or an explicit call to load).
  function _startup() {
    if (_started) {
      return;
    }
    _started = true;

    // First invoke the registered init callbacks. This allows page code
    // to programmatically register scripts.
    var initCallbacks = _initCallbacks;
    _initCallbacks = null;
    _invokeCallbacks(initCallbacks);

    // Storage cookie defaults to 'scripts', but can be overriden via an
    // attribute on the body element.
    _storageCookie = document.body.getAttribute('data-scripts-cookie') || 'scripts';

    var startupScripts = [];
    var deferredScripts = [];
    var inlineScripts = [];

    // Extract the list of registered scripts and inline scripts by enumerating
    // script elements with type = text/script.

    var scriptElements = document.getElementsByTagName('script');
    for (var i = 0, count = scriptElements.length; i < count; i++) {
      var scriptElement = scriptElements[i];
      if (scriptElement.type == 'text/script') {
        var script = {
          name: scriptElement.getAttribute('data-name'),
          src: scriptElement.getAttribute('data-src'),
          requires: scriptElement.getAttribute('data-requires'),
          mode: scriptElement.getAttribute('data-mode') || 'startup',
          text: scriptElement.text,
          store: scriptElement.getAttribute('data-store')
        };
        if (script.requires) {
          script.requires = script.requires.split(',');
        }

        if (script.name) {
          registerScript(script);
          if (script.mode == 'startup') {
            startupScripts.push(script.name);
          }
          else if (script.mode == 'deferred') {
            deferredScripts.push(script.name);
          }
          // TODO: Error check - script.mode must be 'ondemand'
        }
        else {
          inlineScripts.push(script);
        }
      }
    }

    // Load the startup scripts, and once that is done, execute any inline
    // scripts there are on the page.
    _loadScripts(startupScripts, function () {
      var inlinesProcessed = 0;
      if (inlineScripts.length) {
        inlineScripts.forEach(function (script) {
          if (script.requires) {
            // If an inline script has a dependency on other scripts, ensure
            // they are loaded first.
            _loadScripts(script.requires, function (s) {
              _evalScript(s);
              inlinesProcessed++;

              // If all the inlines have been processed, then go ahead and invoke
              // the ready callbacks.
              if (inlinesProcessed == inlineScripts.length) {
                _raiseReady(deferredScripts);
              }
            }, script);
          }
          else {
            _evalScript(script);
            inlinesProcessed++;
          }
        });
      }

      // If all the inlines have been processed, then go ahead and invoke
      // the ready callbacks.
      if (inlinesProcessed == inlineScripts.length) {
        _raiseReady(deferredScripts);
      }
    });
  }

  window.ss = {
    load: _startup,
    loadScripts: loadScripts,
    checkScripts: checkScripts,
    registerScript: registerScript,
    init: registerInitCallback,
    ready: registerReadyCallback
  };
  if (document.addEventListener) {
    document.readyState == 'complete' ? _startup() : document.addEventListener('DOMContentLoaded', _startup, false);
  }
  else if (window.attachEvent) {
    window.attachEvent('onload', function () {
      _startup();
    });
  }
})();
