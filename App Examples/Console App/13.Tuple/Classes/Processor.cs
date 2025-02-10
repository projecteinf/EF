public class Processor
{
    public static TextAndNumber GetTheData()
    {
        return new TextAndNumber
        {
            Text = "Número parell",
            Number = 42
        };
    }

    public static (string, int) GetTheDataWithTuple()
    {
        return ("Número parell",  42);
    }
}