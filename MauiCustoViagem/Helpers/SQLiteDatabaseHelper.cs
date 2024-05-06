using MauiCustoViagem.Models;
using SQLite;

namespace MauiCustoViagem.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Viagem>().Wait();
        }

        public Task<int> Insert(Viagem v)
        {
            return _conn.InsertAsync(v);
        }

        public Task<List<Viagem>> Update(Viagem v)
        {
            string sql = "UPDATE Viagem SET Origem=?, Destino=?, Distancia=?, Rendimento=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Viagem>(sql, v.Origem, v.Destino, v.Distancia, v.Rendimento, v.Preco, v.Id);
        }

        public Task<List<Viagem>> GetAll()
        {
            return _conn.Table<Viagem>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Viagem>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Viagem>> Search(string q)
        {
            string sql = "SELECT * FROM Viagem WHERE descricao LIKE '% " + q + "%'";
            return _conn.QueryAsync<Viagem>(sql);
        }

    }
}