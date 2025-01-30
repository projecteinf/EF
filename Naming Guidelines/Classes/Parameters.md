# Nomenclatura paràmetres

✅ Els paràmetres han de seguir la nomenclatura **camelCasing** 

**Example:**
```csharp
public void SetUserName(string userName) { }
public int CalculateTotal(int itemCount, double pricePerItem) { }
```

✅ Han de decriure el seu propòsit i què representen

**Example:**
```csharp
// CORRECTE
public void SendEmail(string recipientEmail, string subject, string messageBody) { }

// INCORRECTE
public void SendEmail(string email, string sub, string msg) { }
```

✅ El nom el paràmetre ha d'estar relacionat amb el seu propòsit, no amb el seu tipus.

**Example:**
```csharp
// CORRECTE

public void ProcessPayment(decimal amount, string currencyCode) { }

// INCORRECTE
public void ProcessPayment(decimal d, string s) { }
```

# Nomenclatura paràmetres de sobrecàrrega d'operador

✅ Quan es sobrecarregui un operador binari (ex: +, -, *, /, ...), si els paràmetres no tenen un significat especial, utilitza "left" i "right" com a noms de paràmetres.
**Example:**
```csharp

public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    // CORRECTE
    public static Vector operator +(Vector left, Vector right)
    {
        return new Vector(left.X + right.X, left.Y + right.Y);
    }
}


public class Vector {
    public int X { get; set; }
    public int Y { get; set; }

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    // INCORRECTE
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y);
    }
}
```

✅ Quan la sobrecarrega és d'un operador unari (com !, ++, --), si el paràmetre no té un significat específic, utilitza "value" per representar l'operand.

**Example:**
```csharp

public class Number
{
    public int Value { get; set; }

    public Number(int value)
    {
        Value = value;
    }
    // CORRECTE
    public static Number operator -(Number value)
    {
        return new Number(-value.Value);
    }
}
```

✅ Si els paràmetres tenen un significat específic o un context, utilitza noms significatius en lloc de noms genèrics com left, right o value.

**Example:**
```csharp

public class Complex
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // CORRECTE
    // Els noms multiplicand i multiplier tenen sentit en la multiplicació de nombres complexes
    public static Complex operator *(Complex multiplicand, Complex multiplier)
    {
        return new Complex(
            multiplicand.Real * multiplier.Real - multiplicand.Imaginary * multiplier.Imaginary,
            multiplicand.Real * multiplier.Imaginary + multiplicand.Imaginary * multiplier.Real
        );
    }
}
```

❌ Evita utilitzar abreviacions o índexs numèrics (com a, b, x1, x2) per als noms dels paràmetres, ja que redueixen la llegibilitat i la claredat.

**Example:**
```csharp
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // CORRECTE
    public static Point operator +(Point left, Point right)
    {
        return new Point(left.X + right.X, left.Y + right.Y);
    }
}


public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // INCORRECTE
    public static Point operator +(Point p1, Point p2)
    {
        return new Point(p1.X + p2.X, p1.Y + p2.Y);
    }
}
```
