using EstimatePi;

double estimate = BuffonsNeedle.EstimatePiParallel(
    needleCount: 100_000_000_000,
    needleLength: 1.0,
    lineSpacing: 1.0);



Console.WriteLine($"{Math.PI} --- actual");
Console.WriteLine($"{estimate} --- estimated");
Console.WriteLine("-------------------------------");
Console.WriteLine($"Absolute Error: {Math.Round(Math.Abs(Math.PI - estimate), 7):0.###################}");
Console.WriteLine($"Percentage Error: {Math.Round(Math.Abs((Math.PI - estimate) / Math.PI) * 100, 5):0.###################}%");
Console.WriteLine($"Correct Digits: {GetCorrectDigits(estimate)}");

static int GetCorrectDigits(double estimate)
{
    // TODO: this algorithm is incorrect, fix it
    // 3.1416087321339803
    // 3.141592653589793

    double absError = Math.Abs(Math.PI - estimate);
    if (absError == 0)
        return int.MaxValue; // Infinite correct digits if there's no error

    return Math.Max(0, -(int)Math.Floor(Math.Log10(absError)));
}
