using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Infrastructure.Contexts;
using ThreadsService.Infrastructure.Repositories;
using QueriesMediatR = ThreadsService.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR dependencies:
builder.Services.AddMediatR(new Type[]
{
    typeof(QueriesMediatR.GetAllThreads.GetAllThreadsQuery),
    typeof(QueriesMediatR.GetThread.GetThreadQuery)
});

// Dependency injection:
builder.Services.AddScoped<IQueryThreadRepository, QueryThreadRepository>();


ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ThreadDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AzureConnection"),
    b => b.MigrationsAssembly("ThreadsService.API").EnableRetryOnFailure()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ThreadDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
