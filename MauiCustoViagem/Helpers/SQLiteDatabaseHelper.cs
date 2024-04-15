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
            _conn.CreateTableAsync<Pedagio>().Wait();
        }

        public Task<int> Insert(Pedagio p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Pedagio>> Update(Pedagio p)
        {
            string sql = "UPDATE Pedagio SET Origem=?, Destino=?, Distancia=?, Rendimento=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Pedagio>(sql, p.Origem, p.Destino, p.Distancia, p.Rendimento, p.Preco, p.Id);
        }

        public Task<List<Pedagio>> GetAll()
        {
            return _conn.Table<Pedagio>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Pedagio>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Pedagio>> Search(string q)
        {
            string sql = "SELECT * FROM Pedagio WHERE descricao LIKE '% " + q + "%'";
            return _conn.QueryAsync<Pedagio>(sql);
        }

    }// fecha classe
}// fecha namespace