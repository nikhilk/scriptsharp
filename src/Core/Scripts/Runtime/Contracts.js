// Contracts

function IDisposable() { }
function IEnumerable() { }
function IEnumerator() { }
function IObserver() { }
function IApplication() { }
function IContainer() { }
function IObjectFactory() { }
function IEventManager() { }
function IInitializable() { }

IEnumerator.getEnumerator = function(enumerable) {
  if (enumerable) {
    return enumerable.getEnumerator ? enumerable.getEnumerator() : new ArrayEnumerator(enumerable);
  }
  return null;
}

