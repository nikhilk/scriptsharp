
describe('keys', () => {
    test('object keys are returned', () => {
        //Arrange
        const keys = require(process.env['RUNTIME']).keys;
        const obj = { a: null, b: true, c: "" };

        //Act
        const result = keys(obj);
        
        //Assert
        expect(result.length).toEqual(3);
        expect(result).toEqual(expect.arrayContaining(['a', 'b', 'c']));
    });

    test('empty object returns empty array', () => {
        //Arrange
        const keys = require(process.env['RUNTIME']).keys;

        //Act
        const result = keys({});

        //Assert
        expect(result).toEqual([]);
    });
});