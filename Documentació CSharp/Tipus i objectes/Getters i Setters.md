# Getters i Setters

## Auto-Implemented Property

1. No cal definir cap camp privat on emmagatzemar el valor. El compilador crea el camp per nosaltres.
2. La implementació de getter i setter és automàtica: no podem personalitzar el codi del getter ni del setter

```CSharp
public class Article {
    public string Nom { get; set; }
}
```

Com que Merma només implementa el mètode getter, hem d'inicialitzar el seu valor en el constructor o en la declaració de la propietat.

```CSharp
public class Article
{
    public string Nom { get; } = "Genèric"; // Declaració i inicialització de la  propietat

    public Article(string nom)  // Inicialització en el constructor
    {
        Nom = nom; 
    }
}
```

## Backing Field Property

1. Cal definir un camp (no public) on s'emmagatzemarà el valor que assignem a través de la propietat
2. Podem personalitzar els mètodes getter i setter

```CSharp
public class Article {
    
    private decimal _marge; // Resultat de Marge/100
    private string _colorPrimari;

    public decimal Marge { // El mètode retorna un decimal!
        get { 
                return _marge; 
            }
        set { 
                _marge = value / 100;   // Sempre rebem el valor amb la paraula reservada value
            } 
    }

    public string ColorPrimari
    {
        get
        {
            return _colorPrimari;
        }
        set
        {
            switch (value.ToLower())
            {
                case "red":
                case "green":
                case "blue":
                    _colorPrimari = value;
                    break;
                default:
                    throw new System.ArgumentException(
                    $"{value} is not a primary color. Choose from: red, green, blue.");
            }
        }
    }
}

```

# Utilització d'expressions Lambda

Només podem utilitzar expressions lambda si s'executa una única línia de codi. L'opció és que cridi a un altre mètode de la classe.

```CSharp
public class Article {
    
    private decimal _marge; // Resultat de Marge/100
    
    public decimal Marge { 
        get => _marge; 
        set => _marge = value / 100;   
    }
}

```
