namespace CadastroMvvm.Data
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
