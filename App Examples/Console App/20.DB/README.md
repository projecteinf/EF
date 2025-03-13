# GUIO
1. Aconseguir connexió sense patró (cutre).  
2. Millorar l'eficiència. Aplicació singleton a la connexió.  
3. Fer CRUD per una única taula (Password sense encriptar). Afegir internacionalització.  
3.1. Millorar CRUD. Separar responsabilitats (Incorporar classe ADO).  
3.2. Separar informació de taula de la vista ( DTO - Data transfer objects => Automapper ).  
4. Seguretat.  
4.1. Encriptació fitxer de dades de connexió. 
4.2. Classes Util.  
4.3. Interface per a la classe connexió.   
4.4. Inclusió salt i hash per guardar password a BD.  
5. Gestió personalitzada d'errors.(Pendent d'implementació.)  
5.1. Try .. Catch .. Finally - Minimitzar operacions. (Pendent d'implementació.)  

# Guió Registre i Login amb ADO.NET

## 1. Connexió a BD  
- Connexió bàsica sense patró (primer contacte).  
- Millora: Singleton per gestionar la connexió eficientment.  

## 2. CRUD bàsic (sense seguretat)  
- Implementació CRUD per una taula d'usuaris (password sense encriptar).  
- Afegir internacionalització.  

## 3. Refactorització i separació de responsabilitats  
- Crear classe ADO per gestionar l’accés a dades.  
- Implementar DTO (Data Transfer Objects) amb Automapper.  

## 4. Seguretat  
- Encriptar fitxer de configuració de connexió.  
- Implementar interfície per la classe de connexió.  
- Guardar contrasenyes amb hash + salt.  

## 5. Gestió d'errors i bones pràctiques  
- Try..Catch..Finally eficient.  
- Minimitzar operacions dins dels blocs de gestió d’errors.  
