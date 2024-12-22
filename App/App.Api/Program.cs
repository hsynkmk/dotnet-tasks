using App.Application.Interfaces;
using App.Application.Services;
using App.Infrastructure.Extensions;
using App.Infrastructure.Seeders;
using App.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICourseService, CourseService>();

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
