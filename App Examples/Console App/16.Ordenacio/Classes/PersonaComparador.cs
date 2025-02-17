public class PersonaComparador : IComparer<Persona>
{
    public int Compare(Persona p1, Persona p2)
    {
        return p1.Edat - p2.Edat;
    }
}