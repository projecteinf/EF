# .NET Core

## Arquitectura

* CoreCLR (Common Language Runtime) -> Executció del codi
* CoreFX: Framework Class Library -> Classes per a la construcció de les aplicacions

## Compilació

Source code -> Roslyn (C# Compiler) -> Intermediate Language (IL) -> .dll / .exe file -> Executat per la màquina virtual .Net Core (CoreCLR) 
CoreCLR carrega IL code (.dll o .exe) / JIT (just in Time) compiler - Conversió a instruccions màquina (CPU)  

# EF

Object Relational Mapping (ORM)
* Programem amb Objectes
* Guardem les dades amb taules i relacions entre les taules
* Sistema per a facilitar la conversió entre objecte i taula i viceversa

## Instal·lació / Actualització SDK

https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian?tabs=dotnet9#debian-12


## Instal·lació / Actualització EF

```bash
dotnet tool install --global dotnet-ef
```

## Tipus d'aplicació

* Web application
* Desktop application
* Console application 

# Visual Studio Code
## Extensions

![image](https://github.com/user-attachments/assets/40b1ea28-dc9f-4dcc-b49e-a825db0dd256)

![image](https://github.com/user-attachments/assets/a2efa583-f937-4992-a975-f25354668e70)

