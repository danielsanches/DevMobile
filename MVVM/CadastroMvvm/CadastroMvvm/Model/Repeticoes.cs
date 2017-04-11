using CadastroMvvm.Data;
using CadastroMvvm.Model.Base;
using SQLite;
using System;

namespace CadastroMvvm.Model
{
    public class Repeticoes : BaseModel, IKeyObject
    {
        private DateTime _horarioAlerta;

        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [NotNull]
        public int HorarioId { get; set; }

        [NotNull]
        public DateTime HorarioAlerta
        {
            get { return _horarioAlerta; }
            set
            {
                _horarioAlerta = value;
                VerifyPropertyChanged(() => HorarioAlerta);
            }
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
