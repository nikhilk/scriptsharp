///////////////////////////////////////////////////////////////////////////////
// Boolean Extensions

Boolean.__typeName = 'Boolean';

Boolean.parse = function#? DEBUG Boolean$parse##(s) {
    return (s.toLowerCase() == 'true');
}
