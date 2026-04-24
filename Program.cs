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
 * WARNING [Current State] THIS PROJECT IS UNDER DEVELOPMENT
 * The core shifting algorithm is currently being refactored. Some edge cases in Turkish alphabet might not produce the
 * expected output.
 * 
 * Author: Utku Cüre, UtkuCure
 * Date: 23/04/2026
 */

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
        Console.ResetColor();

        List<char> outputText = inputText.ToLower().ToCharArray().ToList();
        
        // ======================================
        // WARNING: WORK IN PROGRESS
        // ======================================
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
