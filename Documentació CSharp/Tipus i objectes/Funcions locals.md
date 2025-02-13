# Definició

C# permet declarar una funció dins un mètode. Totes les variables locals del mètode són accessibles dins la funció i la funció pot modificar el seu valor. Podem declarar la funció en qualsevol lloc del mètode, però per la llegibilitat es recomana fer-ho al principi o al final del codi.

## Exemple

```CSharp
void Exemple()
{
    int x = 10;
    
    // Funció local que modifica la variable x
    void FuncioLocal()
    {
        x = x + 5;
    }

    FuncioLocal();
    Console.WriteLine(x);  // Sortida: 15
}
```

