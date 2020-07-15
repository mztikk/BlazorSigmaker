using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BlazorSigmaker.AoB
{
    public static class IAobValidatorExtensions
    {
        public static bool AreValid(this IAobValidator validator, IEnumerable<string> input, [NotNullWhen(false)] out AobError? error)
        {
            foreach (string? item in input)
            {
                if (!validator.IsValid(item, out error))
                {
                    return false;
                }
            }

            error = null;
            return true;
        }
    }
}
