
describe('properties', () => {
    test('createReadonlyProperty creates property', () => {
        //Arrange
        const createReadonlyProperty = require(process.env['RUNTIME']).createReadonlyProperty;
        const propertyName = "MyProperty";
        let obj = {};

        //Act
        createReadonlyProperty(obj, propertyName, null);

        //Assert
        expect(obj).toHaveProperty(propertyName);
    });

    test('createReadonlyProperty property is readonly', () => {
        //Arrange
        const createReadonlyProperty = require(process.env['RUNTIME']).createReadonlyProperty;
        const propertyName = "MyProperty";
        let obj = {};
        let value = "Value";
        createReadonlyProperty(obj, propertyName, value);

        //Act
        obj[propertyName] = 1

        //Assert
        expect(obj).toHaveProperty(propertyName, value);
    });
});