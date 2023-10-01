using TarefaPro.MAUI.MVVM.Views.Category;

namespace TarefaPro.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(EditCategoryPage), typeof(EditCategoryPage));
        }
    }
}