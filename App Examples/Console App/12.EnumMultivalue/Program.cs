
using System;
using static System.Console;

class Program {
    static void Main() {
        EtapaEducativa etapaEducativa = EtapaEducativa.Primària;
        WriteLine($"Estudis {etapaEducativa} , Valor: {(int) etapaEducativa}");
        etapaEducativa = EtapaEducativa.Primària | EtapaEducativa.Infantil | EtapaEducativa.Secundària;
        WriteLine($"Estudis {etapaEducativa} , Valor: {(int) etapaEducativa}");
    }
}