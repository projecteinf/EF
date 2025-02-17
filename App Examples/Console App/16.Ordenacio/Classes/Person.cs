// ATENCIÓ: No guardeu l'edat, guardeu sempre la data de naixement!

public record class Persona(string Nom, short Edat, string DNI) : IComparable<Persona>
{
    public int CompareTo(Persona? altra)
    {
        if (altra == null) return 1;
        return this.Edat.CompareTo(altra.Edat);
    }
}
