# Default interfaces
## Motivació
Els mètodes d'interfície predeterminats permeten a un autor d'API afegir mètodes a una interfície en futures versions sense trencar la compatibilitat amb les implementacions existents d'aquesta interfície.
## Exemple
```CSharp
public interface ILogger
{
    void Log(string message);

    // Nou mètode afegit a la interfície sense trencar implementacions anteriors
    void LogWarning(string message)
    {
        // Implementació buida (no-op)
    }
}
```
En la classe on s'implementi la interfície podem sobreescriure el mètode LogWarning per tal d'habilitar-ne la funcionalitat per la nova versió.
## Limitacions
- ❌ No pots definir camps (fields) en una interfície perquè això implicaria estat.
- ❌ No pots accedir a this en un default interface method perquè la interfície no té estat. Excepte per a cridar altres mètodes implementats en la classe o a altres default interfaces.
```CSharp
public interface IExample
{
    int Counter { get; set; }

    void Increment()
    {
        this.Counter++; // ❌ ERROR: No pots accedir a `this.Counter` perquè la interfície no té estat.
    }
}
```
```CSharp
public interface IExample
{
    int Counter { get; set; }

    void Increment()
    {
        SetCounter(GetCounter() + 1); // ✅ Correcte si la classe té aquestes implementacions
    }
    // Obligem a la classe a implementar els mètodes que s'utilitzen en la sentència anterior.
    int GetCounter(); 
    void SetCounter(int value); 
}

```