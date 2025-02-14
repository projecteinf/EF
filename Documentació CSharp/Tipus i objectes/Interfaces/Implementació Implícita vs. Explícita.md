# Implementació Implícita vs. Explícita

Diverses interfícies requereixen la implementació d'un mètode. Tenim una classe que hereda de dues o més interfícies. Podem utlitzar una implementació explícita o implícita per a definir l'acció del mètode. 

## Exemple - Implementació Implícita

```CSharp
using System;

interface IEnemic
{
    void Moure();
}

interface IObjecte
{
    void Moure();
}

class Item : IEnemic, IObjecte
{
    // Implementació implícita (s'aplica a IEnemic, IObjecte)
    public void Moure()
    {
        this.Posicio += Moviment;        
    }
}

class Program
{
    static void Main()
    {
        Item item = new Item();
        item.Moure(); 
    }
}

```

## Exemple - Implementació Explícita

```CSharp
using System;

interface IEnemic
{
    void Moure();
}

interface IObjecte
{
    void Moure();
}

class Item : IEnemic, IObjecte
{
    // Implementació implícita (s'aplica a IEnemic, IObjecte)
    public void Moure()  // Implementació Implícita
    {
        this.Posicio += Moviment;        
    }

    public void IEnemic.Moure() // Implementació Explícita
    {
        this.Posicio += (Moviment * Velocitat);    
    }
}

class Program
{
    static void Main()
    {
        Item itemObjecte = new Item();
        itemObjecte.Moure(); // Moviment associat a IObject

        Item itemEnemic = new Item();
        ((IEnemic)itemEnemic).Moure(); // Moviment associat a IEnemic -> Incrementat amb la velocitat
        
    }
}

```