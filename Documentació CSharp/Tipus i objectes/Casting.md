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
        Treballador treballadora = (Treballador)personaTreballadora;    // Explicit casting
    }
```
