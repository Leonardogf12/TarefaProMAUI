using TarefaPro.MAUI.MVVM.ViewModels.Tasks;

namespace TarefaPro.MAUI.MVVM.Views.Tasks;

public partial class EditTaskPage : ContentPage
{
	public EditTaskPage(EditTaskViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
	}

    private void EditTask_Clicked(object sender, EventArgs e)
    {

    }

    private void ActiveNotify_Toogled(object sender, ToggledEventArgs e)
    {

    }

    private async void Back_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();  
}