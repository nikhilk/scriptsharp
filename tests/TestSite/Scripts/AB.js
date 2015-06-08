define('A', ['ss'], function(ss) {
  return { $name: 'A', $dep: ss };
});

define('B', ['A'], function(a) {
  return { $name: 'B', $dep: a };
});
