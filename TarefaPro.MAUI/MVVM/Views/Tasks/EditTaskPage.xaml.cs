using TarefaPro.MAUI.MVVM.ViewModels.Tasks;

namespace TarefaPro.MAUI.MVVM.Views.Tasks;

public partial class EditTaskPage : ContentPage
{
	public EditTaskPage(EditTaskViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
	}

    private async void EditTask_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as EditTaskViewModel;

        await vm.OnEditTaskCommand();
    }
   
    private async void Back_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();

    private void ActiveNotify_Toogled(object sender, ToggledEventArgs e)
    {
        var vm = BindingContext as EditTaskViewModel;

        var component = (Switch)sender;

        vm.IsEnabledReminder = component.IsToggled;
    }
}