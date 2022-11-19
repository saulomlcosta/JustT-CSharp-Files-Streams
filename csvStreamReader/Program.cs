using static System.Console;

var path = Path.Combine(
    Environment.CurrentDirectory,
    "Entry",
    "user-exp.csv");

if (File.Exists(path))
{
    using var sr = new StreamReader(path);

    var header = sr.ReadLine()?.Split(',');
    while (true)
    {
        var registry = sr.ReadLine()?.Split(',');
        if (registry == null) break;

        if (header?.Length != registry.Length)
        {
            WriteLine("Your file is out of pattern.");
            break;
        }

        for (int i = 0; i < registry.Length; i++)
        {
            WriteLine($"{header?[i]}:{registry[i]}");
        }
        WriteLine("--------------------------------");
    }
}
else
{
    WriteLine("Your file does not exist.");
}


WriteLine("\n\nPress [enter] to continue");
ReadLine();