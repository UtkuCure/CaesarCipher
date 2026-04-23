using DotNetEnv;

namespace CaesarCipher;

internal class Program
{
    public static void Main(string[] args)
    {
        Env.Load();
        List<char> turkishAlphabet = new List<char>();
            
        string rawAlphabet = Environment.GetEnvironmentVariable("TurkishAlphabet");

        if (rawAlphabet is null)
        {
            Console.WriteLine("There is an issue with accessing the alphabet, sorry!");
            return;
        }
        
        turkishAlphabet = rawAlphabet.ToCharArray().ToList();
        
    }
}
