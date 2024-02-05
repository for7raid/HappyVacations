using Microsoft.JSInterop;

namespace HappyVacations
{
    public class AppTheme
    {
        private readonly IJSRuntime js; 
        private bool isDarkMode = false;

        public AppTheme(IJSRuntime js)
        {
            this.js = js;
        }

        public bool IsDarkMode
        {
            get => isDarkMode;
            set {
                isDarkMode = value;
                js.InvokeVoidAsync("setDarkMode", value);
                OnChange?.Invoke();
            }
        }

        public async Task<bool> IsBrowserDarkMode() => await js.InvokeAsync<bool>("isBrowserDarkMode");

        public event Action OnChange;

        public async Task ListenForThemeChanges()
        {
            await js.InvokeVoidAsync("addThemeEventListener", DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public async Task setDarkMode(bool isDarkMode) => IsDarkMode = isDarkMode;
    }
}