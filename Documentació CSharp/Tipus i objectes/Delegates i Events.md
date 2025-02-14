# Events

Un mètde és una acció que un objecte pot fer sobre si mateix o a un objecte relacionat. Un event és una acció que passa a un objecte. Els events ens permeten també **intercanviar missatges entre objectes**.

La gestió d'events es basa en l'ús de delegats.

# Delegats predefinits

Microsoft ha predefinit dos delegats per a utilitzar en la gestió d'events.

```CSharp
public delegate void EventHandler(object sender, EventArgs e);
public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
```

