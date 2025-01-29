# Nomenclatura events

✅ Els esdeveniments han de tenir un nom que sigui un verb o una frase verbal.

**Exemple:**
```csharp
public event EventHandler Clicked;
public event EventHandler Painting;
public event EventHandler DroppedDown;
```

✅ Els noms dels esdeveniments han de reflectir accions abans i després d’un esdeveniment, utilitzant temps present i passat.

**Exemple:**
```csharp
// CORRECTE
public event EventHandler Closing; // Abans de tancar
public event EventHandler Closed;  // Després de tancar
```

❌ No utilitzis prefixos o sufixos "Before" o "After". En el seu lloc, utilitza els temps verbals adequats.

**Exemple:**
```csharp
// INCORRECTE
public event EventHandler BeforeClose; 
public event EventHandler AfterClose;  
```

✅ Els delegats utilitzats com a tipus d’esdeveniments han de tenir el sufix "EventHandler".

**Exemple:**
```csharp
// CORRECTE
public delegate void ClickedEventHandler(object sender, ClickedEventArgs e);
```

✅ Els gestors d'esdeveniments han de tenir dos paràmetres:

    sender: Representa l'objecte que genera l'esdeveniment.
    e: Conté les dades de l'esdeveniment.

**Exemple:**
```csharp
// CORRECTE
public void Button_Clicked(object sender, EventArgs e) { }
```

✅ Les classes que representen arguments d’esdeveniments han d’acabar amb "EventArgs".

**Exemple:**
```csharp
// CORRECTE
public class ClickedEventArgs : EventArgs
{
    public int ClickCount { get; set; }
}
```
