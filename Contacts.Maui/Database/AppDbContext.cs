using Contacts.Maui.Models;
using SQLite;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Database
{
    public class AppDbContext : IAsyncDisposable
    {
        public SQLiteAsyncConnection _dbConnection;

        // Application Database
        public readonly static string nameSpace = "Contacts.Maui.Database.AppDbContext.";

        public const string DatabaseFilename = "contact-db.db3";

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public AppDbContext()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new SQLiteAsyncConnection(DatabasePath, Flags);
                _dbConnection.CreateTableAsync<Department>(); //table 1
                _dbConnection.CreateTableAsync<Contact>(); //table 2
            }
        }


        public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.ToListAsync();
        }
       

        public async Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync<TEntity>(TEntity entity) where TEntity : class,new()
        {
            return await _dbConnection.UpdateAsync(entity) > 0;
        }

        public async Task<bool> DeleteAsysnc<TEntity>(TEntity entity) where TEntity : class, new()
        {
            return await _dbConnection.DeleteAsync(entity) > 0;
        }
        public async Task<bool> DeleteItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await _dbConnection.DeleteAsync<TTable>(primaryKey) > 0;
        }

        public async Task<int> AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.InsertOrReplaceAsync(entity);
        }

        public async Task<List<Department>> GetAll()
        {
            return await _dbConnection.Table<Department>().ToListAsync();
        }        

        public async  ValueTask DisposeAsync()
        {
            await _dbConnection?.CloseAsync();
        }

        private async Task<AsyncTableQuery<TTable>> GetTableAsync<TTable>() where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return _dbConnection.Table<TTable>();
        }

        private async Task CreateTableIfNotExists<TTable>() where TTable : class, new()
        {
            await _dbConnection.CreateTableAsync<TTable>();
        }
    }
}
