using SQLite;

namespace ReiseApp;

public class LocalDBService
{

        private const string DB_NAME = "reise";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Reise>();

        }

        public async Task<List<Reise>> GetReise()
        {
            return await _connection.Table<Reise>().ToListAsync();
        }

        public async Task<Reise> GetById(int id)
        {
            return await _connection.Table<Reise>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Reise reise)
        {
            await _connection.InsertAsync(reise);
        }

        public async Task Update(Reise reise)
        {
            await _connection.UpdateAsync(reise);
        }

        public async Task Delete(Reise reise)
        {
            await _connection.DeleteAsync(reise);
        }
}



