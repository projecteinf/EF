# Delegates

Per a cridar un mètode podem utilitzar el "." . Per exemple: Console.WriteLine("...");
Una altra forma de cridar a un mètode és mitjançant una delegació.

# Hola món utilitzant delegació

```CSharp
using System;
using static System.Console;

class Program
{
    // 1. Definim un delegate
    delegate void MyDelegate(string message);

    // 2. Creem un mètode compatible amb el delegate
    static void PrintMessage(string message)
    {
        WriteLine("Missatge: " + message);
    }

    static void Main()
    {
        // 3. Declarem una variable del tipus delegate i l'assignem a un mètode
        MyDelegate del = PrintMessage;

        // 4. Invoquem el delegate com si fos un mètode
        del("Hola, món!");
    }
}

```

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

## Versió amb classes i asíncron

```CSharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class TaskQueue
{
    // Definim el delegat per a tasques asíncrones
    private delegate Task AsyncTaskDelegate();

    // Cua de tasques
    private Queue<AsyncTaskDelegate> taskQueue = new Queue<AsyncTaskDelegate>();

    // Mètode per afegir una tasca a la cua
    public void Enqueue(Func<Task> task)
    {
        taskQueue.Enqueue(() => task()); // Convertim Func<Task> a AsyncTaskDelegate
    }

    // Mètode per processar totes les tasques en ordre
    public async Task ProcessQueueAsync()
    {
        while (taskQueue.Count > 0)
        {
            var task = taskQueue.Dequeue();
            await task();
        }
    }
}

class Program
{
    static async Task Main()
    {
        // Creem una instància de la cua de tasques
        TaskQueue queue = new TaskQueue();

        // Afegim tasques a la cua
        queue.Enqueue(ValidateDataAsync);
        queue.Enqueue(ProcessTransactionAsync);
        queue.Enqueue(SendNotificationAsync);

        // Processem les tasques en ordre
        await queue.ProcessQueueAsync();
    }

    static async Task ValidateDataAsync()
    {
        WriteLine("Validant les dades...");
        await Task.Delay(1000);
        WriteLine("Dades validades.");
    }

    static async Task ProcessTransactionAsync()
    {
        WriteLine("Processant la transacció...");
        await Task.Delay(2000);
        WriteLine("Transacció completada.");
    }

    static async Task SendNotificationAsync()
    {
        WriteLine("Enviant notificació...");
        await Task.Delay(500);
        WriteLine("Notificació enviada.");
    }
}

```