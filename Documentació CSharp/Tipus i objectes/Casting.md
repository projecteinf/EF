# Casting
## Implicit casting
Associació d'un objecte de la classe fill a una variable de la classe pare.
```CSharp
    Persona refPersona = new Treballador("Eva", "98-1234567-89"); 
```
## Explicit casting
```CSharp
    Persona personaTreballadora = new Treballador("Eva", "98-1234567-89"); 
    if (personaTreballadora is Treballador) {   // Ens assegurem que podem convertir l'objecte personaTreballador a Treballador
        Treballador treballador = (Treballador)personaTreballadora;    // Explicit casting
    }
```
### Utilitzant as
* Cal tenir en compte, que quan utilitzem la paraula reservada "as" per a fer casting, si el casting no es pot fer per imcompatibilitat de tipus, el resultat de l'operació serà null
```CSharp
    Persona personaTreballadora = new Treballador("Eva", "98-1234567-89"); 
    Treballador treballador = personaTreballadora as Treballador;    // Explicit casting amb as
    if (treballador != null) {   // La conversió s'ha pogut fer
        
    }
```
Cal tenir en compte que independentment del sistema que utilitzem, les dues variables referencien el mateix objecte (apunten a la mateixa posició de memòria).