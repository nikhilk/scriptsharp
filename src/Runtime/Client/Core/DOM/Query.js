// DOM Query Helpers

function query(selector, root) {
  root = root || document;
  return root.querySelector(selector);
}

function queryAll(selector, root) {
  root = root || document;
  return ss.array(root.querySelectorAll(selector));
}
