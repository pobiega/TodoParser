using Sprache;

namespace TodoParser.Parsing
{
    public static class CommandLineArgumentsGrammar
    {
        private static readonly Parser<string> _keywordInteractive =
           Parse.IgnoreCase("interactive").Text();

        private static readonly Parser<string> _doubleHyphen =
            Parse.Char('-').Repeat(2).Text();

        private static readonly Parser<char> _dash =
            Parse.Char('-');

        private static readonly Parser<string> _i =
            Parse.IgnoreCase("i").Text();

        private static readonly Parser<string> _dashI =
            from dash in _dash
            from i in _i
            select $"{dash}{i}";

        private static readonly Parser<string> _interactive =
            from dh in _doubleHyphen.Optional()
            from keyword in _keywordInteractive
            select $"{dh}{keyword}";

        public static readonly Parser<string> Interactive =
            _interactive
            .Or(_dashI);
    }
}
