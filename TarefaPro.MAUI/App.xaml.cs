using TarefaPro.MAUI.Data;

namespace TarefaPro.MAUI
{
    public partial class App : Application
    {       
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        #region DATABASE

        private static DbApp _dbApp;

        public static DbApp DbApp
        {
            get
            {
                if (_dbApp == null)
                {
                    _dbApp = new DbApp(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tarefaprodb.db3"));
                }

                return _dbApp;
            }
        }

        public const string dbPath = "/data/user/0/com.companyname.tarefapro.maui/files/tarefaprodb.db3";
        
        #endregion
    }
}