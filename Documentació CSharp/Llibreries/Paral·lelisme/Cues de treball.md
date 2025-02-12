# 📌 Col·leccions i Classes de Paral·lelisme en C#

C# ofereix diverses **estructures de dades i eines per a la concurrència i el paral·lelisme**. Aquí tens una **llista categoritzada** amb la seva funcionalitat.

---


## **🔹  Cues de Treball (`System.Threading.Channels`)**
Més modernes i eficients que `BlockingCollection<T>`, ideals per a cues de treball.

| **Classe**                   | **Descripció** |
|------------------------------|---------------|
| **`Channel<T>`**             | Proporciona una cua segura per `threads`, amb suport per `await`. |
| **`BoundedChannel<T>`**      | Cua limitada que bloqueja quan arriba al límit de capacitat. |
| **`UnboundedChannel<T>`**    | Cua sense límit de capacitat. |

