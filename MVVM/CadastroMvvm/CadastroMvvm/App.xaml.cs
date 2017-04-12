using Xamarin.Forms;

namespace CadastroMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new CadastroMvvm.MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
