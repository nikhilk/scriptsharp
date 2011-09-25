//! Sharpen Core Runtime
//! DOM Helpers (for HTML5 browsers only - IE9+, WebKit)
//!

(function() {

#include "DOM\Query.js"
#include "DOM\Manipulation.js"
#include "DOM\Misc.js"

ss.extend(HTMLElement.prototype, {
  hasClass: hasClass,
  addClass: addClass,
  removeClass: removeClass,
  toggleClass: toggleClass
});

ss.extend(ss, {
  query: query,
  queryAll: queryAll,
  htmlEncode: htmlEncode,
  htmlDecode: htmlDecode
});

})();
