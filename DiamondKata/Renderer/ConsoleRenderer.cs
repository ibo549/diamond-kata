using DiamondKata.Generators;
using DiamondKata.Extensions;

namespace DiamondKata.Renderer;

public class ConsoleRenderer : IDiamondRenderer
{
    private readonly IDiamondMatrixGenerator _diamondMatrixGenerator;

    public ConsoleRenderer(IDiamondMatrixGenerator diamondMatrixGenerator)
    {
        _diamondMatrixGenerator = diamondMatrixGenerator;
    }

    public void RenderDiamond(char letter, char spaceFillerChar)
    {
        var diamondMatrix = _diamondMatrixGenerator.GenerateDiamondMatrix(letter);

        Console.WriteLine(diamondMatrix.ToString(spaceFillerChar));
    }
}

