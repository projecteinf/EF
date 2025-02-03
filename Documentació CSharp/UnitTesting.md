# Configuració de l'entorn de proves

## Crear llibreria de classes

Utilitzarem una llibreria per a demostrar el funcionament de les proves unitàries.

```bash
mkdir 01.Calculator
cd Calculator
dotnet new classlib
mv Class1.cs Calculator.cs
```

## Crear llibreria

```bash
dotnet build
```


## Crear projecte de proves

```bash
mkdir CalculatorLibUnitTests
cd CalculatorLibUnitTests/
dotnet new xunit
dotnet add reference ../../ClassLib/01.Calculator/01.Calculator.csproj
```

## Executar els tests

```bash
dotnet test
```