using TodoParser.Parsing;

namespace TodoParser.Handlers
{
    internal interface IHandler<in TCommand> where TCommand : Command
    {
        void Run(TCommand command);
    }
}