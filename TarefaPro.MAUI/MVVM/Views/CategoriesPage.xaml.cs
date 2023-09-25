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
}