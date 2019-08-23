describe('clearKeys', () => {
    test('clearKeys removes all properties', () => {
        //Arrange
        const clearKeys = require(process.env['RUNTIME']).clearKeys;
        const obj = {a:1, b:2, c:3};

        //Act
        clearKeys(obj);

        //Assert
        expect(obj).toEqual({});
    });
});