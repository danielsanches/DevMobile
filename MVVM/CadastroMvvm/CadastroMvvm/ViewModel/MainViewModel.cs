using CadastroMvvm.Pages;
using CadastroMvvm.ViewModel.ViewBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CadastroMvvm.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand _cadastroHorarioCommpand;

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
    }
}
