// SPDX-License-Identifier: MIT
// Copyright (c) 2026 Utku Cüre, UtkuCure

/*
 * This is a simple Caesar Cipher implementation in C#. It takes a user input string and a scroll number, then shifts
 * each letter in the string by the specified number of positions in the selected alphabet. Non-alphabet characters are
 * left unchanged.
 *
 * English and Turkish alphabet supported.
 * 
 * Note: DO NOT USE THIS METHOD IF YOU ARE ENCRYPTING AN IMPORTANT DATA, USE THIS EDUCATION PURPOSE ONLY!
 * 
 * The Caesar Cipher is a very basic encryption technique and can be easily broken, so it should not be used for secure
 * data encryption.
 *
 * You can import this project to your project
 * How to use:
 *     implement it to your project
 *     create an instance of the class
 *     call the method EncryptWithCaesarCipher with the appropriate parameters
 *
 * If you want to use it on terminal:
 *     dotnet run
 *     enter a text you want to encrypt
 *     enter a number of scroll (positive for right shift, negative for left shift) - you can use negative for decrypt
 *
 * Author: Utku Cüre, UtkuCure
 * Date: 23/04/2026
 */

using System.Globalization;

namespace CaesarCipher;
public class Program
{
    static List<char> _alphabet = new List<char>();
    private static string? _rawAlphabet;
    
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Which alphabet do you want to use (english/turkish) (e/t)?");
        Console.ResetColor();

        string? alphabetType = Console.ReadLine()?.ToLower();

        if (alphabetType is null) return;

        if (alphabetType == "t" || alphabetType == "turkish")
        {
            _rawAlphabet = "abcçdefgğhıijklmnoöprsştuüvyz";
        }
        else if (alphabetType == "e" || alphabetType == "english")
        {
            _rawAlphabet = "abcdefghijklmnopqrstuvwxyz";
        }

        if (_rawAlphabet is null)
        {
            Console.WriteLine("Please enter a valid alphabet (e/t, turkish, english): ");
            return;
        }
        _alphabet = _rawAlphabet.ToCharArray().ToList();
        
        int alphabetLength = _alphabet.Count;

        while (true)
        {
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
        
            string? inputScrollNumber = Console.ReadLine();
            if(int.TryParse(inputScrollNumber, out int scrollNumber) == false)
            {
                Console.WriteLine("Invalid scroll number, exiting...");
                return;
            }
            string outputText = CaesarCipher.EncryptWithCaesarCipher(inputText, 5, null, "turkish");
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(outputText);
            Console.ResetColor();
        }
    }

    public static void EncryptWithCaesarCipher(List<char> outputText, int scrollNumber, int alphabetLength)
    {
        for (int i = 0; i < outputText.Count; i++)
        {
            char currentLetter = outputText[i];
            int currentLettersAlphabetIndex = _alphabet.IndexOf(currentLetter);

            if (!_alphabet.Contains(currentLetter))
            {
                continue;
            }
            
            int newIndex = ((currentLettersAlphabetIndex + scrollNumber) % 
                alphabetLength + alphabetLength) % alphabetLength;
            currentLetter = _alphabet[newIndex];
            outputText[i] = currentLetter;
        }
    }
}
