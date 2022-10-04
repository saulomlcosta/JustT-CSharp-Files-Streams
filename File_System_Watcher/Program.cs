using static System.Console;

var path = @"C:\temp\globe";
using var fsw = new FileSystemWatcher(path);
fsw.Created += OnCreated;
fsw.Renamed += OnRenamed;
fsw.Deleted += OnDeleted;

fsw.EnableRaisingEvents = true;
fsw.IncludeSubdirectories = true;

WriteLine("Listening path...");
ReadLine();

void OnCreated(object sender, FileSystemEventArgs e)
{
  if (e.Name.Contains(".txt"))
  {
    WriteLine($"Creates a new file: {e.Name}");
    return;
  }
  WriteLine($"Creates a new directory: {e.Name}");
}

void OnRenamed(object sender, RenamedEventArgs e)
{
  if (e.OldName.Contains(".txt") && e.Name.Contains(".txt"))
  {
    WriteLine($"Rename file {e.OldName} to {e.Name}");
    return;
  }

  WriteLine($"Rename directory {e.OldName} to {e.Name}");
}

void OnDeleted(object sender, FileSystemEventArgs e)
{
  if (e.Name.Contains(".txt"))
  {
    WriteLine($"Deletes a file: {e.Name}");
    return;
  }
  WriteLine($"Deletes a directory: {e.Name}");
}