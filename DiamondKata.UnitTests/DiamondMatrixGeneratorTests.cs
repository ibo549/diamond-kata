namespace DiamondKata.UnitTests;

public class DiamondMatrixGeneratorTests
{
    private Mock<IValidator> _validatorMock;
    private IDiamondMatrixGenerator _matrixGenerator;

    public DiamondMatrixGeneratorTests()
    {
        _validatorMock = new Mock<IValidator>();
        _matrixGenerator = new DiamondMatrixGenerator(_validatorMock.Object);
    }

    [Fact]
    public void GenerateDiamondMatrix_ThrowsException_WhenInvalidCharacterIsProvided()
    {
        char invalidChar = '#';
        _validatorMock.Setup(x => x.IsValid(invalidChar)).Returns(false);

        Assert.Throws<ArgumentException>(() => _matrixGenerator.GenerateDiamondMatrix(invalidChar));

    }

    [Fact]
    public void GenerateDiamondMatrix_CreatesCorrectSizedMatrix_WithRespectToLetterIndex()
    {
        char diamondChar = 'C';
        _validatorMock.Setup(x => x.IsValid(diamondChar)).Returns(true);
        int expectedMatrixDimension = 5;

        var matrix = _matrixGenerator.GenerateDiamondMatrix(diamondChar);
        int x = matrix.GetLength(0);
        int y = matrix.GetLength(1);

        Assert.Equal(expectedMatrixDimension, x);
        Assert.Equal(expectedMatrixDimension, y);
    }

    [Fact]
    public void GenerateDiamondMatrix_Populates_A()
    {
        char diamondChar = 'A';
        _validatorMock.Setup(x => x.IsValid(diamondChar)).Returns(true);
        int expectedMatrixDimension = 1;

        var matrix = _matrixGenerator.GenerateDiamondMatrix(diamondChar);
        int x = matrix.GetLength(0);
        int y = matrix.GetLength(1);

        Assert.Equal(expectedMatrixDimension, x);
        Assert.Equal(expectedMatrixDimension, y);

        Assert.Equal(diamondChar, matrix[0, 0]);
    }

    [Fact]
    public void GenerateDiamondMatrix_Populates_Diamond_With_UpperCase_When_LowerCase_Argument_Is_Provided()
    {
        char lowerCaseDiamondChar = 'a';
        char upperCaseDiamondChar = 'A';
        _validatorMock.Setup(x => x.IsValid(upperCaseDiamondChar)).Returns(true);

        var matrix = _matrixGenerator.GenerateDiamondMatrix(lowerCaseDiamondChar);

        Assert.Equal(upperCaseDiamondChar, matrix[0, 0]);
    }

    [Fact]
    public void GenerateDiamondMatrix_Populates_MidPoint_In_X_Axis()
    {
        char diamondChar = 'C';
        _validatorMock.Setup(x => x.IsValid(diamondChar)).Returns(true);

        var matrix = _matrixGenerator.GenerateDiamondMatrix(diamondChar);

        Assert.Equal(diamondChar, matrix[2, 0]);
        Assert.Equal(diamondChar, matrix[2, 0]);
    }

    [Fact]
    public void GenerateDiamondMatrix_Populates_MidPoint_In_Y_Axis()
    {
        char diamondChar = 'C';
        _validatorMock.Setup(x => x.IsValid(diamondChar)).Returns(true);

        var matrix = _matrixGenerator.GenerateDiamondMatrix(diamondChar);

        char midPointYAxisChar = 'A';

        Assert.Equal(midPointYAxisChar, matrix[0, 2]);
        Assert.Equal(midPointYAxisChar, matrix[4, 2]);
    }

    [Fact]
    public void GenerateDiamondMatrix_Populates_Diamond_Below_And_Above_MidPoint()
    {
        char diamondChar = 'C';
        _validatorMock.Setup(x => x.IsValid(diamondChar)).Returns(true);

        var matrix = _matrixGenerator.GenerateDiamondMatrix(diamondChar);

        char diamondCharBelowAndAbove = 'B';

        //above
        Assert.Equal(diamondCharBelowAndAbove, matrix[1, 1]);
        Assert.Equal(diamondCharBelowAndAbove, matrix[1, 3]);

        //below
        Assert.Equal(diamondCharBelowAndAbove, matrix[3, 1]);
        Assert.Equal(diamondCharBelowAndAbove, matrix[3, 3]);
    }

    [Theory]
    [InlineData('C')]
    [InlineData('D')]
    [InlineData('E')]
    [InlineData('F')]
    [InlineData('G')]
    public void GenerateDiamondMatrix_Populates_Diamond_With_Various_Letters(char c)
    {
        _validatorMock.Setup(x => x.IsValid(c)).Returns(true);

        var matrix = _matrixGenerator.GenerateDiamondMatrix(c);
        var matrixSize = matrix.GetLength(0);
        var midPoint = matrixSize / 2;

        char letterBelowAndAbove = (char)(((int)c) - 1);

        //letter in X axis
        Assert.Equal(c, matrix[midPoint, 0]);
        Assert.Equal(c, matrix[midPoint, matrixSize - 1]);

        //above
        Assert.Equal(letterBelowAndAbove, matrix[midPoint - 1, 1]);
        Assert.Equal(letterBelowAndAbove, matrix[midPoint - 1, matrixSize - 2]);

        //below
        Assert.Equal(letterBelowAndAbove, matrix[midPoint + 1, 1]);
        Assert.Equal(letterBelowAndAbove, matrix[midPoint + 1, matrixSize - 2]);

        //A in Y axis
        Assert.Equal('A', matrix[0, midPoint]);
        Assert.Equal('A', matrix[matrixSize - 1, midPoint]);
    }

}
