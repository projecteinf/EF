# **🔹  Col·leccions concurrents (`System.Collections.Concurrent`)**
Col·leccions segures per a l’accés des de múltiples `threads` sense necessitat de bloquejos explícits (`lock`).

| **Classe**                   | **Descripció** |
|------------------------------|---------------|
| **`ConcurrentQueue<T>`**      | Implementa una cua FIFO (`First-In, First-Out`). Ideal per a processament en **background** o tasques pendents. |
| **`ConcurrentStack<T>`**      | Implementa una pila LIFO (`Last-In, First-Out`). Útil per a escenaris on l’últim element afegit és el primer que es necessita. |
| **`ConcurrentBag<T>`**        | Una col·lecció desordenada segura per a múltiples `threads`, on cada `thread` pot afegir elements sense bloquejos. No garanteix ordre. |
| **`ConcurrentDictionary<K,V>`** | Diccionari segur per a accés concurrent. Permet operacions atòmiques (`AddOrUpdate()`, `TryGetValue()`, etc.). |
| **`BlockingCollection<T>`**   | Una col·lecció que permet bloquejos i límits de capacitat, sovint usada amb `ConcurrentQueue<T>` o `ConcurrentBag<T>` per a control de flux de dades. |

---

