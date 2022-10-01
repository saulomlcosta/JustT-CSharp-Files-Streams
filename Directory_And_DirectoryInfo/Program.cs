using static System.Console;

var origin = Path.Combine(Environment.CurrentDirectory, "argentina.txt");
var destination = Path.Combine(Environment.CurrentDirectory,
                          "globe",
                          "South America",
                          "Brasil",
                          "brasil.txt");

// CreateFile("argentina");
CreateDirectoriesGlobe();
// MoveOrCopyFile("copy", origin, destination);

static void MoveOrCopyFile(string action, string origin, string destination)
{
  if (!File.Exists(origin))
  {
    WriteLine("The file doesn't exists on origin path " + origin);
    ReadLine();
    return;
  }

  if (File.Exists(destination))
  {
    WriteLine("The file already exists on destination " + destination);
    ReadLine();
    return;
  }

  if (action == "move")
  {
    File.Move(origin, destination);
  }

  if (action == "copy")
  {
    File.Copy(origin, destination);
  }
}

static void CreateFile(string nameFile)
{
  var path = Path.Combine(Environment.CurrentDirectory, $"{nameFile}.txt");
  if (!File.Exists(path))
  {
    using var sw = File.CreateText(path);
    sw.WriteLine("Population: 222M");
    sw.WriteLine("IDH: 0.901");
    sw.WriteLine("Data updated: 20/04/2018");
  }
}

static void CreateDirectoriesGlobe()
{
  // var path = @"C:\temp\globe";
  var path = Path.Combine(Environment.CurrentDirectory, "globe");

  if (!Directory.Exists(path))
  {
    var dirGlobe = Directory.CreateDirectory(path);
    var dirNorthAm = dirGlobe.CreateSubdirectory("North America");
    var dirCenterAm = dirGlobe.CreateSubdirectory("Center America");
    var dirSouthAm = dirGlobe.CreateSubdirectory("South America");

    dirNorthAm.CreateSubdirectory("USA");
    dirNorthAm.CreateSubdirectory("Mexico");
    dirNorthAm.CreateSubdirectory("Canada");

    dirCenterAm.CreateSubdirectory("Costa Rica");
    dirCenterAm.CreateSubdirectory("Panama");

    dirSouthAm.CreateSubdirectory("Brasil");
    dirSouthAm.CreateSubdirectory("Argentina");
    dirSouthAm.CreateSubdirectory("Uruguay");
  }
  else
  {
    WriteLine("Unable to create directory, directory already exists.");
    ReadLine();
  }
}