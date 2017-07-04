//Guid

function Guid() {
}
Guid._getRand = function () {
    return (Math.random() * 4294967295) | 0;
}
Guid.NewGuid = function () {
    var d0 = Guid._getRand();
    var d1 = Guid._getRand();
    var d2 = Guid._getRand();
    var d3 = Guid._getRand();
    var guid = Guid._hexMap[d0 & 255] + Guid._hexMap[d0 >> 8 & 255] + Guid._hexMap[d0 >> 16 & 255] + Guid._hexMap[d0 >> 24 & 255] + '-' + Guid._hexMap[d1 & 255] + Guid._hexMap[d1 >> 8 & 255] + '-' + Guid._hexMap[d1 >> 16 & 15 | 64] + Guid._hexMap[d1 >> 24 & 255] + '-' + Guid._hexMap[d2 & 63 | 128] + Guid._hexMap[d2 >> 8 & 255] + '-' + Guid._hexMap[d2 >> 16 & 255] + Guid._hexMap[d2 >> 24 & 255] + Guid._hexMap[d3 & 255] + Guid._hexMap[d3 >> 8 & 255] + Guid._hexMap[d3 >> 16 & 255] + Guid._hexMap[d3 >> 24 & 255];
    return guid;
}
var Guid$ = {

};