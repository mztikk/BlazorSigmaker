using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RFReborn;

namespace BlazorSigmaker.AoB
{
    public class AobValidator : IAobValidator
    {
        private const string AllowedChars = "abcdef0123456789?";

        public bool IsValid(string? input, [NotNullWhen(false)] out AobError? aobError)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                aobError = new AobError(input, "Input is null or empty");
                return false;
            }

            string trimmed = StringR.RemoveWhitespace(input);

            IEnumerable<char> illegalChars = trimmed.ToLowerInvariant().Except(AllowedChars);
            if (illegalChars.Any())
            {
                aobError = new AobError(input, $"Illegal chars {RFReborn.Extensions.IEnumerableExtensions.ToObjectsString(illegalChars)}");
                return false;
            }

            if (trimmed.Length % 2 != 0)
            {
                aobError = new AobError(input, "Bytes need to be full bytes, length of input has to be divisible by two");
                return false;
            }

            aobError = null;
            return true;
        }
    }
}
