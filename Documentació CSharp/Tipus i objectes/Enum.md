# Enum
- Valors dins d'un conjunt
- Forma eficient d'emmagatzemar un o varis valors

```CSharp

public enum EtapaEducativa
{
    NoEstudis,
    Primària,
    Infantil,
    Secundària,
    Batxillerat,
    CicleFormatiuGrauMig,
    CicleFormatiuGrauSuperior,
    Universitat
}

public class Person
{
    private string _name; 
    private EtapaEducativa _estudis;    // Tot i no ser un array, podem emmagatzemar múltiples valors!

    public string Name  
    {
        get { return _name; }
        set { _name = value; }
    }


    public EtapaEducativa Estudis  
    {
        get { return _estudis; }
        set { _estudis = value; }
    }

}

```

Emmagatzemar múltiples valors

```CSharp
[System.Flags]
public enum EtapaEducativa : byte // Utilitzem un byte per a emmagatzemar els valors de l'enum
{
    NoEstudis = 0b_0000_0001, // 1
    Primària = 0b_0000_0010, // 2
    Infantil = 0b_0000_0100, // 4
    Secundària = 0b_0000_1000, // 8
    Batxillerat = 0b_0001_0000, // 16
    CicleFormatiuGrauMig = 0b_0010_0000 // 32
    CicleFormatiuGrauSuperior = 0b_0100_0000 // 64
    Universitat = 0b_1000_0000 // 128
}
```


| 128 | 64 | 32 | 16 | 8 | 4 | 2 | 1 |
|  0  |  1 |  1 | 0  | 1 | 1 | 1 | 0 | 
