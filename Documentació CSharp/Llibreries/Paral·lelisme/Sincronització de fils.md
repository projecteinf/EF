# 📌 Col·leccions i Classes de Paral·lelisme en C#

C# ofereix diverses **estructures de dades i eines per a la concurrència i el paral·lelisme**. Aquí tens una **llista categoritzada** amb la seva funcionalitat.

---

## **🔹  Sincronització de fils (`System.Threading`)**
Classes per controlar l’accés als recursos compartits.

| **Classe**                   | **Descripció** |
|------------------------------|---------------|
| **`Mutex`**                  | Permet bloquejos entre múltiples processos i fils. |
| **`Semaphore`**              | Controla el nombre màxim de fils que poden accedir a un recurs simultàniament. |
| **`SemaphoreSlim`**          | Versió lleugera de `Semaphore` per ús dins d'un sol procés. |
| **`Monitor`**                | Ofereix funcionalitats avançades de bloqueig i sincronització. |
| **`SpinLock`**               | Bloqueig eficient per a operacions curtes en entorns d’alt rendiment. |
| **`AutoResetEvent`**         | Permet que un `thread` suspès es desperti quan un altre li envia un senyal. |
| **`ManualResetEvent`**       | Com `AutoResetEvent`, però es manté actiu fins que es reinicialitza manualment. |

