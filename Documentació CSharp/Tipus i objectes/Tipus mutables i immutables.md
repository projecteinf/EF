# Tipus mutables i immutables

Els tipus mutables implementen mètodes que modifiquen directament l'objecte. La gran majoria de tipus que definim en la nostra aplicació són mutables. Els tipus immutables són aquells que sempre retornen un nou objecte.

# Per què immutables?

1. Method chaining

Un exemple de method chaining és per l'aplicació del patró "builder". 

```CSharp
// Method chaining . No cal emmagatzemar els objectes (Color i Wheels) intermitjos
var car = new CarBuilder()  
    .SetColor("Red")
    .SetWheels(4)
    .Build();
```

El codi font està de les diferents classes seria

```CSharp
// Codificació del patró 
public class Color
{
    public string Name { get; }
    public Color(string name) => Name = name;
}

public class Wheels
{
    public int Count { get; }
    public bool IsOffroad { get; }

    public Wheels(int count, bool isOffroad)
    {
        Count = count;
    }
}

public class Car
{
    public Color Color { get; }
    public Wheels Wheels { get; }

    public Car(Color color, Wheels wheels)
    {
        Color = color;
        Wheels = wheels;
    }
}

public class CarBuilder
{
    private Color _color;
    private Wheels _wheels;

    public CarBuilder SetColor(string colorName)
    {
        _color = new Color(colorName);
        return this;
    }

    public CarBuilder SetWheels(int count)
    {
        _wheels = new Wheels(count);
        return this;
    }

    public Car Build()
    {
        return new Car(_color, _wheels);
    }
}
```

2. Objectes que per naturalesa no poden canviar

Alguns documents: contractes, factures,... són per naturalesa immutables. En el cas que es canvïin, cal tenir un històric de versions. Utilitzar objectes immutables ens facilita obtenir aquest històric.


