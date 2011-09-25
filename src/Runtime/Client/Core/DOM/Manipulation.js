// DOM Manipulation Helpers

function hasClass(className) {
  return new RegExp('(?:^|\\s+)' + className + '(?:\\s+|$)').test(this.className);
}

function addClass(className) {
  if (!this.hasClass(className)) {
    this.className = [this.className, className].join(' ').replace(/^\s*|\s*$/g, '');
    return this;
  } 
}

function removeClass(className) {
  if (this.hasClass(className)) {
    this.className = this.className.replace(new RegExp('(?:^|\\s+)' + className + '(?:\\s+|$)', 'g'), ' ').replace(/^\s*|\s*$/g, '');
    return this;
  } 
}

function toggleClass(firstClassName, secondClassName) {
  if (!secondClassName) {
    if (!this.hasClass(firstClassName)) {
      this.addClass(firstClassName);
    }
    else {
      this.removeClass(firstClassName);
    }
  }
  else if (secondClassName) {
    if (!this.hasClass(firstClassName)) {
      this.addClass(firstClassName);
      this.removeClass(secondClassName);
    }
    else {
      this.removeClass(firstClassName);
      this.addClass(secondClassName);
    }
  }
  return this;
}
