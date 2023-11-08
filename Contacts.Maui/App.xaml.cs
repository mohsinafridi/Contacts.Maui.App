using Contacts.Maui.Database;

namespace Contacts.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        public static AppDbContext Database { get; private set; }
    }
}