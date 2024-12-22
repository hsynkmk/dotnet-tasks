using App.Infrastructure.Extensions;
using App.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Seed database
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ICourseSeeder>();
await seeder.Seed();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
