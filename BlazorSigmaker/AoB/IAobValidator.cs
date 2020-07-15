using System.Diagnostics.CodeAnalysis;

namespace BlazorSigmaker.AoB
{
    public interface IAobValidator
    {
        bool IsValid(string? input, [NotNullWhen(false)] out AobError? aobError);
    }
}