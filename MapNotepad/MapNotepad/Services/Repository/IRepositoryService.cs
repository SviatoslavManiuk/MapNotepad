using System.Threading.Tasks;
using MapNotepad.Model;
using SQLite;

namespace MapNotepad.Services.Repository
{
    public interface IRepositoryService
    {
        Task<int> InsertAsync<T>(T entity) where T: IEntityBase, new();
        
        Task<int> UpdateAsync<T>(T entity) where T : IEntityBase, new();
        
        Task<int> DeleteAsync<T>(T entity) where T : IEntityBase, new();

        AsyncTableQuery<T> GetTable<T>() where T : IEntityBase, new();

        Task<T> FindWithQueryAsync<T>(string query, params object[] args) where T : IEntityBase, new ();
    }
}