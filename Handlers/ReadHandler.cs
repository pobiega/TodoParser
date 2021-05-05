using System;
using TodoParser.Parsing;

namespace TodoParser.Handlers
{
    internal class ReadHandler : IHandler<ReadCommand>
    {
        public ReadHandler()
        {
            // dependencies go here and will be filled by DI
        }

        public void Run(ReadCommand command)
        {
            Console.WriteLine($"If the ReadHandler was implemented, I would now list details for Task {command.Id}.");
        }
    }
}