# Caesar Cipher — Turkish Alphabet

> ⚠️ **Educational use only.** Do not use this for encrypting sensitive or important data.

## Overview

A simple Caesar Cipher implementation in English and Turkish alphabets. It will scroll your input texts every letter by 
the scroll number you enter.

## How It Works

1. Read the input string and the shift number from the user.
2. Load the Turkish alphabet from an environment variable.
3. For each character in the input:
    - If it exists in the alphabet, shift it by the given number.
    - If it does not, leave it as-is.
4. Output the encrypted string.

## Usage
* Open a terminal in the project directory and run with 'dotnet run'.
* Enter a text you want to encrypt 
* Enter a shift number. The program will output the encrypted text.

## ⚠️ Security Warning

Caesar Cipher is one of the **weakest** encryption methods known. It can be broken by brute force in at most 29 attempts (Turkish alphabet has 29 letters). **Never use this for real encryption.**

## License

MIT © 2026 Utku Cüre