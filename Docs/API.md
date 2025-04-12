# API (Application Porgramming Interface)    
Sistema d'intercanvi d'informació a través de tecnologies web (http).  
- Encapsulació de la lògica de negoci.  
- Emmagatzematge persistent de la informació.
- Emmagatzematge de dades sensibles (tokens).
- Accés a dades en temps real.  
## Característiques  
- No hi ha interfície d'usuari.  
- Simples i eficients.
- Fàcils d'utilitzar (pels desenvolupadors).
- Integració en l'aplicació.  
## Necessitat  
- Connexió controlada a sistemes externs.  
- Desenvolupament aplicacions mòbil.  
- Compartició de dades entre múltiples dispositius (carret de la compra).  
## Elements  
- Contracte: descripció de l'API.
## Requisits  
- Funcional.  
- Segura.  
- Eficient.
- Disponible.  
## Aplicacions mòbils.  
Capacitat de processament reduïda.  
Emmagatzematge de dades reduït.  
### Característiques API.   
- Lleugeres.
- Dades fraccionades (partitioned).  
## Rols.
- Providers: disseny i creació (backend).  
- Customers: adaptació a la interfície d'usuari (crides i gestió de les dades).
## Decisions de disseny.  
- Funcionalitat en el client o en la pròpia API: funcionalitat del client reduïda (emmagatzematge de dades).
- Utilitzar una API existent o crear-ne una de nova.  
## Com escollir una API d'un tercer.  
- Trobar-la!  
- Aprendre sobre el seu funcionament: canvis, versions, gratuïta,...
- Testejar-la: estabilitat, rendiment, seguretat.  
- Utilitzar-la.
## Interaccions entre plataformes
![API Architecture](https://github.com/user-attachments/assets/1f753713-cdb0-4deb-b324-ffe81c1b04f5)
## Arquitectura
![API Architecture](https://github.com/user-attachments/assets/efab85c9-a200-44ea-adeb-62c383e9fb3b)

## REST?
**REST** és un conjunt de principis arquitectònics definits per Roy Fielding que descriuen com hauria de ser la comunicació entre sistemes en una arquitectura distribuïda com la web.  
Una **API RESTful** és una API que segueix els principis de REST, com:  
- Comunicació sense estat (stateless)  
- Utilització dels verbs HTTP estàndard (`GET`, `POST`, `PUT`, `DELETE`)  
- Recursos identificats per URIs  
- Representacions dels recursos (generalment en JSON o XML)  
