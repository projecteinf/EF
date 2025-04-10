# API (Application Porgramming Interface)  
Sistema d'intercanvi d'informació a través de tecnologies web (http).
## Característiques
- No hi ha interfície d'usuari.  
- Simples i eficients.

# SOA
SOA is essentially a collection of services, those services communicate with each other, and a service is an operation or a function that is well defined, self-contained, and independent of other service contexts and states. Services are applications hosted on application servers and interact with other applications through interfaces.  
SOA is not a technology or a programming language; it's a set of principles, procedures, and methodologies to develop a software application.  

# Què és ROA (Resource-Oriented Architecture)?

**ROA** és un estil d’arquitectura per dissenyar serveis web, especialment aquells que segueixen els principis de **REST** (Representational State Transfer).

## Què és REST?

**REST** és un conjunt de principis arquitectònics definits per Roy Fielding que descriuen com hauria de ser la comunicació entre sistemes en una arquitectura distribuïda com la web.

Una **API RESTful** és una API que segueix els principis de REST, com:

- Comunicació sense estat (stateless)
- Utilització dels verbs HTTP estàndard (`GET`, `POST`, `PUT`, `DELETE`)
- Recursos identificats per URIs
- Representacions dels recursos (generalment en JSON o XML)

## Principis bàsics de ROA

1. **Recursos com a entitats clau**  
   Tot allò que es pot gestionar (usuaris, productes, comandes...) es considera un **recurs**.

2. **URI per a cada recurs**  
   Cada recurs té una adreça única (endpoint) com ara:  
   `https://api.exemple.com/usuaris/123`

3. **Operacions via mètodes HTTP**  
   Les accions sobre els recursos es fan mitjançant verbs HTTP:
   - `GET` – llegir informació
   - `POST` – crear un recurs nou
   - `PUT` – actualitzar un recurs existent
   - `DELETE` – eliminar un recurs

4. **Representació del recurs**  
   El recurs no és un objecte en si, sinó la seva **representació** (normalment JSON o XML).

## Relació entre ROA i API

Una **API** és una interfície que permet la comunicació entre aplicacions. Quan parlem d’una **API RESTful**, estem parlant d’un tipus d’API que segueix el model ROA.

Per tant, **ROA defineix l'estil estructural** per construir una API RESTful: cada acció sobre dades es mapeja a un endpoint i un mètode HTTP.

## Exemple d’endpoints ROA dins d’una API RESTful

### Recurs: `usuaris`

| Operació       | Mètode HTTP | Endpoint                  | Descripció                           |
|----------------|-------------|---------------------------|---------------------------------------|
| Llistar        | GET         | `/usuaris`                | Obtenir tots els usuaris             |
| Consultar      | GET         | `/usuaris/123`            | Obtenir un usuari concret            |
| Crear          | POST        | `/usuaris`                | Crear un nou usuari                  |
| Actualitzar    | PUT         | `/usuaris/123`            | Actualitzar les dades de l’usuari    |
| Eliminar       | DELETE      | `/usuaris/123`            | Esborrar un usuari                   |


# Esquema estructura
![Esquema estructura](https://github.com/user-attachments/assets/7b66e275-fc7e-475f-88b8-40456b5a9397)
