// SPDX-License-Identifier: MIT
// Copyright (c) 2026 Utku Cüre, UtkuCure

/*
 * This is a simple Caesar Cipher implementation in C#. It takes a user input string and a scroll number, then shifts
 * each letter in the string by the specified number of positions in the Turkish alphabet. The Turkish alphabet is
 * loaded from an environment variable for flexibility. Non-alphabet characters are left unchanged.
 * 
 * Note: DO NOT USE THIS METHOD IF YOU ARE ENCRYPTING IMPORTANT DATA, USE THIS EDUCATION PURPOSE ONLY!
 * 
 * The Caesar Cipher is a very basic encryption technique and can be easily broken, so it should not be used for secure
 * data encryption.
 *
 * Author: Utku Cüre, UtkuCure
 * Date: 23/04/2026
 */

using DotNetEnv;
using System.Globalization;

namespace CaesarCipher;
public class Program
{
    static List<char> _turkishAlphabet = new List<char>();
    
    public static void Main(string[] args)
    {
        GetTurkishAlphabetFromEnvironment();
        
        int alphabetLength = _turkishAlphabet.Count;
        int alphabetLastIndex = _turkishAlphabet.Count - 1;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a text you want to encrypt: ");
        Console.ResetColor();
        
        string inputText = Console.ReadLine();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter the number of scroll (-3, +3): ");
        Console.ResetColor();
        int scrollNumber = int.Parse(Console.ReadLine());

        List<char> outputText = inputText.ToLower(new CultureInfo("tr-TR")).ToCharArray().ToList();

        EncryptWithCaesarCipher(outputText, scrollNumber, alphabetLength);
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        string finalOutput = new string(outputText.ToArray());
        Console.Write(finalOutput);
        Console.ResetColor();
    }

    public static void EncryptWithCaesarCipher(List<char> outputText, int scrollNumber, int alphabetLength)
    {
        for (int i = 0; i < outputText.Count; i++)
        {
            char currentLetter = outputText[i];
            int currentLettersAlphabetIndex = _turkishAlphabet.IndexOf(currentLetter);

            if (!_turkishAlphabet.Contains(currentLetter))
            {
                continue;
            }
            
            int newIndex = ((currentLettersAlphabetIndex + scrollNumber) % 
                alphabetLength + alphabetLength) % alphabetLength;
            currentLetter = _turkishAlphabet[newIndex];
            outputText[i] = currentLetter;
        }
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
        
        _turkishAlphabet = rawAlphabet.ToCharArray().ToList();
    }
}
