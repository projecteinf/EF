# CONSOLA  
📂 Consola
 ├── 📂 Data  → (Capa de persistència - EF)
 │    ├── AppDbContext.cs
 │    ├── User.cs
 │    ├── Item.cs
 │    ├── Compra.cs
 │
 ├── 📂 Services  → (Capa de negoci 🔥)
 │    ├── UserService.cs   👈 Lògica d’usuaris
 │    ├── CompraService.cs 👈 Lògica de compres
 │    ├── ItemService.cs   👈 Lògica d’ítems
 │
 ├── 📂 DTOs  → (Models per transferència de dades)
 │    ├── UserDto.cs
 │    ├── CompraDto.cs
 │    ├── ItemDto.cs
 │
 ├── 📂 UI  → (Interfície de línia de comandes)
 │    ├── Menu.cs  👈 Mostra opcions a l’usuari
 │
 ├── Program.cs  → (Punt d’entrada)

# API  
📂 ProjecteAPI
 ├── 📂 Data  → (Capa de persistència - EF)
 │    ├── AppDbContext.cs
 │    ├── User.cs
 │    ├── Item.cs
 │    ├── Compra.cs
 │
 ├── 📂 Services  → (Capa de negoci 🔥)
 │    ├── UserService.cs   👈 Lògica d’usuaris
 │    ├── CompraService.cs 👈 Lògica de compres
 │    ├── ItemService.cs   👈 Lògica d’ítems
 │
 ├── 📂 DTOs  → (Transferència de dades)
 │    ├── UserDto.cs
 │    ├── CompraDto.cs
 │    ├── ItemDto.cs
 │
 ├── 📂 Controllers  → (Capa de presentació - API)
 │    ├── UsersController.cs
 │    ├── CompraController.cs
 │    ├── ItemController.cs
