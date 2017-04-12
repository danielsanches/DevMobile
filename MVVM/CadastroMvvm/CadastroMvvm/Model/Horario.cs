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
        private double _horarioRemedio;
        private int _diasRecorrentes;
        private TimeSpan _horarioInicio = new TimeSpan(8,30,0);

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
                VerifyPropertyChanged("Remedio");
            }
        }

        [NotNull]
        public double HorarioRemedio
        {
            get { return _horarioRemedio; }
            set
            {
                _horarioRemedio = value;
                VerifyPropertyChanged("HorarioRemedio");
            }
        }

        [NotNull]
        public int DiasRecorrentes
        {
            get { return _diasRecorrentes; }
            set
            {
                _diasRecorrentes = value;
                VerifyPropertyChanged("DiasRecorrentes");
            }
        }

        [NotNull]
        public TimeSpan HorarioInicio
        {
            get { return _horarioInicio; }
            set
            {
                _horarioInicio = value;
                VerifyPropertyChanged("HorarioInicio");
            }
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Remedio))
                throw new RequiredException("Favor informar o nome do remédio");

            if (HorarioRemedio <= 0)
                throw new RequiredException("Favor informar um horário.");

            if (DiasRecorrentes <= 0)
                throw new RequiredException("Favor informar os dias recorrentes.");

        }
    }
}
