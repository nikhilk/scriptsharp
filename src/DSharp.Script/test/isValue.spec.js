
describe('isValue', () => {
    test('null is not a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;

        //Act
        const result = isValue(null);

        //Assert
        expect(result).toBe(false);
    });

    test('undefined is not a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;
        const object = {};

        //Act
        const result = isValue(object.property);

        //Assert
        expect(result).toBe(false);
    });

    test('empty string is a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;

        //Act
        const result = isValue("");

        //Assert
        expect(result).toBe(true);
    });

    test('string is a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;

        //Act
        const result = isValue("string");

        //Assert
        expect(result).toBe(true);
    });

    test('0 is a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;

        //Act
        const result = isValue(0);

        //Assert
        expect(result).toBe(true);
    });

    test('1 is a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;

        //Act
        const result = isValue(1);

        //Assert
        expect(result).toBe(true);
    });
    
    test('false is a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;

        //Act
        const result = isValue(false);

        //Assert
        expect(result).toBe(true);
    });

    test('true is a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;

        //Act
        const result = isValue(true);

        //Assert
        expect(result).toBe(true);
    });

    test('function is a value', () => {
        //Arrange
        const isValue = require(process.env['RUNTIME']).isValue;

        //Act
        const result = isValue(function () { });

        //Assert
        expect(result).toBe(true);
    });
});