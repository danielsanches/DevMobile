using CadastroMvvm.Data;
using CadastroMvvm.Exceptions;
using CadastroMvvm.Model.Base;
using SQLite;
using System;

namespace CadastroMvvm.Model
{
    public class Horario : BaseModel, IKeyObject
    {
        private string _remdeio;
        private DateTime _horarioRemedio;
        private int _diasRecorrentes;

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(60)]
        public string Remedio
        {
            get { return _remdeio; }
            set
            {
                _remdeio = value;
                VerifyPropertyChanged(() => Remedio);
            }
        }

        [NotNull]
        public DateTime HorarioRemedio
        {
            get { return _horarioRemedio; }
            set
            {
                _horarioRemedio = value;
                VerifyPropertyChanged(() => HorarioRemedio);
            }
        }

        [NotNull]
        public int DiasRecorrentes
        {
            get { return _diasRecorrentes; }
            set
            {
                _diasRecorrentes = value;
                VerifyPropertyChanged(() => DiasRecorrentes);
            }
        }

        public override void Validate()
        {
            if (DiasRecorrentes <= 0)
                throw new RequiredException("Favor informar os dias recorrentes.");

            if (HorarioRemedio < DateTime.Now)
                throw new RequiredException("Favor informar um horário valido.");

            if (string.IsNullOrEmpty(Remedio))
                throw new RequiredException("Favor informar o nome do remédio");
        }
    }
}
