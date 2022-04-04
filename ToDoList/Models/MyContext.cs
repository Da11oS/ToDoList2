using Microsoft.EntityFrameworkCore;

namespace ToDoList
{
    public class MyContext : DbContext
    {
        public DbSet<Models.ToDoList> ToDoLists { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        // Уставновка ef tool'а
        // cmd > dotnet tool install --global dotnet-ef

        // Создание миграций
        // cmd> dotnet ef --startup-project  ./ToDoList migrations add init
        // cmd> dotnet ef --startup-project  ./ToDoList database update
    }
}
