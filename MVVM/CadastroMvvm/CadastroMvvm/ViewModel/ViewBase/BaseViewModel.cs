using CadastroMvvm.Interfaces;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace CadastroMvvm.ViewModel.ViewBase
{
    public class BaseViewModel : BaseViewModel<object> { }

    public class BaseViewModel<T> : INotifyPropertyChanged where T : class, new()
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IMessage Message { get; set; }
        public INavigation Navigation { get; set; }

        private T _entidade;

        protected T Endidade
        {
            get { return _entidade; }
            set
            {
                _entidade = value;
                VerifyPropertyChanged(() => Endidade);
            }
        }

        public BaseViewModel()
        {
            Endidade = new T();
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
