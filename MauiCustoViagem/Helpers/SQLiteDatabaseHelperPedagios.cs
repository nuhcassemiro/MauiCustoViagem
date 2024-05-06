using MauiCustoViagem.Models;
using SQLite;

namespace MauiCustoViagem.Helpers
{
    public class SQLiteDatabaseHelperPedagios
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelperPedagios(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<PedagioModel>().Wait();
        }
        public Task<int> Insert(PedagioModel p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<PedagioModel>> Update(PedagioModel p)
        {
            string sql = "UPDATE Pedagio SET Local=?, Valor=?, IdViagem=? WHERE Id=?";
            return _conn.QueryAsync<PedagioModel>(sql, p.Local, p.Valor, p.IdViagem, p.Id);
        }

        public Task<List<PedagioModel>> GetAll()
        {
            return _conn.Table<PedagioModel>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<PedagioModel>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<PedagioModel>> Search(string q)
        {
            string sql = "SELECT * FROM Pedagio WHERE descricao LIKE '% " + q + "%'";
            return _conn.QueryAsync<PedagioModel>(sql);
        }
    }
}