//! Test.js

#include "Static.js"
#include[as-is] "%code%"

#if DEBUG
alert('debug');
#endif

define('#= Name ##', [ #= DependencyNames ## ], function(#= Dependencies ##) {
});
//! Copyright (c) 2007
 