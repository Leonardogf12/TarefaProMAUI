using CommunityToolkit.Maui.Views;
using TarefaPro.MAUI.MVVM.ViewModels;
using TarefaPro.MAUI.MVVM.Views.Components.Common;

namespace TarefaPro.MAUI.MVVM.Views;

public partial class CategoriesPage : ContentPage
{
    public CategoriesViewModel ViewModel = new();

    public CategoriesPage()
    {
        InitializeComponent();

        BindingContext = ViewModel;
    }

    private async void AddCategory_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCategoryPage());
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();

        ViewModel.OnAppearing();
    }

    private async void RemoveAllCategories_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Excluir", "Deseja realmente excluir tudo. Isso excluira tambem as tarefas.", "Sim", "Não");

        if (result)
            ViewModel.RemoveAllCategories();
    }
   
    private async void PopupActions_TapGesture(object sender, TappedEventArgs e)
    {
        Popup PopupListActionsControl = new PopupCategoriesPage(null);

        await App.Current.MainPage.ShowPopupAsync(PopupListActionsControl);
    }
}