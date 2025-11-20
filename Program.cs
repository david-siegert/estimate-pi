using EstimatePi;

var buffonsNeedle = new BuffonsNeedle();
double estimate = buffonsNeedle.EstimatePi(10_000_000_000, 1.0, 1.0);


Console.WriteLine($"{Math.PI} --- actual");
Console.WriteLine($"{estimate} --- estimated");
Console.WriteLine("-------------------------------");
Console.WriteLine($"{Math.Round(Math.Abs(Math.PI - estimate), 7)} --- absolute error");
Console.WriteLine($"Percentage Error: {Math.Round(Math.Abs((Math.PI - estimate) / Math.PI) * 100, 5)}%");

