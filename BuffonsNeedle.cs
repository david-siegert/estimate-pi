namespace EstimatePi;

public class BuffonsNeedle
{
    public static double EstimatePi(long needleCount, double needleLength, double lineSpacing)
    {
        Random random = new();

        DateTime startTime = DateTime.Now;

        Console.WriteLine($"Needle count: {needleCount}");

        if (needleLength > lineSpacing)
            throw new ArgumentException("Needle length must be less than or equal to line spacing.");

        long crosses = 0;

        for (long i = 0; i < needleCount; i++)
        {
            if (i % 100_000_000 == 0 && i != 0)
            {
                Console.WriteLine($"Progress: 100 million needles simulated...");
            }

            double center = random.NextDouble() * (lineSpacing / 2);
            double angle = random.NextDouble() * (Math.PI / 2);

            if (center <= (needleLength / 2) * Math.Sin(angle))
            {
                crosses++;
            }
        }

        Console.WriteLine($"Time taken: {Math.Round((DateTime.Now - startTime).TotalMinutes, 1)} minutes");

        double piEstimate = 2.0 * needleLength * needleCount / (lineSpacing * crosses);
        return piEstimate;
    }

    public static double EstimatePiParallel(long needleCount, double needleLength, double lineSpacing)
    {
        DateTime startTime = DateTime.Now;

        Console.WriteLine($"Needle count: {needleCount}");

        if (needleLength > lineSpacing)
            throw new ArgumentException("Needle length must be less than or equal to line spacing.");

        long crosses = 0;

        Parallel.For(0, needleCount, () => 0L, (i, loopState, localCrosses) =>
        {
            // if (i % 100_000_000 == 0 && i != 0)
            // {
            //     Console.WriteLine($"Progress: 100 million needles simulated...");
            // }

            double center = Random.Shared.NextDouble() * (lineSpacing / 2);
            double angle = Random.Shared.NextDouble() * (Math.PI / 2);

            if (center <= (needleLength / 2) * Math.Sin(angle))
            {
                localCrosses++;
            }

            return localCrosses;
        },
        localCrosses =>
        {
            Interlocked.Add(ref crosses, localCrosses);
        });

        Console.WriteLine($"Time taken: {Math.Round((DateTime.Now - startTime).TotalMinutes, 3)} minutes");

        double piEstimate = 2.0 * needleLength * needleCount / (lineSpacing * crosses);
        return piEstimate;
    }

}
