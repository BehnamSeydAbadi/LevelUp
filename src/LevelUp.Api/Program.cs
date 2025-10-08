using LevelUp.Api.Endpoints.Activities;
using LevelUp.Api.Endpoints.Rewards;
using LevelUp.Application;
using LevelUp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(_ => { });

ApplicationBootstrapper.Run(builder.Services);
InfrastructureBootstrapper.Run(builder.Services, builder.Configuration);

var app = builder.Build();

InfrastructureBootstrapper.ApplyMigrations(app);

const string version = "v1";

ActivityEndpoints.Map(app, version);
RewardEndpoints.Map(app, version);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(_ => { });
}

app.Run();