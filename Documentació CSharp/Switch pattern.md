# Switch pattern

Codificació clàssica

```csharp
class Point
{
    public int X { get; }
    public int Y { get; }
    public Point(int x, int y) => (X, Y) = (x, y);
    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
}

static string Display(object o)
{
    switch (o)
    {
        case Point p when p.X == 0 && p.Y == 0:
            return "origin";
        case Point p:
            return $"({p.X}, {p.Y})";
        default:
            return "unknown";
    }
}

// Aplicació de la nova sintaxis : més llegible i concisa

static string Display(object o)
{
    return o switch
    {
        Point p when p.X == 0 && p.Y == 0 => "origin",
        Point p                           => $"({p.X}, {p.Y})",
        _                                 => "unknown"
    };
}

// Com que el mètode Display només consisteix d'una sentència return, podem simplificar encara més el codi amb expressió lambda. No cal utilitzar la paraula clau return ni les clausules {}

static string Display(object o) => o switch
{
    Point p when p.X == 0 && p.Y == 0 => "origin",
    Point p                           => $"({p.X}, {p.Y})",
    _                                 => "unknown"
};


```
