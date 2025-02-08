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

# Emmagatzematge de múltiples valors

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

## Funcionament

La taula d'assignacions segons l'enum EtapaEducativa és:

|Universitat|CicleFormatiuGrauSuperior|CicleFormatiuGrauMig|Secundària|Infantil|Primària|NoEstudis|
|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
|128|64|32|16|8|4|2|1|
|0|0|0|1|1|1|0|

Convertim el número binari 0001110 (1110) a decimal 14 . És el valor que es guardarà a la variable de tipus Enum.

```Csharp
    EtapaEducativa etapaEducativa = EtapaEducativa.Primària | EtapaEducativa.Infantil | EtapaEducativa.Secundària;
    WriteLine($"Estudis {etapaEducativa} , Valor: {(int) etapaEducativa}");
```

**Resultat execució**
Estudis Primària, Infantil, Secundària , Valor: 14

# Good practice

Utilitza valors enum per a emmagatzemar combinacions d'opcions discretes.
- 8 opcions -> byte 
- 16 opcions -> short 
- 32 opcions -> int
- 64 opcions -> long

