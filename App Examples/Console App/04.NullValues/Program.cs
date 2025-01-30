int notNullValue = 5;
int? nullableValue = null; // Utilize ? to make a value type nullable

// notNullValue = null; // error CS0037: Cannot convert null to 'int' because it is a non-nullable value type

Console.WriteLine($"notNullValue: {notNullValue}");
Console.WriteLine($"nullableValue:{nullableValue}");
Console.WriteLine($"nullableValue default value: {nullableValue.GetValueOrDefault()}");

nullableValue = 10;
Console.WriteLine($"nullableValue:{nullableValue}");
