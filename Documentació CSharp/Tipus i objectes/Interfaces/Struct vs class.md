# Struct vs class
La funcionalitat que ens aporten un struct i un class és la mateixa. Per tant, cal pendre una decisió de quina de les dues opcions escollir per a cada situació. 
## Característiques
Struct utilitza un sistema de memòria més eficient per a gestionar la informació, però de mida més limitada ( ulimit -a # valor associat a stack size ) que les classes.  
## Recomanacions 
Struct, tot i que per defecte no és immutable, es recomana implementar-lo com a immutable per tal d'evitar modificacions inesperades.  
```CSharp
public struct Posicio
{
    public int X;
    public int Y;

    public void Desplaçar(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
}

static void Main()
{
    Posicio pos1 = new Posicio { X = 10, Y = 20 };
    Posicio pos2 = pos1; // 🔴 Aquí es copia el valor, no es comparteix la mateixa instància

    pos2.Desplaçar(5, 5); // 🔴 Modifica la còpia, no `pos1`. Amb classes es modificarien els dos, ja que hem assignat la mateixa referència a l'objecte.

    Console.WriteLine($"pos1: {pos1.X}, {pos1.Y}"); // ❌ Sortida: 10, 20 (NO s'ha modificat)
    Console.WriteLine($"pos2: {pos2.X}, {pos2.Y}"); // ✅ Sortida: 15, 25 (modificat)
}
```
No es recomana utilitzar struct si la mida de la informació que s'hi vol emmagatzemar és superior a 16 bytes.  
No es recomana utilitzar struct que continguin propietats associades a altres classes: pas de paràmetres diferent pot portar a un funcionament del programa inesperat i de difícil depuració.  
## 📌 Quan utilitzar `struct` o `class` en C#

| **Cas**             | **Usa `struct`**                                      | **Usa `class`**                                       |
|---------------------|------------------------------------------------------|------------------------------------------------------|
| **Mida total**      | ≤ 16 bytes                                           | > 16 bytes                                           |
| **Tipus de dades**  | Només tipus valor (`int`, `double`, etc.)            | Conté tipus referència (`string`, `object`)         |
| **Còpia per valor o referència?** | Necessites copiar dades sovint i evitar referències compartides | Necessites passar-lo per referència per compartir estat |
| **Herència**        | No necessites herència ni polimorfisme                | Necessites derivació (`class BasePais : Pais`)      |
| **Canvis futurs**   | L'estructura no canviarà molt                        | Pot necessitar nous camps i mètodes més endavant    |
| **Col·leccions**    | Es crea en grans quantitats i vols optimitzar memòria (evitant el `heap`) | Sovint es treballarà amb llistes o estructures de dades grans |
## Exemple d'utilització struct (immutable)
```CSharp
public struct Posicio
{
    public readonly int X;
    public readonly int Y;

    public Posicio(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Retorna una nova instància amb la nova posició
    public Posicio Desplaçar(int dx, int dy)
    {
        return new Posicio(X + dx, Y + dy);
    }
}

static void Main()
{
    Posicio pos1 = new Posicio(10, 20);
    Posicio pos2 = pos1.Desplaçar(5, 5); // ✅ Genera un nou `struct`

    Console.WriteLine($"pos1: {pos1.X}, {pos1.Y}"); // ✅ Sortida: 10, 20 (NO modificat)
    Console.WriteLine($"pos2: {pos2.X}, {pos2.Y}"); // ✅ Sortida: 15, 25 (nou valor)
}
```
