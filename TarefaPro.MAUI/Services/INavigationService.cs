namespace TarefaPro.MAUI.Services
{
    public interface INavigationService
    {
        Task NavigationToPageAsync<T>(Dictionary<string, object> parameters, View view = null) where T : IView;
        Task GoBackAsync(string quantityReturn, View component = null);
    }
}
