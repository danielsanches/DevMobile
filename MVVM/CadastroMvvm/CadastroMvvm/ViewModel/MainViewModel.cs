using CadastroMvvm.Model;
using CadastroMvvm.Pages;
using CadastroMvvm.Services;
using CadastroMvvm.ViewModel.ViewBase;
using System.Windows.Input;
using Xamarin.Forms;

namespace CadastroMvvm.ViewModel
{
    public class MainViewModel : BaseViewModel<Repeticoes>
    {
        private ICommand _cadastroHorarioCommpand;

        private HorariosService _horarioService;

        public MainViewModel()
        {
            _horarioService = new HorariosService();
            PreencherLista();
        }

        public ICommand CadastroHorarioCommpand
        {
            get
            {
                return _cadastroHorarioCommpand ?? (_cadastroHorarioCommpand = new Command(() =>
                {
                    Navigation.PushAsync(new CadastroHorarioPage());
                }));
            }
        }

        private void PreencherLista()
        {
            Lista = _horarioService.ObterLista();
        }
    }
}
