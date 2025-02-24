# Span
Span és una estructura que fa ús de la memòria stack. Per tant, és un mètode eficient per a gestionar informació en memòria. Com que span utilitza la memòria stack, no podem utilitzar classes i estem limitats a 16 Bytes d'informació. Per tant, el seu ús és per a casos molt particulars.
## Característiques i imitacions
✅ Span<T> és útil per a dades petites i contínues (arrays, stackalloc, strings). No serveix per a grans conjunts de dades (millor Memory<T>).  
✅ És molt eficient perquè evita còpies innecessàries de memòria. Treball eficient a l'stack.  
❌ No es pot emmagatzemar a heap (no podem utilitzar-lo en classes. En tot cas, struct).  
❌ No es pot encapsular en object, interface o dynamic.  
```CSharp
class Persona { public string Nom; }
Span<Persona> span = new Persona[3]; // ❌ ERROR, no es pot fer servir amb classes!
```
```CSharp
struct MyStruct { public int X, Y; }
Span<MyStruct> span = new MyStruct[3]; // Funciona perfectament!
```
❌ No es pot passar entre threads.  
❌ Té un límit de memòria a l'stack.  
## Comparativa entre Span<T> i punters de llenguatge C
| Característica          | Punter en C (`int*`) | `Span<T>` en C# |
|------------------------|----------------------|-----------------|
| **Tipus de memòria** | Pot apuntar a qualsevol lloc (stack, heap, global, unsafe) | Només a dades segures (stack, heap via `Memory<T>`) |
| **Límit de seguretat** | No controla si surt dels límits | Té límits de seguretat interns |
| **Accés a heap** | Pot apuntar a heap directament | Necessita `Memory<T>` per accedir a heap |
| **Multi-threading** | Pot passar-se entre fils | `Span<T>` no es pot passar entre fils |
| **Seguretat** | Pot provocar *segmentation faults* | Tipus-safe, sense *buffer overflows* |
| **Conversió a objecte** | Pot convertir-se fàcilment (`void*`) | No es pot encapsular en `object` |
