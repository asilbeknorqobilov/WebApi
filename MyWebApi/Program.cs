using Microsoft.EntityFrameworkCore;
using MyWebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=mywebapi_db1;Username=mywebapi_1;Password=mywebapi_1"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();


app.Run();

