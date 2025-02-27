using Microsoft.EntityFrameworkCore;
using MVCToDoList.Models;

namespace MVCToDoList.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDoItem> TodoItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

    }
}
