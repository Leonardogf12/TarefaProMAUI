namespace TarefaPro.MAUI.MVVM.Views;

public partial class AddCategoryPage : ContentPage
{
	public AddCategoryPage()
	{
		InitializeComponent();
	}

    private async void Back_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private void AddCategory_Clicked(object sender, EventArgs e)
    {

    }
}