
describe('extend', () => {
    test('null object throws when properties are given', () => {
        //Arrange
        const extend = require(process.env['RUNTIME']).extend;

        //Act
        const test = () => { extend(null, { b: 2 }); };

        //Assert
        expect(test).toThrow();
    });

    test('object has properties and values copied from another object', () => {
        //Arrange
        const extend = require(process.env['RUNTIME']).extend;
        const object = {a:1};
        const anotherObject = { b: 2, c: () => { }, d: null };

        //Act
        const result = extend(object, anotherObject);

        //Assert
        expect(result).toStrictEqual(object);
        expect(result.a).toEqual(1);
        expect(result.b).toEqual(2);
        expect(result.c).toEqual(anotherObject.c);
        expect(result).toHaveProperty('d');
        expect(result.d).toBeNull();
    });
});