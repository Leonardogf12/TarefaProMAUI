using TarefaPro.MAUI.Controls;
using TarefaPro.MAUI.MVVM.ViewModels.Category;

namespace TarefaPro.MAUI.MVVM.Views.Category;

public partial class AddCategoryPage : ContentPage
{
    public AddCategoryViewModel ViewModel = new();

    public AddCategoryPage()
    {
        InitializeComponent();

        BindingContext = ViewModel;
    }

    private async void Back_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();

    private async void AddCategory_Clicked(object sender, EventArgs e)
    {
        var validate = await ValidateCategoryToNextStep();

        if (validate)
        {
            ViewModel.Name = entryName.Text;
            ViewModel.Description = entryDescription.Text;

            await ViewModel.AddCategory();
        }            
    }

    private async Task<bool> ValidateCategoryToNextStep()
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
                    
        if (string.IsNullOrEmpty(entryDescription.Text) && string.IsNullOrEmpty(entryDescription.Text))
        {
            await DisplayAlert("Ops", "Preencha corretamente os campos.", "OK");
            return false;
        }

        return true;
    }

    private void checkgreen_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsGreenSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsGreenSelected = true;

        SetDefaultColor(green: StringConstants.IconGreenName, 
                        buttonBackground: StringConstants.ColorGreenHex);

        ViewModel.IconSelected = StringConstants.IconGreenName;
        ViewModel.ColorFrame = StringConstants.ColorGreenHex;
    }

    private void checkblue_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsBlueSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsBlueSelected = true;

        SetDefaultColor(blue: StringConstants.IconBlueName, buttonBackground: StringConstants.ColorBlueHex);

        ViewModel.IconSelected = StringConstants.IconBlueName;
        ViewModel.ColorFrame = StringConstants.ColorBlueHex;
    }

    private void checksalmon_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsSalmonSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsSalmonSelected = true;

        SetDefaultColor(salmon: StringConstants.IconSalmonName, 
                        buttonBackground: StringConstants.ColorSalmonHex);

        ViewModel.IconSelected = StringConstants.IconSalmonName;
        ViewModel.ColorFrame = StringConstants.ColorSalmonHex;
    }

    private void checkyellow_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsYellowSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsYellowSelected = true;

        SetDefaultColor(yellow: StringConstants.IconYellowName, 
                        buttonBackground: StringConstants.ColorYellowHex);

        ViewModel.IconSelected = StringConstants.IconYellowName;
        ViewModel.ColorFrame = StringConstants.ColorYellowHex;
    }

    private void checkorange_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsOrangeSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsOrangeSelected = true;

        SetDefaultColor(orange: StringConstants.IconOrangeName, 
                        buttonBackground: StringConstants.ColorOrangeHex);

        ViewModel.IconSelected = StringConstants.IconOrangeName;
        ViewModel.ColorFrame = StringConstants.ColorOrangeHex;
    }

    private void SetDefaultColor(string green = "green_not_check",
                                 string blue = "blue_not_check",
                                 string salmon = "salmon_not_check",
                                 string yellow = "yellow_not_check",
                                 string orange = "orange_not_check",
                                 string buttonBackground = "#919191")    
    {
    
        ViewModel.GreenCheckImageSource = ImageSource.FromFile(green);
        ViewModel.BlueCheckImageSource = ImageSource.FromFile(blue);
        ViewModel.SalmonCheckImageSource = ImageSource.FromFile(salmon);
        ViewModel.YellowCheckImageSource = ImageSource.FromFile(yellow);
        ViewModel.OrangeCheckImageSource = ImageSource.FromFile(orange);
        ViewModel.BackgroundColorButtonNew = Color.FromRgba(buttonBackground);       
    }
}