# Delegates

Per a cridar un mètode podem utilitzar el "." . Per exemple: Console.WriteLine("...");
Una altra forma de cridar a un mètode és mitjançant una delegació.

# Exemple: Cua de tasques amb delegates

## Versió simple síncrona i sense utilitzar classes

```CSharp
using System;
using static System.Console;
using System.Collections.Generic;

class Program
{
    // Definim un delegat per les accions de la cua
    delegate void TaskDelegate();

    static void Main()
    {
        // Creem una cua de mètodes
        Queue<TaskDelegate> taskQueue = new Queue<TaskDelegate>();

        // Afegim diferents tasques a la cua
        taskQueue.Enqueue(ValidateData);
        taskQueue.Enqueue(ProcessTransaction);
        taskQueue.Enqueue(SendNotification);

        // Executem les tasques en ordre
        while (taskQueue.Count > 0)
        {
            TaskDelegate task = taskQueue.Dequeue();
            task();  // Executa la funció
        }
    }

    static void ValidateData()
    {
        WriteLine("Validant les dades...");
    }

    static void ProcessTransaction()
    {
        WriteLine("Processant la transacció...");
    }

    static void SendNotification()
    {
        WriteLine("Enviant notificació...");
    }
}

```
