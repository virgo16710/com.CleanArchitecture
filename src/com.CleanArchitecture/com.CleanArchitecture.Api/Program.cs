using com.CleanArchitecture.Api.Extensions;
using com.CleanArchitecture.Application;
using com.CleanArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
var configuracion = builder.Configuration;
builder.Services.AddInfrastructure(configuracion);
var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ApplyMigration();
app.MapControllers();



app.Run();


