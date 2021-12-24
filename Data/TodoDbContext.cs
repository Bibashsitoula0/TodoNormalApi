using Microsoft.EntityFrameworkCore;
using ApiTodo.Models;

namespace ApiTodo.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base (options)
        {
            
        }
        public DbSet<Todo> Todo {get;set;}
        
    }
}