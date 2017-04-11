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

        protected void VerifyPropertyChanged(Expression<Func<object>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;

            if (member.Member is PropertyInfo propertInfo)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertInfo.Name));

        }

        public abstract void Validate();
    }
}
