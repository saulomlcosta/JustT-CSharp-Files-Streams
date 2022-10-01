using static System.Console;

var path = @"C:\temp\globe";

ReadDirectories(path);
WriteLine("Press enter to continue...");
Console.ReadLine();

static void ReadDirectories(string path)
{
  if (Directory.Exists(path))
  {
    var directories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
    foreach (var dir in directories)
    {
      var dirInfo = new DirectoryInfo(dir);
      WriteLine($"[Name]:{dirInfo.Name}");
      WriteLine($"[Root]:{dirInfo.Root}");
      if (dirInfo.Parent != null)
        WriteLine($"[Parent]:{dirInfo.Parent.Name}");

      WriteLine("--------------------------");
    }
  }
  else
  {
    WriteLine("The directory doesn't exists");
  }
}