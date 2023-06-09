using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Lakeshore.SendUnplannedReturn.Infrastructure.EntityModelConfiguration;
using Lakeshore.SendUnplannedReturn.Infrastructure.SendUnplannedReturn;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Lakeshore.SendUnplannedReturn.Infrastructure.DomainEventsDispatching;
using Lakeshore.SendUnplannedReturn.Infrastructure;
using Lakeshore.SendUnplannedReturn.Domain;
using Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn.Command.UpdateOrder;
using Lakeshore.SendUnplannedReturn.Application.SendUnplannedReturn;
using Lakeshore.Kafka.Client;
using Lakeshore.Kafka.Client.Interfaces;
using Lakeshore.Kafka.Client.Implementation;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(RunHrtPickupUnplannedReturnCommandHandler).Assembly));
builder.Services.AddTransient<IHrt_dtlQueryRepository, Hrt_dtlQueryRepository>();
builder.Services.AddTransient<IHrt_hdrQueryRepository, Hrt_hdrQueryRepository>();
builder.Services.AddTransient<IDomainEventsAccessor,DomainEventsAccessor>();
builder.Services.AddTransient<ICommandUnitOfWork,CommandUnitOfWork>();

builder.Services.Configure<ProducerSettings>(configuration.GetSection("KafkaSettings:ProducerSettings"));

var logger = new LoggerConfiguration()
    // Read from appsettings.json
    .ReadFrom.Configuration(configuration)
    // Create the actual logger
    .CreateLogger();

builder.Host.UseSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var options = configuration.GetAWSOptions();
options.Credentials = new BasicAWSCredentials(configuration.GetSection("DynamoDb:AccessKey").Value, configuration.GetSection("DynamoDb:SecretKey").Value);
builder.Services.AddAWSService<IAmazonDynamoDB>(options);

builder.Services.AddHealthChecks();

builder.Services.AddScoped<IKafkaProducerClient, KafkaProducerClient>();

builder.Services.AddDbContext<UnplannedReturnDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("/healthz");

app.MapControllers();

app.Run();
