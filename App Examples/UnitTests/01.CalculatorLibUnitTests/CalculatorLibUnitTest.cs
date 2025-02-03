namespace BoscComa.Calculadora;

/*
    Per executar els tests:

    dotnet test
*/
public class UnitTestCalculadora
{
/* 
    Arrange: This part will declare and instantiate variables for input and output.
    •Act: This part will execute the unit that you are testing. In our case, that
            means calling the method that we want to test.
    •Assert: This part will make one or more assertions about the output. An
            assertion is a belief that if not true indicates a failed test. For example, when
            adding 2 and 2 we would expect the result would be 4. */
    [Fact]
    public void Sumar()
    {
        decimal quantity1 = 2;
        decimal quantity2 = 2;
        decimal expected = 4;
        var calc = new Calculadora();

        // act
        decimal actual = calc.Sumar(quantity1, quantity2);
        // assert
        Assert.Equal(expected, actual);
    }
}
