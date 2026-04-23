using DotNetEnv;

namespace CaesarCipher;

internal class Program
{
    static List<char> turkishAlphabet = new List<char>();
    
    public static void Main(string[] args)
    {
        char currentLetter;
        int currentLettersAlphabetIndex;
        int AlphabetLength = turkishAlphabet.Count;
        int AlphabetLastIndex = turkishAlphabet.Count - 1;
        int letterCounter = 0;
        
        GetTurkishAlphabetFromEnvironment();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a text you want to encrypt: ");
        Console.ResetColor();
        
        string inputText = Console.ReadLine();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter the number of scroll (-3, +3): ");
        int scrollNumber = int.Parse(Console.ReadLine());

        List<char> outputText = inputText.ToLower().ToCharArray().ToList();
        
        for (int i = 0; i < outputText.Count; i++)
        {
            currentLetter = outputText[i];
            currentLettersAlphabetIndex = turkishAlphabet.IndexOf(currentLetter);
            
            foreach (char c in turkishAlphabet)
            {
                if (outputText[i] != c)
                {
                    letterCounter += 1;
                }
            }

            if (letterCounter == AlphabetLastIndex)
            {
                continue;
            }

            if (currentLettersAlphabetIndex + scrollNumber > AlphabetLastIndex)
            {
                outputText[i] = turkishAlphabet[(currentLettersAlphabetIndex + scrollNumber) - AlphabetLength];
            }
            else if (currentLettersAlphabetIndex + scrollNumber < 0)
            {
                outputText[i] = turkishAlphabet[(currentLettersAlphabetIndex + scrollNumber) +  AlphabetLength];
            }
            else
            {
                outputText[i] = turkishAlphabet[currentLettersAlphabetIndex + scrollNumber];
            }
            letterCounter = 0;
        }
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        outputText.ToString();
        Console.Write(outputText);
        Console.ResetColor();
    }

    private static void GetTurkishAlphabetFromEnvironment()
    {
        Env.Load();
            
        string rawAlphabet = Environment.GetEnvironmentVariable("TurkishAlphabet");

        if (rawAlphabet is null)
        {
            Console.WriteLine("There is an issue with accessing the alphabet, sorry!");
            return;
        }
        
        turkishAlphabet = rawAlphabet.ToCharArray().ToList();
    }
}
