# **🔹 4. Paral·lelisme de dades (`System.Threading.Tasks.Dataflow`)**
Col·leccions optimitzades per a **fluxos de dades**.

| **Classe**                   | **Descripció** |
|------------------------------|---------------|
| **`BufferBlock<T>`**         | Emmagatzema missatges i els emet quan un receptor els demana. |
| **`BroadcastBlock<T>`**      | Reenvia un missatge a múltiples receptors. |
| **`ActionBlock<T>`**         | Executa una acció sobre cada element rebut. |
| **`TransformBlock<TInput,TOutput>`** | Processa dades en paral·lel i retorna un resultat. |
| **`TransformManyBlock<TInput,TOutput>`** | Igual que `TransformBlock`, però cada entrada pot generar múltiples sortides. |
| **`BatchBlock<T>`**          | Agrupa elements en lots abans d'enviar-los al següent bloc. |

