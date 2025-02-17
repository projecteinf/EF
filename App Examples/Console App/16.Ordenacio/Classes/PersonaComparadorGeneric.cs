public class PersonaComparador<T> : IComparer<Persona>
{
    private readonly Func<Persona, T> _criteri;     // Es tracta d'una funció delegada.
    private readonly bool _ordreInvers;

    public PersonaComparador(Func<Persona, T> criteri, bool ordreInvers = false)
    {
        _criteri = criteri;                         // Assignem el mètode get indicat per a l'usuari (main!)
        _ordreInvers = ordreInvers;
    }

    public int Compare(Persona p1, Persona p2)
    {
        int resultat = Comparer<T>.Default.Compare(_criteri(p1), _criteri(p2)); // Executa el mètode Get associat a la Funció Criteri. Funció delegada
        return _ordreInvers ? -resultat : resultat; // -resultat = (-1) * resultat -> Valor correcte per a canviar l'ordre
    }
}