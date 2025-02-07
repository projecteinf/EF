# .NET Core

## Instal·lació / Actualització SDK

https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian?tabs=dotnet9#debian-12

```bash
wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-9.0
```

Per a determinar la versió

```bash
dotnet --version
dotnet --info
``` 

## Arquitectura

* CoreCLR (Common Language Runtime) -> Executció del codi
* CoreFX: Framework Class Library -> Classes per a la construcció de les aplicacions

# Windows Desktop Pack

https://dotnet.microsoft.com/download/dotnet/6.0


## Compilació

Source code -> Roslyn (C# Compiler) -> Intermediate Language (IL) -> .dll / .exe file -> Executat per la màquina virtual .Net Core (CoreCLR) 
CoreCLR carrega IL code (.dll o .exe) / JIT (just in Time) compiler - Conversió a instruccions màquina (CPU)  

# EF

Object Relational Mapping (ORM)
* Programem amb Ob## Instal·lació / Actualització SDK

https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian?tabs=dotnet9#debian-12
jectes
* Guardem les dades amb taules i relacions entre les taules
* Sistema per a facilitar la conversió entre objecte i taula i viceversa

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

