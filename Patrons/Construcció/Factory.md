# Factory pattern
```CSharp
public static class PersonaFactory  // Classe per fabricar objectes de tipus Persona o dels seus subtipus
{
    public static Persona CreaPersona(string tipus, string nom, string? nss = null)
    {
        return tipus.ToLower() switch
        {
            "treballador" => new Treballador(nom, nss),
            "jubilat" => new Jubilat(nom),
            _ => new Persona(nom) // Per defecte
        };
    }
}
```
Ara, des de qualsevol lloc, podem fer:  

```CSharp
    Persona p1 = PersonaFactory.CreaPersona("treballador", "Lucas", "12-3456789-10");
    Persona p2 = PersonaFactory.CreaPersona("jubilat", "Clara");
    Persona p3 = PersonaFactory.CreaPersona("persona", "Joan");
```
# Avantatges
✅ La creació d’objectes està totalment encapsulada =>  
* 👉 tota la lògica per crear instàncies de Persona i les seves subclasses (Treballador, Jubilat, etc.) està centralitzada dins de PersonaFactory.  
    *   Si volem afegir més subclasses en el futur, només modifiquem PersonaFactory sense tocar la resta del codi.  
    *   Evitem que altres parts del codi hagin de conèixer tots els constructors de cada subclasse.  
    *   El codi client només necessita saber que ha d’utilitzar PersonaFactory.CreaPersona(...), però no necessita conèixer cada subclasse ni com instanciar-la.  
*  👉 es redueix la dependència del codi client respecte a les subclasses concretes, millorant la modularitat i facilitant els canvis futurs.
