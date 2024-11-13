using Microsoft.EntityFrameworkCore;

namespace MyWebApi;

public class DataDbContext:DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }    

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(
    //         "Host=localhost;Database=mywebapi_db1;Username=mywebapi_1;Password=mywebapi_1");
    // }
}