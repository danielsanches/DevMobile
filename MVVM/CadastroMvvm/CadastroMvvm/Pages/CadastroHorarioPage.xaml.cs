using CadastroMvvm.Interfaces;
using CadastroMvvm.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadastroMvvm.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroHorarioPage : ContentPage, IMessage
    {
        public CadastroHorarioPage()
        {
            InitializeComponent();

            var viewModel = new HorariosViewModel
            {
                Navigation = this.Navigation,
                Message = this
            };

            BindingContext = viewModel;
        }
    }
}