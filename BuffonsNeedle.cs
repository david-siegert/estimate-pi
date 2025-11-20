namespace EstimatePi;

public class BuffonsNeedle
{
    private readonly Random _random = new();

    public double EstimatePi(long needleCount, double needleLength, double lineSpacing)
    {
        if (needleLength > lineSpacing)
            throw new ArgumentException("Needle length must be less than or equal to line spacing.");

        int crosses = 0;

        for (int i = 0; i < needleCount; i++)
        {
            double center = _random.NextDouble() * (lineSpacing / 2);
            double angle = _random.NextDouble() * (Math.PI / 2);

            if (center <= (needleLength / 2) * Math.Sin(angle))
            {
                crosses++;
            }
        }

        double piEstimate = (2.0 * needleLength * needleCount) / (lineSpacing * crosses);
        return piEstimate;
    }
}
