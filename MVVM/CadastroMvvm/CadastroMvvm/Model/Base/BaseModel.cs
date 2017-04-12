using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace CadastroMvvm.Model.Base
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void VerifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void Validate();
    }
}
