
describe('extend', () => {
    test('negative decimal is truncated', () => {
        //Arrange
        const truncate = require(process.env['RUNTIME']).truncate;

        //Act
        const result = truncate(-1.234);

        //Assert
        expect(result).toEqual(-1);
    });

    test('negative integer is unchanged', () => {
        //Arrange
        const truncate = require(process.env['RUNTIME']).truncate;

        //Act
        const result = truncate(-1);

        //Assert
        expect(result).toEqual(-1);
    });

    test('positive decimal is truncated', () => {
        //Arrange
        const truncate = require(process.env['RUNTIME']).truncate;

        //Act
        const result = truncate(1.234);

        //Assert
        expect(result).toEqual(1);
    });

    test('positive integer is unchanged', () => {
        //Arrange
        const truncate = require(process.env['RUNTIME']).truncate;

        //Act
        const result = truncate(1);

        //Assert
        expect(result).toEqual(1);
    });

    test('zero is unchanged', () => {
        //Arrange
        const truncate = require(process.env['RUNTIME']).truncate;

        //Act
        const result = truncate(0);

        //Assert
        expect(result).toEqual(0);
    });
});