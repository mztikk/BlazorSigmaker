using RFReborn;

namespace BlazorSigmaker.AoB
{
    public class AobPrettifier : IAobPrettifier
    {
        public string Prettify(string input)
        {
            input = StringR.RemoveWhitespace(input);

            return StringR.InSplit(input, 2, " ").ToUpperInvariant();
        }
    }
}
