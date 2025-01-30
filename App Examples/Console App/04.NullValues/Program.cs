int notNullValue = 5;
int? nullableValue = null; // Utilize ? to make a value type nullable

// notNullValue = null; // error CS0037: Cannot convert null to 'int' because it is a non-nullable value type

Console.WriteLine($"notNullValue: {notNullValue}");
Console.WriteLine($"nullableValue:{nullableValue}");
Console.WriteLine($"nullableValue default value: {nullableValue.GetValueOrDefault()}");

nullableValue = 10;
Console.WriteLine($"nullableValue:{nullableValue}");

// Codi utilitzant "?" 
// Retorna la suma d'una llista de números
double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
{
    return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
}

double SumNumbersClassic(List<double[]> setsOfNumbers, int indexOfSetToSum)
{
    {
    if (setsOfNumbers == null || indexOfSetToSum < 0 || indexOfSetToSum >= setsOfNumbers.Count)
    {
        return double.NaN;
    }

    double[] selectedSet = setsOfNumbers[indexOfSetToSum];
    if (selectedSet == null)
    {
        return double.NaN;
    }

    double sum = 0;
    foreach (double number in selectedSet)
    {
        sum += number;
    }

    return sum;
}

Console.WriteLine(SumNumbers(null, 0));  // output: NaN
Console.WriteLine(SumNumbersClassic(null, 0));
  
List<double[]?> numbers =
[
    [1.0, 2.0, 3.0],
    null
];


Console.WriteLine(SumNumbers(numbers, 0));  // output: 6
Console.WriteLine(SumNumbersClassic(numbers, 0));
 
Console.WriteLine(SumNumbers(numbers, 1)); // output: NaN
Console.WriteLine(SumNumbersClassic(numbers, 1));

  
