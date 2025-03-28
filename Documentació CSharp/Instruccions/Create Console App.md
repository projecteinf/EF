# Creació aplicació HelloWorld (Consola)

## Creació aplicació

```bash
mkdir 01.HelloWorld
cd 01.HelloWorld/
dotnet new console
```

Qualsevol de les següents comandes són equivalents a les tres instruccions anteriors
```bash
dotnet new console -n 01.HelloWorld
dotnet new console --name 01.HelloWorld # Windows segurament és -name
```

## GIT - Ignorar fitxers binaris (fitxer: .gitignore)

```bash
echo "
01.HelloWorld/bin
01.HelloWorld/obj/
01.HelloWorld/obj/Debug/
01.HelloWorld/obj/Debug/net9.0/ " >> .gitignore
```

# Execució

```bash
pwd # ./01.HelloWorld - Ubicació del fitxer program.cs
dotnet run Program.cs
```

