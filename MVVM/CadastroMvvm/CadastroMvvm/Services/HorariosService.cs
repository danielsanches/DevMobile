using CadastroMvvm.Data;
using CadastroMvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CadastroMvvm.Services
{
    public class HorariosService
    {
        private DataBaseManager<Horario> _horario;
        private DataBaseManager<Repeticoes> _repeticoes;

        public HorariosService()
        {
            _horario = new DataBaseManager<Horario>();
            _repeticoes = new DataBaseManager<Repeticoes>();
        }

        public void Cadastrar(Horario entidade)
        {
            DateTime data = DateTime.Now;
            _horario.Update(entidade);

            List<Repeticoes> lista = new List<Repeticoes>();
            lista.Add(new Repeticoes
            {
                HorarioAlerta = new DateTime(data.Year, data.Month, data.Day, entidade.HorarioInicio.Hours, entidade.HorarioInicio.Minutes, 0)
            });

            for (int i = 0; i < entidade.DiasRecorrentes; i++)
            {
                Repeticoes temp = lista.Last();
                lista.Add(new Repeticoes
                {
                    HorarioId = entidade.Id,
                    HorarioAlerta = temp.HorarioAlerta.AddHours(entidade.HorarioRemedio)
                });
            }

            foreach (var item in lista)
                _repeticoes.Update(item);
        }

        public ObservableCollection<Repeticoes> ObterLista()
        {
            var lista = _repeticoes.GetAll();

            return new ObservableCollection<Repeticoes>(lista);
        }
    }
}
