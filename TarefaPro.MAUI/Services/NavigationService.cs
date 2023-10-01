using TarefaPro.MAUI.Helpers.Components;

namespace TarefaPro.MAUI.Services
{
    public class NavigationService : INavigationService
    {       
        ScaleUpScaleDownHelper _scaleDownHelper = new();

        public bool IsBrowsing = false;

        public async Task NavigationToPageAsync<T>(Dictionary<string, object> parameters = null,
                                                   View component = null) where T : IView
        {
            if (IsBrowsing) return;

            IsBrowsing = true;

            var typeView = typeof(T);

            await Shell.Current.GoToAsync($"{typeView.Name}", parameters);

            IsBrowsing = false;
        }

        public async Task GoBackAsync(string quantityReturn, View component = null)
        {
            if (component != null)
                await _scaleDownHelper.SetScaleOnElement(component);

            // "..\\.."            
            await Shell.Current.GoToAsync(quantityReturn);
        }
    }
}
