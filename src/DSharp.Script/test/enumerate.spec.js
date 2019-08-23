
describe('enumerate', () => {
    test('null returns empty enumerator', () => {
        //Arrange
        const enumerate = require(process.env['RUNTIME']).enumerate;

        //Act
        const result = enumerate(null);

        //Assert
        expect(result.moveNext()).toBe(false);
    });

    test('empty array returns empty enumerator', () => {
        //Arrange
        const enumerate = require(process.env['RUNTIME']).enumerate;

        //Act
        const result = enumerate([]);

        //Assert
        expect(result.moveNext()).toBe(false);
    });

    test('empty object returns empty enumerator', () => {
        //Arrange
        const enumerate = require(process.env['RUNTIME']).enumerate;

        //Act
        const result = enumerate({});

        //Assert
        expect(result.moveNext()).toBe(false);
    });

    test('array returns elements', () => {
        //Arrange
        const enumerate = require(process.env['RUNTIME']).enumerate;
        const emumerator = enumerate([1,2,3]);

        //Act
        const results = [];
        emumerator.moveNext();
        results.push(emumerator.current);
        emumerator.moveNext();
        results.push(emumerator.current);
        emumerator.moveNext();
        results.push(emumerator.current);

        //Assert
        expect(results[0]).toBe(1);
        expect(results[1]).toBe(2);
        expect(results[2]).toBe(3);
    });

    test('array returns correct number of elements', () => {
        //Arrange
        const enumerate = require(process.env['RUNTIME']).enumerate;
        const emumerator = enumerate([1, 2, 3]);

        //Act
        emumerator.moveNext();
        emumerator.moveNext();
        emumerator.moveNext();

        //Assert
        expect(emumerator.moveNext()).toBe(false);
    });

    test('object returns key-value-pairs', () => {
        //Arrange
        const enumerate = require(process.env['RUNTIME']).enumerate;
        const emumerator = enumerate({a:1,b:2,c:3});

        //Act
        const results = [];
        emumerator.moveNext();
        results.push(emumerator.current);
        emumerator.moveNext();
        results.push(emumerator.current);
        emumerator.moveNext();
        results.push(emumerator.current);

        //Assert
        expect(results[0]).toEqual({key:'a', value:1});
        expect(results[1]).toEqual({key:'b', value:2});
        expect(results[2]).toEqual({key:'c', value:3});
    });

    test('object returns correct number of elements', () => {
        //Arrange
        const enumerate = require(process.env['RUNTIME']).enumerate;
        const emumerator = enumerate({ a: 1, b: 2, c: 3 });

        //Act
        emumerator.moveNext();
        emumerator.moveNext();
        emumerator.moveNext();

        //Assert
        expect(emumerator.moveNext()).toBe(false);
    });
});