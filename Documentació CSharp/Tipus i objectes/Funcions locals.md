# Funcions locals
## Definició

C# permet declarar una funció dins un mètode. Totes les variables locals del mètode són accessibles dins la funció i la funció pot modificar el seu valor. Podem declarar la funció en qualsevol lloc del mètode, però per la llegibilitat es recomana fer-ho al principi, després de la declaració de les variables, o al final del codi.

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

## Funcions locals vs mètodes privats

1. Claredat i mantenibilitat: Permeten que el codi sigui més llegible, evitant la creació de mètodes privats que potser només es necessiten dins d’un context molt restringit. Això fa que el codi sigui més fàcil de seguir.

2. Visibilitat limitada: Les funcions locals només són accessibles dins del mètode on es defineixen, mentre que un mètode privat és accessible dins de tota la classe. Això ajuda a evitar exposar funcionalitat que no es vol que sigui reutilitzada o testejada fora del seu context.

3. Facilitat per a closures: Les funcions locals poden capturar variables locals en el seu àmbit, oferint més flexibilitat que els mètodes privats tradicionals, que no poden fer-ho tan directament.

4. Millora del rendiment

    - Funcions locals: No requereixen que el compilador creï un mètode separat i que aquest mètode tingui un cicle de vida que pot ser més costós (p. ex., invocar-lo repetidament). Les funcions locals es mantenen dins de l'àmbit de l'execució immediata i desapareixen després de l'execució.

    - Mètodes addicionals: Tot i que no tenen una gran sobrecàrrega, sempre hi ha un cost associat a la seva definició i a la seva invocació (sobretot si la crida al mètode es fa repetidament en un bucle o amb un nombre alt d'invocacions).

        No s'aconsegueix un gran guany a nivell de rendiment, però és important si es vol un codi altament optimitzat.