using CadastroMvvm.Interfaces;
using CadastroMvvm.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace CadastroMvvm.ViewModel.ViewBase
{
    //public class BaseViewModel : BaseViewModel<object> { }

    public class BaseViewModel<T> : INotifyPropertyChanged where T : class, new()
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IMessage Message { get; set; }
        public INavigation Navigation { get; set; }
        private ObservableCollection<Repeticoes> _lista = new ObservableCollection<Repeticoes>();

        private T _entidade;

        public T Entidade
        {
            get { return _entidade; }
            set
            {
                _entidade = value;
                VerifyPropertyChanged("Entidade");
            }
        }

        public ObservableCollection<Repeticoes> Lista
        {
            get { return _lista; }
            set
            {
                _lista = value;
                VerifyPropertyChanged("Lista");
            }
        }

        public BaseViewModel()
        {
            Entidade = new T();
        }

        protected void VerifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        
        
        protected void VerifyPropertyChanged(Expression<Func<T>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;

            if (member.Member is PropertyInfo propertInfo)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertInfo.Name));
        }
    }
}
