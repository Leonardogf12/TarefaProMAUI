using TarefaPro.MAUI.MVVM.ViewModels;

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
}