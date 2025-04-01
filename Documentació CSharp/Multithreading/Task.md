# Multithreading amb la classe Task
| **Forma**                         | **Execució immediata** | **Control**       | **Recomanada per a**                      |
|----------------------------------|-------------------------|-------------------|--------------------------------------------|
| `new Task(...).Start()`          | ❌ No                  | ✅ Molt control   | Casos on vols retardar l'inici manualment |
| `Task.Factory.StartNew(...)`     | ✅ Sí                  | ✅ Opcions extra  | Casos avançats (opcions, custom schedulers) |
| `Task.Run(...)`                  | ✅ Sí                  | ❌ (simplificada) | ✅ Ús general, més clara i segura         |
Es recomana utilitzar Task.Run(...) per la majoria de casos!  
## `new Task(...).Start()`
Permet preparar la tasca i decidir quan l'executarem.
```csharp
using System;
using System.Threading.Tasks;

void MethodA() => Console.WriteLine("Task A");

Task taskA = new Task(MethodA);
taskA.Start();
```
## `Task.Factory.StartNew(...)` 
Té opcions més avançades, però complica el codi. Només s'ha d'utilitzar quan estigui justificat. 
```csharp
using System;
using System.Threading.Tasks;

void MethodB() => Console.WriteLine("Task B");

Task taskB = Task.Factory.StartNew(MethodB);
```
## `Task.Run(...)` 
No permet preparar la tasca abans de la seva execució
```csharp
using System;
using System.Threading.Tasks;

void MethodC() => Console.WriteLine("Task C");

Task taskC = Task.Run(() => MethodC());
```
