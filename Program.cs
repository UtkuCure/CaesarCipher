using DotNetEnv;

namespace CaesarCipher;

internal class Program
{
    public static void Main(string[] args)
    {
            List<char> turkishAlphabet = new List<char>();
            
            string rawAlphabet = Environment.GetEnvironmentVariable("TurkishAlphabet");
            turkishAlphabet = rawAlphabet.ToCharArray().ToList();
            
            //Test
            Console.WriteLine(turkishAlphabet.Count);
            Console.WriteLine(turkishAlphabet[0]);
            Console.WriteLine(turkishAlphabet[1]);
            int lastIndex =  turkishAlphabet.Count - 1;
            Console.WriteLine(lastIndex);
            Console.WriteLine(turkishAlphabet[lastIndex]);
        
    }
}
