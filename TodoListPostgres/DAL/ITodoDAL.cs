using TodoListPostgres.Models;

namespace TodoListPostgres.DAL
{
    public interface ITodoDAL
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GeSingleAsync(int Id);
        Task<int> InsertAsync(TodoItem todoItem);
        Task<int> UpdateAsync(TodoItem todoItem);
        Task<int> DeleteAsync(int Id);
    }
}
