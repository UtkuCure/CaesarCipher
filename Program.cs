// SPDX-License-Identifier: MIT
// Copyright (c) 2026 Utku Cüre, UtkuCure

/*
 * This is a simple Caesar Cipher implementation in C#. It takes a user input string and a scroll number, then shifts
 * each letter in the string by the specified number of positions in the Turkish alphabet. The Turkish alphabet is
 * loaded from an environment variable for flexibility. Non-alphabet characters are left unchanged.
 * 
 * Note: DO NOT USE THIS METHOD IF YOU ARE ENCRYPTING AN IMPORTANT DATA, USE THIS EDUCATION PURPOSE ONLY!
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
internal class Program
{
    static List<char> turkishAlphabet = new List<char>();
    
    public static void Main(string[] args)
    {
        GetTurkishAlphabetFromEnvironment();
        
        int AlphabetLength = turkishAlphabet.Count;
        int AlphabetLastIndex = turkishAlphabet.Count - 1;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter a text you want to encrypt: ");
        Console.ResetColor();
        
        string? inputText = Console.ReadLine();
        if (inputText is null) 
        {
            Console.WriteLine("Input cannot be null, exiting...");
            return;
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter the number of scroll (-3, +3): ");
        Console.ResetColor();
        int scrollNumber = int.Parse(Console.ReadLine());

        List<char> outputText = inputText.ToLower(new CultureInfo("tr-TR")).ToCharArray().ToList();
        
        for (int i = 0; i < outputText.Count; i++)
        {
            char currentLetter = outputText[i];
            int currentLettersAlphabetIndex = turkishAlphabet.IndexOf(currentLetter);

            if (!turkishAlphabet.Contains(currentLetter))
            {
                continue;
            }
            
            int newIndex = ((currentLettersAlphabetIndex + scrollNumber) % AlphabetLength + AlphabetLength) % AlphabetLength;
            currentLetter = turkishAlphabet[newIndex];
            outputText[i] = currentLetter;
        }
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        string finalOutput = new string(outputText.ToArray());
        Console.Write(finalOutput);
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
