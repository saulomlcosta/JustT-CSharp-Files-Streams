using static System.Console;

string sourceDirectory = @"c:\temp\globe";
string targetDirectory = @"c:\temp\globeCopy";

var diSource = new DirectoryInfo(sourceDirectory);
var diTarget = new DirectoryInfo(targetDirectory);

CopyAllDirAndFiles(diSource, diTarget);

static void CopyAllDirAndFiles(DirectoryInfo source, DirectoryInfo target)
{
  if (source.FullName.ToLower() == target.FullName.ToLower())
  {
    return;
  }

  // Check if the target directory exists, if not, create it.
  if (!Directory.Exists(target.FullName))
  {
    Directory.CreateDirectory(target.FullName);
  }

  // Copy each file into it's new directory.
  foreach (FileInfo f1 in source.GetFiles())
  {
    WriteLine(@"Copying {0} to {1}", source.FullName, f1.Name);
    f1.CopyTo(Path.Combine(target.ToString(), f1.Name), true);
  }

  // Copy each subdirectory using recursion.
  foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
  {
    DirectoryInfo nextTargetSubDir =
      target.CreateSubdirectory(diSourceSubDir.Name);
    CopyAllDirAndFiles(diSourceSubDir, nextTargetSubDir);
  }
}
