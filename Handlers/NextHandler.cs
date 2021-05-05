using System;
using TodoParser.Parsing;

namespace TodoParser.Handlers
{

    internal class NextHandler : IHandler<NextCommand>
    {
        public void Run(NextCommand command)
        {
            Console.WriteLine("Hello from the next command!");
        }
    }
}