using System.Text.RegularExpressions;

namespace DiamondKata.Validators;

public class EnglishLetterValidator : IValidator
{
    public bool IsValid(char c)
    {
        return Regex.IsMatch(c.ToString(), @"^[a-zA-Z]+$");
    }

    public bool IsValid(string c)
    {
       return c.Length == 1 ? IsValid(c[0]) : false;
    }
}