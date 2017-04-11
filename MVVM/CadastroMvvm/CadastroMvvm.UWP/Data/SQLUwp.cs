using CadastroMvvm.Data;
using CadastroMvvm.UWP.Data;
using SQLite;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLUwp))]
namespace CadastroMvvm.UWP.Data
{
    public class SQLUwp : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "BancoServico.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
