using TodoParser.Parsing;
using Sprache;
using System;
using Microsoft.Extensions.DependencyInjection;
using TodoParser.Handlers;
using System.Linq;

namespace TodoParser
{
    public static class Program
    {
        const string PROMPT = "> ";

        const bool INTERACTIVE_DEFAULT = false;

        private static void Main(string[] args)
        {
            var services = ConfigureServices();
            var provider = services.BuildServiceProvider();

            var cmdline = string.Join(' ', args);

            var userRequestedInteractive = CommandLineArgumentsGrammar.Interactive.TryParse(cmdline).WasSuccessful;

            var runInteractive = INTERACTIVE_DEFAULT || userRequestedInteractive;

            var parser = CommandGrammar.Source;

            if (runInteractive)
            {
                InteractiveMode(provider);
            }
            else
            {
                var command = parser.Parse(cmdline);

                Console.WriteLine(command);

                HandleCommand(provider, command);
            }
        }

        private static void InteractiveMode(ServiceProvider provider)
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
                        var command = parser.Parse(line);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(command);

                        Console.ResetColor();
                        HandleCommand(provider, command);
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

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IHandler<ReadCommand>, ReadHandler>();
            services.AddTransient<IHandler<DeleteCommand>, DeleteHandler>();

            return services;
        }

        private static void HandleCommand(ServiceProvider provider, Command command)
        {
            switch (command)
            {
                case ReadCommand read:
                    provider.GetRequiredService<IHandler<ReadCommand>>().Run(read);
                    break;
                case DeleteCommand delete:
                    provider.GetRequiredService<IHandler<DeleteCommand>>().Run(delete);
                    break;
                default:
                    throw new Exception($"Unknown command type {command.GetType().FullName} sent to HandleCommand!");
            }
        }
    }
}