using TarefaPro.MAUI.MVVM.ViewModels;

namespace TarefaPro.MAUI.MVVM.Views;

public partial class AddCategoryPage : ContentPage
{
    public AddCategoryViewModel ViewModel = new();

    public AddCategoryPage()
    {
        InitializeComponent();

        BindingContext = ViewModel;
    }

    private async void Back_Clicked(object sender, EventArgs e) => await Navigation.PopAsync();

    private void AddCategory_Clicked(object sender, EventArgs e)
    {
    }

    private void checkgreen_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsGreenSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsGreenSelected = true;

        SetDefaultColor(green: "green_check", buttonBackground: "#29B885");
    }

    private void checkblue_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsBlueSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsBlueSelected = true;

        SetDefaultColor(blue: "blue_check", buttonBackground: "#11B7F3");
    }

    private void checksalmon_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsSalmonSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsSalmonSelected = true;

        SetDefaultColor(salmon: "salmon_check", buttonBackground: "#FE866A");
    }

    private void checkyellow_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsYellowSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsYellowSelected = true;

        SetDefaultColor(yellow: "yellow_check", buttonBackground: "#EEC233");
    }

    private void checkorange_Tapped(object sender, TappedEventArgs e)
    {
        if (ViewModel.IsOrangeSelected)
        {
            ViewModel.GetDefaultLayoutSettings();
            return;
        }

        ViewModel.IsOrangeSelected = true;

        SetDefaultColor(orange: "orange_check", buttonBackground: "#EEA333");
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