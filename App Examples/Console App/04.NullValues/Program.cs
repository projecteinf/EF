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
double SumNumbers(List<double[]> numbers, int indexOfSetToSum)
{
    return indexOfSetToSum >= numbers?.Count ? double.NaN : numbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
}


// Codi clàssic amb control de nulls

double SumNumbersClassic(List<double[]> numbers, int indexOfSetToSum)
{
    if (numbers == null || indexOfSetToSum < 0 || indexOfSetToSum >= numbers.Count)
    {
        return double.NaN;
    }

    double[] selectedSet = numbers[indexOfSetToSum];
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

// output: NaN
Console.WriteLine(SumNumbers(null, 0));  
Console.WriteLine(SumNumbersClassic(null, 0));
  
List<double[]?> numbers =
[
    [1.0, 2.0, 3.0],
    null
];

// output: 6
Console.WriteLine(SumNumbers(numbers, 0));  
Console.WriteLine(SumNumbersClassic(numbers, 0));

// output: NaN 
Console.WriteLine(SumNumbers(numbers, 1)); 
Console.WriteLine(SumNumbersClassic(numbers, 1));

// OutOfRangeException  
Console.WriteLine(SumNumbers(numbers, 2)); 
Console.WriteLine(SumNumbersClassic(numbers, 2));