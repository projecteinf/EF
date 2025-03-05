namespace BoscComa.Xifratge
{
    public interface IDadesXifratge
    {
        byte[] GetKey();
        byte[] GetInitializationVector();
    }
}
