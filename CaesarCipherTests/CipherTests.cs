// SPDX-License-Identifier: MIT

using Xunit;

namespace CaesarCipherTests;

public class CipherTests
{
    [Theory]
    [InlineData("abc", 1, "bcd")]
    [InlineData("xyz", 1, "yza")]
    [InlineData("abc", -1, "zab")]
    [InlineData("abc", 26, "abc")]
    public void EnglishEncrypt_ShiftsCorrectly(string input, int scroll, string expected)
    {
        Assert.Equal(expected, CaesarCipher.CaesarCipher.EncryptWithCaesarCipher(input, scroll, null, "english"));
    }

    [Fact]
    public void EnglishShorthand_EqualsFullWord()
    {
        var r1 = CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("hello", 3, null, "e");
        var r2 = CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("hello", 3, null, "english");
        Assert.Equal(r1, r2);
    }

    [Fact]
    public void NullAlphabetType_DefaultsToEnglish()
    {
        Assert.Equal("bcd", CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("abc", 1, null, null));
    }

    [Fact]
    public void NonAlphabeticChars_ArePreserved()
    {
        Assert.Equal("ifmmp, xpsme!", CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("hello, world!", 1, null, "english"));
    }

    [Fact]
    public void UppercaseInput_IsNormalized()
    {
        Assert.Equal("bcd", CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("ABC", 1, null, "english"));
    }

    [Fact]
    public void TurkishEncrypt_WrapsCorrectly()
    {
        // Turkish alphabet has 29 letters; 'z' (index 28) + 1 wraps to 'a' (index 0)
        Assert.Equal("a", CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("z", 1, null, "turkish"));
    }

    [Fact]
    public void TurkishShorthand_EqualsFullWord()
    {
        var r1 = CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("abc", 3, null, "t");
        var r2 = CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("abc", 3, null, "turkish");
        Assert.Equal(r1, r2);
    }

    [Fact]
    public void CustomAlphabet_UsedWhenProvided()
    {
        // alphabet "abc": a→b, b→c, c→a with scroll 1
        Assert.Equal("bca", CaesarCipher.CaesarCipher.EncryptWithCaesarCipher("abc", 1, "abc", "custom"));
    }
}
