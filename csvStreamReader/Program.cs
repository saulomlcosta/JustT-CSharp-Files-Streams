using static System.Console;

CreateCsv();

WriteLine("\n\nPress [enter] to continue");
ReadLine();

static void CreateCsv()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Output");

    var person = new List<Person>(){
        new Person()
        {
            Name = "Jeffrey Ross",
            Email = "jf@gmail.com",
            Phone = "55958471512",
            Birthday = new DateOnly(year: 1970, month:2, day: 12)
        },
        new Person()
        {
            Name = "Mith Ross",
            Email = "mf@gmail.com",
            Phone = "55958471512",
            Birthday = new DateOnly(year: 1975, month:3, day: 13)
        },
        new Person()
        {
            Name = "Rony Ross",
            Email = "rf@gmail.com",
            Phone = "55958471512",
            Birthday = new DateOnly(year: 1977, month:6, day: 14)
        },
        new Person()
        {
            Name = "Dart Ross",
            Email = "df@gmail.com",
            Phone = "55958471512",
            Birthday = new DateOnly(year: 1980, month:5, day: 15)
        }
    };

    var directory = new DirectoryInfo(path);
    if (!directory.Exists)
    {
        directory.Create();
        path = Path.Combine(path, "user-output.csv");
    }
    else
    {
        path = Path.Combine(path, "user-output.csv");
    }

    using var sw = new StreamWriter(path);
    sw.WriteLine("name,email,phone,birthday");
    foreach (var p in person)
    {
        var line = $"{p.Name},{p.Email},{p.Phone},{p.Birthday}";
        sw.WriteLine(line);
    }

}

static void ReadCsv()
{
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
}


