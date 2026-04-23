namespace CaesarCipher;

internal class Program
{
    public static void Main(string[] args)
    {
        List<char> turkishAlphabet;
        
        string rawAlphabet = Environment.GetEnvironmentVariable("TurkishAlphabet");
        turkishAlphabet = rawAlphabet.ToCharArray().ToList();
        
        //Test
        
    }
}
