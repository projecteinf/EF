# Getters i Setters

## Auto-Implemented Property

1. No cal definir cap camp privat on emmagatzemar el valor. El compilador crea el camp per nosaltres.
2. No cal definir el mètodes de getter i setter. Només indicar quins utilitzarem. En el cas d'utilitzar només get, cal que el valor s'assigni a la propietat en la declaració de la mateixa o en el constructor.
3. No podem assignar cap codi personalitzat als mètodes (return _nom pel getter i _nom=value pel setter)

```CSharp
public class Article {
    public string Nom { get; set; }
}
```

## Backing Field Property

```CSharp
public class Article {
    private string _nom;
    public string Nom { 
        get { return _nom; }
        set { _nom = value; } 
    }
}
```


