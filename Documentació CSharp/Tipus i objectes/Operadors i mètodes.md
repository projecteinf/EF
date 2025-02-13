# Implementar funcionalitat amb operadors

En alguns casos, segons la tipologia de les dades en què treballem, la claredat i llegibilitat del codi millora amb operadors ( +, *, ...) en lloc de noms de mètodes (Add, Multiply,...). Simplement, per què és més natural. 

Suposem que estic treballant amb coordenades (x,y) i les vull sumar. Em puc plantejar que l'usuari utilitzi el seu codi per a sumar dues coordenades de la següent manera

```CSharp
coordResult = coordOrigen + coordDespl; // Expressió utilitzant operador +
coordResult = coordOrigen.Add(coordDespl); // Utilitzant un mètode!

// o bé

coordOrigen += coordDespl; // Si no preciso de la coordenada origen inicial
coordOrigen = coordOrigen.Add(coordDespl); // Expressió amb la qual estem menys familiaritzats
```
La implementació del  codi seria

```CSharp
public class Coordenada // Classe immutable!
{
    public int X { get; }
    public int Y { get; }

    public Coordenada(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Mètode que realitza la suma
    public Coordenada Add(Coordenada coordDespl) => new Coordenada(X + coordDespl.X, Y + coordDespl.Y);

    // Operador que reutilitza el mètode
    public static Coordenada operator +(Coordenada coordOrigen, Coordenada coordDespl) => coordOrigen.Add(coordDespl);
}
```
que ens permet utilitzar qualsevol dels dos sistemes: operador + o mètode Add
