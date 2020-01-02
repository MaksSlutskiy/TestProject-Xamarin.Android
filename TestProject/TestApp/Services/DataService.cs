using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Services
{
    public class DataService
        : IDataService
    {
        private const string FileName = "File.sqlite3";
        private SQLiteAsyncConnection _connection;

        public DataService()
        {
            GetAsyncConnection();
        }




        public SQLiteAsyncConnection GetAsyncConnection()
        {
            if (_connection == null)
            {
                var databaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var databaseFilePath = Path.Combine(databaseFolder, FileName);
                _connection = new SQLiteAsyncConnection(databaseFilePath);
                _connection.CreateTableAsync<Kitten>();
            }
            return _connection;
        }

        
        public void Delete(Kitten kitten)
        {
            _connection.DeleteAsync(kitten);
        }

        public void Insert(Kitten kitten)
        {
            _connection.InsertAsync(kitten);
        }


        public void Update(Kitten kitten)
        {
            _connection.UpdateAsync(kitten);
        }

        public async Task<IEnumerable<Kitten>> GetAll()
        {
            return await _connection.Table<Kitten>()
                              .ToListAsync();
                              
        }
    }
}
