(function() {

function IDrawable() {}

function Shape(type) {
  this._type = type;
}
var Shape$proto = {
  get_type: function() {
    return this._type;
  },
  draw: function() {
    return 'shape(' + this._type + '); ';
  }
};

function Circle(radius) {
  Shape.apply(this, [ 'circle' ]);
  this._radius = radius;
}
var Circle$proto = {
  get_radius: function() {
    return this._radius;
  },
  draw: function() {
    var drawing = Shape.prototype.draw.call(this);
    return drawing + 'circle(' + this._radius + '); ';
  }
};

function XCircle(radius) {
  Circle.apply(this, [ radius ]);
}
var XCircle$proto = {
};

var $ns = ss.ns('Test');
ss.type($ns,
  [ IDrawable, 'IDrawable' ],
  [ Shape, 'Shape', Shape$proto, null, [ IDrawable ] ],
  [ Circle, 'Circle', Circle$proto, Shape ],
  [ XCircle, 'XCircle', XCircle$proto, Circle ]
);

})();
