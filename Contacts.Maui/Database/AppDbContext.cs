using Contacts.Maui.Models;
using SQLite;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Database
{
    public class AppDbContext
    {
        public SQLiteAsyncConnection _dbConnection;

        // Application Database
        public readonly static string nameSpace = "AzamRealEstate.DbContext.";

        public const string DatabaseFilename = "AzamRealEstate.db3";

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
        public static string dtabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public AppDbContext()
        {
            if (_dbConnection == null)
            {
                _dbConnection = new SQLiteAsyncConnection(dtabasePath, Flags);
                _dbConnection.CreateTableAsync<Department>(); //table 1
                _dbConnection.CreateTableAsync<Contact>(); //table 2
            }
        }

        public async Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsysnc<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.DeleteAsync(entity);
        }


        public async Task<int> AddOrUpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConnection.InsertOrReplaceAsync(entity);
        }

        public List<T> GetTableRows<T>(string tableName)
        {

            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(nameSpace + tableName));
            string query = "SELECT * FROM [" + tableName + "]";

            return _dbConnection.QueryAsync(map, query, obj).Result.Cast<T>().ToList();

        }

        public object GetTableRow(string tableName, string column, string value)
        {

            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(nameSpace + tableName));
            string query = "SELECT * FROM " + tableName + " WHERE " + column + "='" + value + "'";

            return _dbConnection.QueryAsync(map, query, obj).Result.FirstOrDefault();

        }
    }
}
