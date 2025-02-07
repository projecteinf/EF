# Modificadors d'accés (camps i mètodes)

✅ Per defecte, si no declarem el tipus, són de tipus private

## Tipus

| Modificador d'accés         | Descripció |
|-----------------------------|------------|
| **`private`**                   | La propietat és accessible només dins del tipus. Aquest és el valor per defecte. |
| **`internal`**                  | La propietat és accessible dins del tipus i qualsevol tipus definit en el mateix projecte (mateix assemblatge). |
| **`protected`**                 | La propietat és accessible dins del tipus i qualsevol tipus que hereti d'aquest. |
| **`public`**                    | La propietat és accessible des de qualsevol lloc. |
| `internal protected`        | La propietat és accessible dins del tipus, qualsevol tipus dins del mateix assemblatge i qualsevol tipus que hereti d'aquest. Equivalent a un modificador d'accés fictici anomenat `internal_or_protected`. |
| `private protected`         | La propietat és accessible dins del tipus o qualsevol tipus que hereti d'aquest i estigui en el mateix assemblatge. Equivalent a un modificador d'accés fictici anomenat `internal_and_protected`.  |

## Consideracions sobre tipus "ficticis"

internal protected: És útil si vols limitar l'accessibilitat tant per subclasses (herència) com per altres classes dins del mateix assembly. Això podria ser útil en frameworks o llibreries internes, on es vol permetre la reutilització dins del mateix projecte però restringint l’accés a usuaris externs.

private protected: Limita l’accés només a subclasses dins del mateix assembly, la qual cosa és encara més restrictiva que protected i internal per separat. Això podria servir en escenaris on només una jerarquia de classes interna ha de tenir accés a certes propietats.

# Bones pràctiques

✅ Assignar explícitament un modificador d'accés a cada membre del tipus, encara que sigui el valor del modificador per defecte. 
✅ Els camps (fields) haurien de ser private o protected per restringir-ne l'accés directe. Control sobre les modificacions del camp.
✅ Utilitzar propietats public per accedir als camps privats, proporcionant control sobre la lectura i escriptura.

```CSharp
class Persona
{
    private string _name; // Camp privat

    public string Name  // Propietat pública per accedir al camp
    {
        get { return _name; }
        set { _name = value; }
    }
}
```
