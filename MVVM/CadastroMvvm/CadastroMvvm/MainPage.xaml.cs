using CadastroMvvm.Interfaces;
using CadastroMvvm.ViewModel;
using Xamarin.Forms;

namespace CadastroMvvm
{
    public partial class MainPage : ContentPage, IMessage
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModel = new MainViewModel()
            {
                Message = this,
                Navigation = Navigation
            };

            BindingContext = viewModel;
        }
    }
}
