using System.Text;
var sb = new StringBuilder();
sb.AppendLine("There is a house in New Orleans...");
sb.AppendLine("They call the rising sun...");
sb.AppendLine("And it's been the ruin of many a poor boy...");
sb.AppendLine("And God, I know I'm one...");

using var sr = new StringReader(sb.ToString());

do
{
    Console.WriteLine(sr.ReadLine());
} while (sr.Peek() >= 0);

// using var sr = new StringReader(sb.ToString());
// var buffer = new char[10];
// var size = 0;

// do
// {
//     buffer = new char[10];
//     size = sr.Read(buffer);
//     Console.Write(string.Join("", buffer));
// } while (size >= buffer.Length);