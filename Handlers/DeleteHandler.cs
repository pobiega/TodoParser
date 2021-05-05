using System;
using TodoParser.Parsing;

namespace TodoParser.Handlers
{
    internal class DeleteHandler : IHandler<DeleteCommand>
    {
        public void Run(DeleteCommand command)
        {
            Console.WriteLine($"If the DeleteHandler was implemented, I would now delete Task {command.Id}.");
        }
    }
}