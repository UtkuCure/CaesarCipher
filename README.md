# Caesar Cipher — Turkish Alphabet

> ⚠️ **Educational use only.** Do not use this for encrypting sensitive or important data.

## Overview

A simple Caesar Cipher implementation in C# that shifts each letter in a given string by a specified number of positions within the **Turkish alphabet**. Non-alphabet characters are left untouched.

The Turkish alphabet is loaded from an **environment variable**, making it flexible and easy to configure without changing the source code.

## How It Works

1. Read the input string and the shift number from the user.
2. Load the Turkish alphabet from an environment variable.
3. For each character in the input:
    - If it exists in the alphabet, shift it by the given number.
    - If it does not, leave it as-is.
4. Output the encrypted string.

## Usage

Turkish alphabet is alredy setted but to make it work, you should delete the '.example' from the name of '.env.example'. It should be '.env'

If you want to change alphabet **do not** change the name of variable (TurkishAlphabet), just enter the alphabet you want as value of TurkishAlphabet

Then run the program and follow the prompts.

## ⚠️ Security Warning

Caesar Cipher is one of the **weakest** encryption methods known. It can be broken by brute force in at most 29 attempts (Turkish alphabet has 29 letters). **Never use this for real encryption.**

## License

MIT © 2026 Utku Cüre