using ChitChat.Application.Mapping;
using TestWebApplication.Data;
using TestWebApplication.Helpers;
using TestWebApplication.Middlewares;
using TestWebApplication.Repositories;
using TestWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Entity Framework Core
builder.AddEntityFramewordCore();
// Add Mapping
builder.Services.AddAutoMapper(typeof(IMappingProfileMarker));
// Add Repository
builder.Services.AddRepositories();
// Add Services
builder.Services.AddServices();

var app = builder.Build();

// Apply middleware
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await MigrationAutomation.ApplyMigration(app);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
