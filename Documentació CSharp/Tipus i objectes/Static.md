# Tipus i membres static

Utilitzem tipus statics quan no és necessari crear objectes de la classe: tots els objectes comparteixen els mateixos valors pels camps i, per tant, no cal diferenciar-los entre ells.

Tots els membres d'una classe estàtica també han de ser estàtics.

## Exemple

En una aplicació podem definir els paràmetres per defecte del sistema utilitzant un tipus estàtic.

```CSharp
public static class SystemParameters { 
    public static string DefaultCurrency { get; set; } = "EUR";
    public static short NumberOfDecimals { get; set; } = "3";
    public static string FormatDate(DateTime date) {
        return date.ToString("yyyy-MM-dd");
    }
}
```

El membre FormatDate el podríem també definir en una classe Helper pròpia

```CSharp
public static class DateHelper {  
    public static string FormatDate(DateTime date) {
        return date.ToString("yyyy-MM-dd");
    }
}
```

