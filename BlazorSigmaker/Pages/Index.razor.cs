using System;
using System.Threading.Tasks;
using BlazorSigmaker.AoB;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorSigmaker.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        protected IJSRuntime js { get; set; }
        [Inject]
        protected IAobGenerator aobGenerator { get; set; }
        [Inject]
        protected IAobValidator aobValidator { get; set; }
        [Inject]
        protected IAobPrettifier aobPrettifier { get; set; }

        public string Input { get; set; }
        public string Output { get; set; }

        private async Task Generate()
        {
            string[] aobs = Input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (aobValidator.AreValid(aobs, out AobError? error))
            {
                Output = aobPrettifier.Prettify(aobGenerator.Make(aobs));
            }
            else
            {
                await js.InvokeVoidAsync("errorNotification", error.Message);
            }
        }
    }
}
