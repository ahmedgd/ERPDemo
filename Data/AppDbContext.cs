using Microsoft.EntityFrameworkCore;
using ERPDemo.Models;

namespace ERPDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // إضافة null-forgiving operator ! لتفادي تحذير CS8618
        public DbSet<Employee> Employees { get; set; } = null!;
    }
}
