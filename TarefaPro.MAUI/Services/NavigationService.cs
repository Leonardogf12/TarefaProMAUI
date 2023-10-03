using TarefaPro.MAUI.Helpers.Components;

namespace TarefaPro.MAUI.Services
{
    public class NavigationService : INavigationService
    {
        ScaleUpScaleDownHelper _scaleDownHelper = new();

        public bool IsBrowsing = false;

        public async Task NavigationToPageAsync<T>(Dictionary<string, object> parameters,
                                                   View component = null) where T : IView
        {
            if (IsBrowsing) return;

            IsBrowsing = true;

            var typeView = typeof(T);


            if (parameters != null)
                await Shell.Current.GoToAsync($"{typeView.Name}", parameters);
            else
                await Shell.Current.GoToAsync($"{typeView.Name}");

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
