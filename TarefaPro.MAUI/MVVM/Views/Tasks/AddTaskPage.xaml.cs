using Plugin.LocalNotification;
using TarefaPro.MAUI.MVVM.ViewModels.Tasks;

namespace TarefaPro.MAUI.MVVM.Views.Tasks;

public partial class AddTaskPage : ContentPage
{
	public AddTaskPage(AddTaskViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
	}

    private async void Back_Clicked(object sender, EventArgs e)=> await Navigation.PopAsync();

    private async void AddTask_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as AddTaskViewModel;

        var validate = await ValidateTaskToNextStep();

        if (validate)
        {
            vm.TaskName = entryName.Text;
            vm.TaskDescription = entryDescription.Text;

            await vm.AddTask();
        }
    }
   
    private async Task<bool> ValidateTaskToNextStep()
    {
        if (string.IsNullOrEmpty(entryName.Text))
        {
            await DisplayAlert("Ops", "Campo Nome é obrigatório.", "OK");
            return false;
        }

        if (string.IsNullOrEmpty(entryDescription.Text))
        {
            await DisplayAlert("Ops", "Campo Descrição é obrigatório.", "OK");
            return false;
        }      

        return true;
    }

    private void ActiveNotify_Toogled(object sender, ToggledEventArgs e)
    {
        var vm = BindingContext as AddTaskViewModel;

        var component = (Switch)sender;

        vm.IsEnabledReminder = component.IsToggled;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as AddTaskViewModel;

        //vm.OnAppearing();
    }

    private async void entryNotifyDate_DateSelected(object sender, DateChangedEventArgs e)
    {
        var dateReminder = e.NewDate;

        var vm = BindingContext as AddTaskViewModel;

        if(dateReminder > vm.DateEvent) {

            await DisplayAlert("Ops", "A data do lembrete não pode ser maior que a data do evento!. Favor verificar.", "Ok");
            entryNotifyDate.Date = DateTime.Now;
        }
    }
}