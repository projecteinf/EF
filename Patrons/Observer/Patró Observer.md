# Patró observer

Per a implementar el patró observer tenim les llibreries

```CSharp
public delegate void EventHandler(object sender, EventArgs e);
public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
```

La diferència entre ambdós és que la segona ens permet definir TEventArgs, per tant, els arguments que volem associar a l'event. La classe TEventArgs ha de ser derivada de EventArgs.

```CSharp
class MyEventArgs : EventArgs
{
    public string Message { get; }

    public MyEventArgs(string message)
    {
        Message = message;
    }
}
```

# Exemple patró Observer utilitzant EventHandle

```CSharp
using System;
using static System.Console;

class Publisher
{
    public event EventHandler? SomethingHappened;

    public void DoSomething()
    {
        WriteLine("El subjecte fa alguna cosa...");
        OnSomethingHappened();
    }

    protected virtual void OnSomethingHappened()
    {
        // Notifica tots els observadors (subscriptors)
        SomethingHappened?.Invoke(this, EventArgs.Empty);
    }
}

class Subscriber
{
    private string _name;

    public Subscriber(string name)
    {
        _name = name;
    }

    public void HandleEvent(object sender, EventArgs e)
    {
        WriteLine($"{_name} ha rebut la notificació!");
    }
}

class Program
{
    static void Main()
    {
        Publisher publisher = new Publisher();

        // Creem múltiples observadors
        Subscriber sub1 = new Subscriber("Observador 1");
        Subscriber sub2 = new Subscriber("Observador 2");

        // Els observadors es registren a l'esdeveniment
        publisher.SomethingHappened += sub1.HandleEvent;
        publisher.SomethingHappened += sub2.HandleEvent;

        // El subjecte fa alguna cosa i dispara l'esdeveniment
        publisher.DoSomething();
    }
}
```

