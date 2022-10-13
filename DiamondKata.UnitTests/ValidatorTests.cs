namespace DiamondKata.UnitTests;

public class ValidatorTests
{
    [Fact]
    public void EnglishLetterValidator_Returns_False_For_Non_English_Letters()
    {
        var englishValidator = new EnglishLetterValidator();
        var nonEnglishLetter = 'Ç';

        var result = englishValidator.IsValid(nonEnglishLetter);

        Assert.False(result);
    }

    [Fact]
    public void EnglishLetterValidator_Returns_True_For_LowerCase()
    {
        var englishValidator = new EnglishLetterValidator();
        var nonEnglishLetter = 'a';

        var result = englishValidator.IsValid(nonEnglishLetter);

        Assert.True(result);
    }

    [Fact]
    public void EnglishLetterValidator_Returns_True_For_UpperCase()
    {
        var englishValidator = new EnglishLetterValidator();
        var nonEnglishLetter = 'C';

        var result = englishValidator.IsValid(nonEnglishLetter);

        Assert.True(result);
    }

    [Fact]
    public void EnglishLetterValidator_Returns_False_For_NonAlphabetLetter()
    {
        var englishValidator = new EnglishLetterValidator();
        var nonEnglishLetter = '*';

        var result = englishValidator.IsValid(nonEnglishLetter);

        Assert.False(result);
    }

    [Fact]
    public void EnglishLetterValidator_Returns_False_For_Strings_With_Multiple_Chars()
    {
        var englishValidator = new EnglishLetterValidator();
        var nonEnglishLetter = "ABC";

        var result = englishValidator.IsValid(nonEnglishLetter);

        Assert.False(result);
    }

    [Fact]
    public void EnglishLetterValidator_Returns_True_For_English_Letter_String()
    {
        var englishValidator = new EnglishLetterValidator();
        var nonEnglishLetter = "D";

        var result = englishValidator.IsValid(nonEnglishLetter);

        Assert.True(result);
    }
}

