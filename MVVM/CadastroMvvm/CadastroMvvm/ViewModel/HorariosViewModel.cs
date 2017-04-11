using CadastroMvvm.Exceptions;
using CadastroMvvm.Model;
using CadastroMvvm.Services;
using CadastroMvvm.ViewModel.ViewBase;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CadastroMvvm.ViewModel
{
    public class HorariosViewModel : BaseViewModel<Horario>
    {
        private ICommand _salvarCommand;
        private HorariosService _horarioService;

        public HorariosViewModel()
        {
            _horarioService = new HorariosService();
        }

        public ICommand SalvarCommand
        {
            get
            {
                return _salvarCommand ?? (_salvarCommand = new Command(() =>
                {
                    Salvar();
                }));
            }
        }

        public void Salvar()
        {
            try
            {
                Endidade.Validate();
                _horarioService.Cadastrar(Endidade);
                Message.DisplayAlert("Alerta", "Lembrete cadastrado com sucesso.", "Ok");
            }
            catch (RequiredException ex)
            {
                Message.DisplayAlert("Alerta", ex.Message, "Ok");
            }
            catch (Exception ex)
            {
                Message.DisplayAlert("Erro", "Erro ao salvar registro", "Ok");
            }
        }
    }
}
