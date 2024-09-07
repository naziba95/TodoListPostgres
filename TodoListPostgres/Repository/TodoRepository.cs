using TodoListPostgres.DAL;
using TodoListPostgres.Dtos;
using TodoListPostgres.Models;

namespace TodoListPostgres.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ITodoDAL _todoDAL;

        public TodoRepository(ITodoDAL todoDAL)
        {
            _todoDAL = todoDAL;
        }
        public async Task<TodoItem> CreateTodoItem(CreateDto todoItem)
        {
            try
            {
                var Todo = new TodoItem();
                Todo.Title = todoItem.Title;
                var createdTodo = await _todoDAL.InsertAsync(Todo);
                if (createdTodo != null)
                {
                    return Todo;
                }

                else
                {
                    Todo.Title = "Error";
                    return Todo;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem> UpdateTodoItem(UpdateDto todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
