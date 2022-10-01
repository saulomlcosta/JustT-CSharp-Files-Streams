using static System.Console;

WriteLine("What's the file name?");
var nameFile = ReadLine();

nameFile = SanitizeNameFile(nameFile);

var path = Path.Combine(Environment.CurrentDirectory, $"{nameFile}.txt");

try
{
  CreateFile(path);
}
catch
{

  WriteLine("Couldn't create file, please try again");
}

WriteLine("Press enter to continue...");
ReadLine();

static string SanitizeNameFile(string nameFile)
{
  foreach (var @char in Path.GetInvalidFileNameChars())
  {
    nameFile = nameFile.Replace(@char, '-');
  }

  return nameFile;
}

static void CreateFile(string path)
{
  using var sw = File.CreateText(path);
  sw.WriteLine("Line 1");
  sw.WriteLine("Line 2");
  sw.WriteLine("Line 3");
}