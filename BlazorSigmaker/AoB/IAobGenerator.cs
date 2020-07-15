using System.Collections.Generic;

namespace BlazorSigmaker.AoB
{
    public interface IAobGenerator
    {
        string Make(IEnumerable<string> input);
    }
}
