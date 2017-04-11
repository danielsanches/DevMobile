using CadastroMvvm.Interfaces;
using CadastroMvvm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                
            };

            BindingContext = viewModel;
        }
    }
}
