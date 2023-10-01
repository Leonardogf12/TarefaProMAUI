using CommunityToolkit.Maui.Views;
using TarefaPro.MAUI.MVVM.ViewModels.Category;

namespace TarefaPro.MAUI.MVVM.Views.Components.Category;

public partial class PopupCategoriesPage : Popup
{
   
    public PopupCategoriesPage(PopupCategoriesViewModel popup)
	{
		InitializeComponent();

		BindingContext = popup;
	}


}