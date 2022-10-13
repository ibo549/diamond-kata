using System.Text;

namespace DiamondKata.Extensions;

public static class MatrixExtensions
{
    public static string ToString(this char?[,] matrix, char spaceFillerCharacter)
    {
        if (matrix.GetLength(0) == 0)
        {
            return string.Empty;
        }
        var xLen = matrix.GetLength(0);
        var yLen = matrix.GetLength(1);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < xLen; i++)
        {
            for (int j = 0; j < yLen; j++)
            {
                if (matrix[i, j] == null)
                {
                    sb.Append(spaceFillerCharacter);
                }
                else
                {
                    sb.Append(matrix[i, j]);
                }
                    
                if (j == (yLen - 1))
                    sb.AppendLine();
            }
        }

        return sb.ToString();
    }
}

