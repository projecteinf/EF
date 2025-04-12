# Comparació: Microserveis vs API
Aquest document recull les diferències i relació entre microserveis i APIs, dos conceptes fonamentals en el desenvolupament de sistemes moderns.  
---
## 🔧 Què és una API?  
- Una **API** (Application Programming Interface) és una interfície que permet comunicar-se amb un sistema o servei.  
- Pot existir en qualsevol arquitectura: monolítica, SOA, microserveis, etc.  
- Exposa funcionalitats de forma estructurada (normalment via HTTP/REST, GraphQL, gRPC...).  

> Exemple: `GET /usuaris` retorna la llista d’usuaris d’un sistema.  
---
## 🧱 Què és un microservei?  
- Un **microservei** és una unitat funcional petita i independent dins d’una arquitectura distribuïda.  
- Cada microservei fa una funció concreta (com gestionar usuaris, enviar notificacions...).  
- Té la seva pròpia base de dades, cicle de vida i deploy.  
- Es comunica amb altres microserveis mitjançant una API.  
> Exemple: El microservei de comandes gestiona tot el flux de compra i exposa `POST /comandes`.  
---
## 🔁 Relació entre microserveis i APIs  
Els microserveis **exposen APIs** per comunicar-se entre ells i amb l’exterior.  
És a dir, **una API és la porta d'entrada a un microservei**.  

---  
## 🧠 Comparació taula  
| Aspecte | Microservei | API |
|--------|--------------|------|
| **Tipus** | Unitat funcional del sistema | Interfície de comunicació |
| **Funció** | Separa responsabilitats, escalable, autònom | Permet accedir a funcionalitats |
| **Tecnologia** | Pot usar qualsevol (Node, Java, Python...) | Normalment HTTP/REST, GraphQL, gRPC |
| **Escalabilitat** | Escalables per separat | No és escalable per si sola |
| **Context** | Arquitectura de microserveis | Pot existir en qualsevol arquitectura |

---  
## 🏨 Metàfora  
- Els **microserveis** són com les habitacions d’un hotel.  
- Les **APIs** són les portes que permeten accedir a aquestes habitacions.  
- Truques a la porta (API) per demanar el servei que hi ha dins (microservei).  
---  
## ✅ Conclusions  
- **Una API pot existir sense microserveis**, però **un microservei no pot funcionar sense una API**.  
- Les APIs són el mecanisme de comunicació; els microserveis són els components que fan la feina.  
