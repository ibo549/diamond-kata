namespace DiamondKata.Validators;

public interface IValidator
{
    public bool IsValid(char c);
    public bool IsValid(string c);
}

