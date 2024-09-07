using Dapper;
using System.Collections;
using System.Data;
using TodoListPostgres.Models;

namespace TodoListPostgres.DAL
{
    public class TodoDAL : ITodoDAL
    {
        private readonly IDbConnection _dbConn;

        public TodoDAL(IDbConnection dbConn)
        {
            _dbConn = dbConn;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            var query = "SELECT * FROM TodoItems";
            return await _dbConn.QueryAsync<TodoItem>(query);
        }

        public async Task<TodoItem> GeSingleAsync(int Id)
        {
            var query = "SELECT * FROM TodoItems WHERE Id = @Id";
            return await _dbConn.QueryFirstOrDefaultAsync<TodoItem>(query, new { Id = Id});
        }

        public async Task<int> InsertAsync(TodoItem todoItem)
        {
            var query = "INSERT INTO TodoItems (Title, IsComplete) VALUES (@Title, @IsComplete) RETURNING Id";
            return await _dbConn.ExecuteScalarAsync<int>(query, todoItem);
        }

        public async Task<int> UpdateAsync(TodoItem todoItem)
        {
            var query = "UPDATE TodoItems SET Title = @Title,IsComplete = @IsComplete WHERE Id=@Id";
            return await _dbConn.ExecuteAsync(query, todoItem);
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var query = "DELETE FROM TodoItems WHERE Id=@Id";
            return await _dbConn.ExecuteAsync(query, new { Id = Id});
        }
    }
}
