# Col·leccions
| **Namespace**                          | **Tipus**                                                                 | **Descripció** |
|-----------------------------------------|--------------------------------------------------------------------------|---------------|
| `System.Collections`                    | `IEnumerable`, `IEnumerable<T>`                                          | Interfícies i classes base utilitzades per a col·leccions. |
| `System.Collections.Generic`            | `List<T>`, `Dictionary<T>`, `Queue<T>`, `Stack<T>`                        | Per a  tipus de dades genèriques (més segur, ràpid i eficient). |
| `System.Collections.Concurrent`         | `BlockingCollection`, `ConcurrentDictionary`, `ConcurrentQueue`           | Per a escenaris multithreading. |
| `System.Collections.Immutable`          | `ImmutableArray`, `ImmutableDictionary`, `ImmutableList`, `ImmutableQueue` | Escenaris on el contingut de la col·lecció original no canviarà mai. Es poden crear col·leccions modificades com una nova instància. |
# Diagrama de classes
![image](https://github.com/user-attachments/assets/c25d1098-b936-4368-9524-651a67b36c2d)
# Selecció de la col·lecció a utilitzar
## Llistes
✔️ Volem controlar l'ordre dels ítems. Cada ítem de la llista té associat un índex (igual que un array).  
✔️ Podem inserir elements en qualsevol lloc de la llista. Els índexos afectats es recalculen.  
## Diccionaris
✔️ Associació d'un valor clau a cada element.  
✔️ Podem trobar de forma eficient l'element sabent la clau.  
✔️ La clau ha de ser única per a cada col·lecció.  
## Piles (Stacks)
✔️ Last In First Out (LIFO). L'últim element introduït és l'únic que tenim accés de forma directe. Per exemple, si volem permetre que l'aplicació implementi opció de desfer les accions de l'usuari (CTRL+Z).  
## Cues (Queue)
✔️ First In First Out (FIFO). El primer element introduït és l'únic que tenim accés de forma directe. Per exemple, una cua d'accions que cal executar.
## Conjunts (Sets)  
✔️ Útil quan es vol treballar amb dues col·leccions. Per exemple, trobar elements repetits a les dues col·leccions (intersecció).
✔️ Els elements d'un conjunt han de ser únics.

