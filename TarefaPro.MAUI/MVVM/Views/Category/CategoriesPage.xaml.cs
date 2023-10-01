using TarefaPro.MAUI.Helpers.Components;
using TarefaPro.MAUI.MVVM.ViewModels.Category;

namespace TarefaPro.MAUI.MVVM.Views.Category;

public partial class CategoriesPage : ContentPage
{   
    ScaleUpScaleDownHelper ScaleUpScaleDownHelper = new();

    public CategoriesPage(CategoriesViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    private async void AddCategory_Clicked(object sender, EventArgs e) => await Navigation.PushAsync(new AddCategoryPage());
    
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as CategoriesViewModel;

        vm.OnAppearing();
    }

    private async void RemoveAllCategories_Clicked(object sender, EventArgs e)
    {   
        var vm = BindingContext as CategoriesViewModel;

        var result = await DisplayAlert("Excluir", "Deseja realmente excluir tudo. Isso excluira tambem as tarefas.", "Sim", "Não");

        if (result)
            vm.RemoveAllCategories();
    }


    private async void PopupActions_Tapped(object sender, TappedEventArgs e)
    {        
        var vm = BindingContext as CategoriesViewModel;

        if (vm.HasSelectedCategory) return;

        vm.HasSelectedCategory = true;

        var element = sender as Image;

        await ScaleUpScaleDownHelper.SetScaleOnElement(element: element, scale: 0.8);

        vm.SelectedCategoryCommand.Execute(e.Parameter);
    }
}