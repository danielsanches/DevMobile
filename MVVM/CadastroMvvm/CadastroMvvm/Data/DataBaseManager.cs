using CadastroMvvm.Model;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CadastroMvvm.Data
{
    public class DataBaseManager<T> where T : IKeyObject, new()
    {
        SQLiteConnection database;

        public DataBaseManager()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Horario>();
        }

        public void Save(T value)
        {
            database.Insert(value);
        }

        public void Alter(T value)
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Id == value.Id
                       select entry).ToList();

            database.Update(value);
        }

        public List<T> GetAll()
        {
            return database.Table<T>().ToList();
        }

        public T GetItem(int id)
        {
            var item = (from entry in database.Table<T>().AsEnumerable<T>()
                        where entry.Id == id
                        select entry).FirstOrDefault();

            return item;
        }

        public void Remove(T item)
        {
            database.Delete(item);
        }
    }
}
