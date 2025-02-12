# 📌 Col·leccions i Classes de Paral·lelisme en C#

C# ofereix diverses **estructures de dades i eines per a la concurrència i el paral·lelisme**. Aquí tens una **llista categoritzada** amb la seva funcionalitat.


## **🔹  Tasques i paral·lelisme (`System.Threading.Tasks`)**
Classes per executar codi en paral·lel de manera eficient.

| **Classe**                   | **Descripció** |
|------------------------------|---------------|
| **`Task`**                   | Representa una operació asíncrona o en segon pla que es pot esperar (`await`). |
| **`Task<TResult>`**          | Versió de `Task` que retorna un resultat (`Result`). |
| **`Parallel`**               | Proporciona operacions com `Parallel.For` i `Parallel.ForEach` per executar bucles en paral·lel. |
| **`TaskFactory`**            | Crea i gestiona `Tasks`, útil quan es requereixen opcions personalitzades de creació. |

