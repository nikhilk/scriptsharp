// Miscellaneous Helpers

function htmlDecode(s) {
  var div = document.createElement('div');
  div.innerHTML = s;
  return div.textContent || div.innerText;
}

function htmlEncode(s) {
  var div = document.createElement('div');
  div.appendChild(document.createTextNode(s));
  return div.innerHTML.replace(/\"/g, '&quot;');
}
