
describe('keyCount', () => {
    test('number of properties are returned', () => {
        //Arrange
        const keyCount = require(process.env['RUNTIME']).keyCount;

        //Act
        const results = [
            keyCount({}),
            keyCount({ a: 1 }),
            keyCount({ a: 1, b: 2 }),
            keyCount({ a: 1, b: 2, c: 3 })
        ];

        //Assert
        expect(results[0]).toEqual(0);
        expect(results[1]).toEqual(1);
        expect(results[2]).toEqual(2);
        expect(results[3]).toEqual(3);
    });
});