using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using DotNetTask.Models;
using DotNetTask.Services;
using DotNetTask.Models.Profiles;
using TestWebAPIProj.Models.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ProgramInformationMapper));
builder.Services.AddAutoMapper(typeof(UserApplicationMapper));
var configuration = builder.Configuration;
builder.Services.Configure<CosmosDbSettings>(builder.Configuration.GetSection("CosmosDbSettings"));
//services.AddScoped<IUserApplicationsService, UserApplicationsService>();
// Register Cosmos DB client and service
builder.Services.AddSingleton(sp =>
{
    var settings = sp.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
    return new CosmosClient(settings.EndpointUri, settings.PrimaryKey);
});

builder.Services.AddSingleton<IEmployerService>(sp =>
{
    var cosmosClient = sp.GetRequiredService<CosmosClient>();
    var settings = sp.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
    return new EmployerService(cosmosClient, settings.DatabaseName, "ProgramInformation");
});
builder.Services.AddSingleton<IApplicantService>(sp =>
{
    var cosmosClient = sp.GetRequiredService<CosmosClient>();
    var settings = sp.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
    return new ApplicantService(cosmosClient, settings.DatabaseName, "UserApplications");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
