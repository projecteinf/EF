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
