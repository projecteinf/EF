```CSharp
using System;
using static System.Console;

class Publisher
{
    // Definim un delegat per a l'esdeveniment
    public delegate void TaskCompletedEventHandler(string message);

    // Declarem l'esdeveniment basat en el delegat
    public event TaskCompletedEventHandler? TaskCompleted;

    public void RunTask()
    {
        WriteLine("Executant tasca...");
        System.Threading.Thread.Sleep(2000); // Execució de codi propi de la tasca 
        OnTaskCompleted("La tasca s'ha completat correctament!");
    }

    // Mètode per disparar l'esdeveniment
    protected virtual void OnTaskCompleted(string message)
    {
        // Verifiquem si hi ha algun subscriptor abans de cridar l'event
        TaskCompleted?.Invoke(message);
    }
}

class Subscriber
{
    public void OnTaskCompletedHandler(string message)
    {
        WriteLine($"Rebut notificació: {message}");
    }
}

class Program
{
    static void Main()
    {
        Publisher publisher = new Publisher();
        Subscriber subscriber = new Subscriber();

        // El subscriber s'inscriu a l'esdeveniment
        publisher.TaskCompleted += subscriber.OnTaskCompletedHandler;

        // Executem la tasca que eventualment dispararà l'esdeveniment
        publisher.RunTask();
    }
}
```
