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
# Quan utlitzar-lo
Quan treballem amb struct "grans".  
🔹 Els struct són per valor i, normalment, el seu pas és per valor. Per tant, es fa una còpia de la informació cada vegada que es passa per paràmetre o es modifica. La còpia té una penalització en el sistema.  
```CSharp
struct Punt
{
    public int X, Y;
}

class Program
{
    static void Modifica(Punt p)
    {
        p.X = 100; // ❌ Això modifica una còpia!
    }

    static void Main()
    {
        Punt p = new Punt { X = 1, Y = 2 };
        Modifica(p);
        Console.WriteLine(p.X); // 🔴 Mostra "1", perquè `struct` es passa per valor!
    }
}
```
🔹 Amb Span<T> podem evitar que es facin còpies de la informació quan aquesta s'envia com a paràmetre o es modifica. Es passa un punter de memòria associat a la informació original (no còpia).    
```CSharp
struct Punt
{
    public int X, Y;
}

class Program
{
    static void Modifica(Span<Punt> punts)
    {
        punts[0].X = 100; // ✅ Modifica l'original!
    }

    static void Main()
    {
        Punt[] array = { new Punt { X = 1, Y = 2 } };
        Span<Punt> span = array; // ✅ No hi ha còpia
        Modifica(span);

        Console.WriteLine(array[0].X); // 🟢 Mostra "100"!
    }
}
```
🔹 Tot i que la recomanació sigui la de no superar els 16 bytes en estructures (struct) és una recomanació! Si ho fem cal tenir en compte fer-ne un ús eficient utilitzant Span i evitar d'aquesta forma la còpia de dades per a cada modificació (sobretot si se'n fan moltes).
```CSharp
struct GranStruct
{
    public double A, B, C, D; // 32 bytes
}

class Program
{
    static void Modifica(Span<GranStruct> structs)
    {
        structs[0].A = 99.9; // ✅ Modifica directament sense copiar
    }

    static void Main()
    {
        GranStruct[] array = new GranStruct[1000]; // 🟢 No hi ha heap allocation
        Span<GranStruct> span = array; // ✅ Referència sense copiar
        Modifica(span);

        Console.WriteLine(array[0].A); // 🟢 Mostra "99.9"
    }
}
```
