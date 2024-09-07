using TodoListPostgres.Dtos;
using TodoListPostgres.Models;

namespace TodoListPostgres.Repository
{
    public interface ITodoRepository
    {
        Task<TodoItem> GetByIdAsync(int id);
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> CreateTodoItem(CreateDto todoItem);
        Task<TodoItem> UpdateTodoItem(UpdateDto todoItem);
        void DeleteAsync(int id);
    }
}
