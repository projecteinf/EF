namespace BoscComa.Xifratge
{
    public interface IDadesXifratge
    {
        byte[] ObtenirClau();
        byte[] ObtenirVectorInicialitzacio();
    }
}
