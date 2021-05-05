using TodoParser.Parsing;
using Sprache;
using System;

namespace TodoParser
{
    public static class Program
    {
        const string PROMPT = "> ";

        private static void Main()
        {
            var parser = CommandGrammar.Source;

            string line;
            do
            {
                Console.Write(PROMPT);
                line = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    try
                    {
                        var result = parser.Parse(line);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            while (line != null);
        }
    }
}