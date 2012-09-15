// Date

Date.Empty = null;

Date.get_now = function() {
  return new Date();
}

Date.get_today = function() {
  var d = new Date();
  return new Date(d.getFullYear(), d.getMonth(), d.getDate());
}

Date.isEmpty = function(d) {
  return (d === null) || (d.valueOf() === 0);
}

