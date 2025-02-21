# Publish and Deploy
Podem desplegar les nostres aplicacions de 3 formes diferents:
* Framework-dependent deployment (FDD).
* Framework-dependent executables (FDEs).
* Self-contained.
Les dues primeres opcions precisen que .NET Core estigui disponible en el sistema on es desplega l'aplicació.  
## Publishing self-contained application
```bash
dotnet publish -c Release -r win10-x64      # Windows
dotnet publish -c Release -r osx-x64        # MAC
dotnet publish -c Release -r rhel.7.4-x64   # Linux
```