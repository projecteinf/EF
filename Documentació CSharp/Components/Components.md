# Components .Net Core
## Compilador Roslyn
Codi font -> Compilador -> Intermediate language (IL) -> Assembly  
[Github Roslyn](https://github.com/dotnet/roslyn)  
## CoreCLR
Common Language Runtime  
Load assembly en IL -> Compilació (instruccions natives CPU) -> Execució  
## CoreFX
Llibreria d'eines reutilitzables (assemblies) distribuida en paquets.  
## Assembly (llibreria)
Serveixen per guardar el codi (IL) associat als tipus (classes,structs,...) en el sistema de fitxers.  
Es poden referenciar en altres projectes => Reutilització de codi.  
## Package
Conjunt d'assemblies amb la informació associada (plataforma,dades descriptives...).  
## Namespace
Direcció d'un tipus. Amb el namespace podem diferenciar dos tipus diferents amb el mateix nom.  
## Dependent assemblies
Relació, dependència, entre un o varis fitxers "assembly" o fitxers de llibreria. Les referències circulars són un avís d'un mal disseny de codi!  
## Framework
Grup de paquets. Un paquet pot formar part de diferents frameworks.  