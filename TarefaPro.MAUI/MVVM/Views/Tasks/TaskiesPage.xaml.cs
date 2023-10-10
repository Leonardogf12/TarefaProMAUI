using TarefaPro.MAUI.Helpers.Components;
using TarefaPro.MAUI.MVVM.ViewModels.Tasks;

namespace TarefaPro.MAUI.MVVM.Views.Tasks;

public partial class TaskiesPage : ContentPage
{
    ScaleUpScaleDownHelper ScaleUpScaleDownHelper = new();

   
    public TaskiesPage(TaskiesViewModel ViewModel)
	{
		InitializeComponent();
        
        BindingContext = ViewModel;
	}

        
    private async void PopupActions_Tapped(object sender, TappedEventArgs e)
    {
        var vm = BindingContext as TaskiesViewModel;
     
        View element;

        if (sender is Image)
        {
            element = sender as Image;
            await ScaleUpScaleDownHelper.SetScaleOnElement(element: element, scale: 0.8);
        }
        else
        {
            element = sender as Frame;
            await ScaleUpScaleDownHelper.SetScaleOnElement(element: element, scale: 0.99);
        }

        vm.SelectedTaskCommand.Execute(e.Parameter);
    }

    private async void RemoveAllTaskies_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as TaskiesViewModel;
       
        var result = await DisplayAlert("Excluir", "Deseja realmente excluir todas as tarefas desta categoria?", "Sim", "Não");

        if (result)
            await vm.RemoveAllTasks();
    }

    private void AddTaskie_Clicked(object sender, EventArgs e)
    {
      var vm = BindingContext as TaskiesViewModel;

        vm.GotoAddTaskPage();
    }
   
    private async void Back_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();    
   
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as TaskiesViewModel;

        vm.OnAppearing();
    }
}