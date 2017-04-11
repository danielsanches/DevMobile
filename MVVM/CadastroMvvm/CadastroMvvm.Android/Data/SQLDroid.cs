using SQLite;
using System.IO;
using CadastroMvvm.Data;
using Xamarin.Forms;
using CadastroMvvm.Droid.Data;

[assembly: Dependency(typeof(SQLDroid))]
namespace CadastroMvvm.Droid.Data
{
    public class SQLDroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqlFileName = "DbHoraRemedio.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqlFileName);
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}