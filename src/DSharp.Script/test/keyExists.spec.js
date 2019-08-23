
describe('keyExists', () => {
    test('missing key returns false', () => {
        //Arrange
        const keyExists = require(process.env['RUNTIME']).keyExists;

        //Act
        const result = keyExists({}, 'a');

        //Assert
        expect(result).toBe(false);
    });

    test('existing key returns true', () => {
        //Arrange
        const keyExists = require(process.env['RUNTIME']).keyExists;

        //Act
        const result = keyExists({ a: 1 }, 'a');

        //Assert
        expect(result).toBe(true);
    });
});