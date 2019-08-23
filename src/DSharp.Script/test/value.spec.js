
describe('value', () => {
    test('null is returned if no values are passed', () => {
        //Arrange
        const value = require(process.env['RUNTIME']).value;

        //Act
        const result = value();

        //Assert
        expect(result).toBeNull();
    });

    test('null is returned if null values are passed', () => {
        //Arrange
        const value = require(process.env['RUNTIME']).value;

        //Act
        const results = [
            value(null),
            value(null, null),
            value(null, null, null)
        ];

        //Assert
        expect(results[0]).toBeNull();
        expect(results[1]).toBeNull();
        expect(results[2]).toBeNull();
    });

    test('first argument is returned if it is a value', () => {
        //Arrange
        const value = require(process.env['RUNTIME']).value;

        //Act
        const results = [
            value(1),
            value(1, 2),
            value(1, 2, 3)
        ];

        //Assert
        expect(results[0]).toBe(1);
        expect(results[1]).toBe(1);
        expect(results[2]).toBe(1);
    });

    test('second argument is returned if it is a value but first is not', () => {
        //Arrange
        const value = require(process.env['RUNTIME']).value;

        //Act
        const results = [
            value(null, 2),
            value(null, 2, 3)
        ];

        //Assert
        expect(results[0]).toBe(2);
        expect(results[1]).toBe(2);
    });
    
    test('third argument is returned if it is the first passed value', () => {
        //Arrange
        const value = require(process.env['RUNTIME']).value;

        //Act
        const result = value(null, null, 3);

        //Assert
        expect(result).toBe(3);
    });
});