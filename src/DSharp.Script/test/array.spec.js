
describe('array', () => {
    test('null returns null', () => {
        //Arrange
        const array = require(process.env['RUNTIME']).array;

        //Act
        const result = array(null);

        //Assert
        expect(result).toBeNull();
    });

    test('arguments is converted to array', () => {
        //Arrange
        const array = require(process.env['RUNTIME']).array;

        //Act
        const result = array(arguments);

        //Assert
        expect(Array.isArray(arguments)).toBe(false);
        expect(Array.isArray(result)).toBe(true);
    });

    test('array is cloned', () => {
        //Arrange
        const array = require(process.env['RUNTIME']).array;
        const arr = [1, 2, 3];

        //Act
        const result = array(arr);

        //Assert
        expect(result).not.toBe(arr);
        expect(result).toEqual(arr);
    });
});