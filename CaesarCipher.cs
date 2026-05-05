// SPDX-License-Identifier: MIT
// Copyright (c) 2026 Utku Cüre, UtkuCure

/*
 * a = alphabet lenght
 * x = current letter index
 * k = scroll number
 *
 * E(x) = (x + k) mod a
 */

using System.Globalization;

namespace CaesarCipher;

public static class CaesarCipher
{
    public static string EncryptWithCaesarCipher(string inputText, int scrollNumber, string? alphabet, string? alphabetType)
    {
        if (alphabetType == "turkish" || alphabetType == "t")
        {
            alphabetType = "turkish";
            alphabet = "abcçdefgğhıijklmnoöprsştuüvyz";
        }
        else if (alphabetType == "english" || alphabetType == "e")
        {
            alphabetType = "english";
            alphabet = "abcdefghijklmnopqrstuvwxyz";
        }
        else
        {
            if (alphabet is null)
            {
                alphabetType = "english";
                alphabet = "abcdefghijklmnopqrstuvwxyz";
            }
        }
        
        string outputText = inputText.ToLower(new CultureInfo("tr-TR"));
        List<char> outputTextList = outputText.ToCharArray().ToList();
        
        char currentLetter;
        int currentLettersAlphabetIndex;
        int newIndex;
        char newLetter;

        for (int i = 0; i < outputText.Length; i++)
        {
            if (!alphabet.Contains(outputText[i]))
            {
                continue;
            }
            
            currentLetter = outputText[i];
            currentLettersAlphabetIndex = alphabet.IndexOf(currentLetter);
            
            newIndex = ((currentLettersAlphabetIndex + scrollNumber) %
                alphabet.Length + alphabet.Length) % alphabet.Length;
            
            //if (newIndex < 0 || newIndex >= alphabet.Length) return string.Empty;
            newLetter = alphabet[newIndex];
            
            outputTextList[i] = newLetter;
        }
        
        outputText = new string(outputTextList.ToArray());
        return outputText;
    }
}