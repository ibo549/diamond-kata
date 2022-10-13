using DiamondKata.Validators;

namespace DiamondKata.Generators;

public class DiamondMatrixGenerator : IDiamondMatrixGenerator
{
    private readonly IValidator _charValidator;

    public DiamondMatrixGenerator(IValidator charValidator)
    {
        _charValidator = charValidator;
    }

    public char?[,] GenerateDiamondMatrix(char c)
    {
        c = char.ToUpper(c);
        if (!_charValidator.IsValid(c))
        {
            throw new ArgumentException($"{c} is not a valid letter");
        }

        var zeroBasedIndex = GetLetterIndex(c);
        var matrixSize = GetMatrixSize(zeroBasedIndex);
        int midPoint = matrixSize / 2;

        char?[,] diamondMatrix = new char?[matrixSize, matrixSize];

        for (int i = 0; i < matrixSize; i++)
        {
            if(i == 0)
            {
                diamondMatrix[i, midPoint] = 'A';
                diamondMatrix[(matrixSize - 1), midPoint] = 'A';
                continue;
            }

            char currentLetter = (char)(((int)'A') + i);

            if (i == midPoint)
            {
                diamondMatrix[midPoint, 0] = currentLetter;
                diamondMatrix[midPoint, (matrixSize - 1)] = currentLetter;
                break;
            }

            //populate below and above the midpoint
            //above
            diamondMatrix[i, (midPoint - i)] = currentLetter;
            diamondMatrix[i, (midPoint + i)] = currentLetter;
            //below
            diamondMatrix[(matrixSize - (i+1)), (midPoint - i)] = currentLetter;
            diamondMatrix[(matrixSize - (i+1)), (midPoint + i)] = currentLetter;                   
        }


        return diamondMatrix;
    }

    private int GetLetterIndex(char c)
    {
        return char.ToUpper(c) - 'A';
    }

    private int GetMatrixSize(int zeroBasedAlphabetIndex)
    {
        return (zeroBasedAlphabetIndex * 2) + 1;
    }
}

