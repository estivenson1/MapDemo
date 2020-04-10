using MapDemoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MapDemoApp.Services
{
    public class DbService
    {
       public static DbService Api = new DbService();

       
        string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
        SQLiteAsyncConnection _database;

        public DbService()
        {
            InitializeAsync();
        }

        private void InitializeAsync()
        {
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Stock>().Wait();
            _database.CreateTableAsync<Valuation>().Wait();
        }

        #region Methods	
        public async Task<bool> InsertAsync<T>(T model) => (await _database.InsertAsync(model)) > 0;
        

        public async Task<bool> UpdateAsync<T>(T model)
        {
            return (await _database.UpdateAsync(model)) > 0;
        }

        public async Task<bool> DeleteAsync<T>(T model)
        {
            return (await _database.DeleteAsync(model)) > 0;
        }

        public AsyncTableQuery<T> QueryTable<T>(Expression<Func<T, bool>> filter) where T : new()
        {
            var r= _database.Table<T>().Where(filter);
            return r;
        }

        public Task<List<T>> GetItemsAsync<T>() where T : new()
        {
            return _database.Table<T>().ToListAsync();
        }

        //public Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : new()
        //{
        //    return ReadAsync(conn => conn.Get<T>(predicate));
        //}

        #endregion

    }
}
