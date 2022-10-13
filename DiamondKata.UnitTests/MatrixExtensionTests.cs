namespace DiamondKata.UnitTests;

public class MatrixExtensionTests
{

    [Fact]
    public void Char_Matrix_ToString_Returns_Empty_String_With_Zero_Size_Matrix()
    {
        char?[,] zeroSizeMatrix = new char?[0,0];

        var result = zeroSizeMatrix.ToString('_');

        Assert.Equal(String.Empty, result);
    }

    [Fact]
    public void Char_Matrix_Single_Element_ToString_Returns_A_Single_Line_With_Line_Terminator()
    {
        char?[,] matrix = new char?[1, 1];
        matrix[0, 0] = 'A';
        var result = matrix.ToString('_');
        Assert.Equal("A" + Environment.NewLine, result);
    }

    [Fact]
    public void Char_Matrix_With_Multiple_Elements_Flattens_Matrix_With_SpaceFiller_And_LineTerminators()
    {
        char?[,] matrix = new char?[3, 3];
        matrix[0, 1] = 'A';
        matrix[1, 0] = 'B';
        matrix[1, 2] = 'B';
        matrix[2, 1] = 'A';

        var spaceFiller = '_';

        var result = matrix.ToString(spaceFiller);

        var expected =
            $"{spaceFiller}A{spaceFiller}{Environment.NewLine}" +
            $"B{spaceFiller}B{Environment.NewLine}" +
            $"{spaceFiller}A{spaceFiller}{Environment.NewLine}";


        Assert.Equal(expected, result);
    }

}
