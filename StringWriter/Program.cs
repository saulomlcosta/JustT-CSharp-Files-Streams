using static System.Console;

string textReaderText = @"A água potável tem um valor sem limites, entretanto a humanidade tem dado pouca importância aos cuidados que lhe são devidos.

Convenhamos nos atinar para esta ideologia, dando ao tão precioso líquido, suas devidas considerações, zelando das pequenas fontes, até os grandes mananciais.

Temos que ter em mente que: Não havendo água potável, não haverá saúde e nem a própria vida, quer das plantas ou animais.";

WriteLine($"Original text:\r\n {textReaderText}\n\n");
string line, paragraph = null;
var sr = new StringReader(textReaderText);

while (true)
{
    line = sr.ReadLine();
    if (line != null)
    {
        paragraph += line + "";
    }
    else
    {
        paragraph += '\n';
        break;
    }
}
Console.BackgroundColor = ConsoleColor.DarkCyan;
Console.ForegroundColor = ConsoleColor.Black;
WriteLine($"Edited Text:\r\n {paragraph}\n\n");

int charRead;
char charConverted;

var sw = new StringWriter();
sr = new StringReader(paragraph);

while (true)
{
    charRead = sr.Read();
    if (charRead == -1) break;

    charConverted = Convert.ToChar(charRead);

    if (charConverted == '.')
    {
        sw.Write(charConverted);
        sw.Write("\n\n");
    }
    else
    {
        sw.Write(charConverted);
    }
}
Console.BackgroundColor = ConsoleColor.Green;
WriteLine($"Text loaded in StringWriter:\r\n {sw.ToString()}");
ReadLine();