namespace BoscComa.Connexio
{
    public interface IDadesXifratge
    {
        public byte[] Key { get; }
        public byte[] VectorInicialitzacio { get; }
    }
}