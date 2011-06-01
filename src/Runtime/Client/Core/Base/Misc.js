// Number Helpers

function truncateNumber(n) {
  return (n >= 0) ? Math.floor(n) : Math.ceil(n);
}

// Date Helpers

function now() {
  return new Date();
}

function today() {
  var d = new Date();
  return new Date(d.getFullYear(), d.getMonth(), d.getDate());
}

// Array Helpers

function toArray(o) {
  return Array.prototype.slice.call(o);
}
