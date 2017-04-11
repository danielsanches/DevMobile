using System;

namespace CadastroMvvm.Exceptions
{
    public class RequiredException : Exception
    {
        public RequiredException(string message) : base(message) { }
    }
}
