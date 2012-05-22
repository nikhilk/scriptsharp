///////////////////////////////////////////////////////////////////////////////
// Tuple

ss.Tuple = function (first, second, third) {
  this.first = first;
  this.second = second;
  if (arguments.length == 3) {
    this.third = third;
  }
}
ss.Tuple.registerClass('Tuple');
