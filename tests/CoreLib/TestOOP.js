Type.registerNamespace('Test');

////////////////////////////////////////////////////////////////////////////////
// Test.IMammal

Test.IMammal = function() { };
Test.IMammal.prototype = {

}
Test.IMammal.registerInterface('Test.IMammal');


////////////////////////////////////////////////////////////////////////////////
// Test.IPet

Test.IPet = function() { };
Test.IPet.prototype = {
    get_name : null,
    get_owner : null
}
Test.IPet.registerInterface('Test.IPet');


////////////////////////////////////////////////////////////////////////////////
// Test.Animal

Test.Animal = function Test_Animal(species) {
    this._species = species;
}
Test.Animal.prototype = {
    _species: null,
    
    get_species: function Test_Animal$get_species() {
        return this._species;
    }
}


////////////////////////////////////////////////////////////////////////////////
// Test.Cat

Test.Cat = function Test_Cat() {
    Test.Cat.initializeBase(this, [ 'Cat' ]);
}
Test.Cat.prototype = {
    
    speak: function Test_Cat$speak() {
        return 'meow';
    }
}


////////////////////////////////////////////////////////////////////////////////
// Test.Garfield

Test.Garfield = function Test_Garfield() {
    Test.Garfield.initializeBase(this);
}
Test.Garfield.prototype = {
    
    get_name: function Test_Garfield$get_name() {
        return 'Garfield';
    },
    
    get_owner: function Test_Garfield$get_owner() {
        return 'Jon';
    },
    
    speak: function Test_Garfield$speak() {
        return Test.Garfield.callBaseMethod(this, 'speak') + '\r\n' + 'I am fat, lazy, and cynical, but still, a favorite cat...';
    }
}


Test.Animal.registerClass('Test.Animal');
Test.Cat.registerClass('Test.Cat', Test.Animal, Test.IMammal);
Test.Garfield.registerClass('Test.Garfield', Test.Cat, Test.IPet);
