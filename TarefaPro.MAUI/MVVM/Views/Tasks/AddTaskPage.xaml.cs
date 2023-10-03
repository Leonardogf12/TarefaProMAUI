using TarefaPro.MAUI.MVVM.ViewModels.Tasks;

namespace TarefaPro.MAUI.MVVM.Views.Tasks;

public partial class AddTaskPage : ContentPage
{
	public AddTaskPage()
	{
		InitializeComponent();

		BindingContext = new AddTaskViewModel();
	}

    private async void Back_Clicked(object sender, EventArgs e)=> await Navigation.PopAsync();
       

    private void AddCategory_Clicked(object sender, EventArgs e)
    {

    }

    private void AddTask_Tapped(object sender, TappedEventArgs e)
    {

    }
}