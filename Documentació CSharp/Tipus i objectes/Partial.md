# Partial

La paraula reservada "partial" ens permet dividir una classe en diferents fitxers. Aquesta divisió és generalment important, quan es dóna alguna de les situacions següents

1. Separació de codi generat automàticament i codi personalitzat. 
    Quan hi ha una actualització del framework o de l'eina que genera el codi, podem substituir tot el codi de la classe parcial pel nou codi generat sense necessitat de preocupar-nos per les personalitzacions que hem introduït: estaran en un altre fitxer.

2. Treball en equip en grans projectes / Organització de classes molt grans
    Cada programador treballa en un fitxer diferent implementant una funcionalitat concreta de la classe. 
    Reducció del número de conflictes en la gestió de versions (git)

```CSharp
// Tramitació de comanda
// Fitxer: Comanda/Tramitació.cs

namespace BoscComa.ERP
{
    public partial class Comanda
    {
    }
}

// Comptabilització de comandes
// Fitxer: Comanda/Comptabilització.cs

namespace BoscComa.ERP
{
    public partial class Comanda
    {
    }
}
```

