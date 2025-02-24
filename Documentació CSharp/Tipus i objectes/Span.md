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
