using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreadsService.Application.Interfaces.Repositories;
using ThreadsService.Infrastructure.Contexts;
using ThreadsService.Infrastructure.Repositories;
using QueriesMediatR = ThreadsService.Application.Queries;
using CommandsMediatR = ThreadsService.Application.Commands;

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
    typeof(QueriesMediatR.GetThread.GetThreadQuery),
    typeof(CommandsMediatR.CreateThread.CreateThreadCommand),
    typeof(CommandsMediatR.UpdateThread.UpdateThreadCommand),
    typeof(CommandsMediatR.DeleteThread.DeleteThreadCommand)
});

// Dependency injection:
builder.Services.AddScoped<IQueryThreadRepository, QueryThreadRepository>();
builder.Services.AddScoped<ICommandThreadRepository, CommandThreadRepository>();


ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ThreadDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AzureConnection"),
    b => b.MigrationsAssembly("ThreadsService.API").EnableRetryOnFailure()));

// Add RabbitMQ connection:
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("host.docker.internal", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

// Configure RabbitMQ options
builder.Services.AddOptions<MassTransitHostOptions>().Configure(options =>
{
    // Below are the config defaults for RabbitMQ

    // Waits until bus is started:
    options.WaitUntilStarted = true;

    // Limit wait time when starting the bus:
    options.StartTimeout = TimeSpan.FromSeconds(10);

    // Limit wait time when stopping the bus:
    options.StopTimeout = TimeSpan.FromSeconds(30);
});

//builder.Services.AddHostedService<Worker>();

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
