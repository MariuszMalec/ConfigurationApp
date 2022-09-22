using ConfigurationApp.Configuration;
using ConfigurationApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dodalem
builder.Services.AddScoped<SampleService>();

//1
//builder.Services.Configure<ServiceConfiguration>(
//    builder.Configuration.GetSection(ServiceConfiguration.SectionName));

//3 ,  2 patrz SampleService validation
//builder.Services.AddOptions<ServiceConfiguration>()
//    .Configure<IConfiguration>((serviceConfig, configuration) =>
//    {
//        var configSection = configuration.GetSection(ServiceConfiguration.SectionName);
//        configSection.Bind("serviceConfig");

//        if (string.IsNullOrEmpty(serviceConfig.ApiKey))
//        {
//            throw new ArgumentNullException("serviceconfiguration ApiKey is missing!");
//        }
//    });

//4 validation in class as attribute
builder.Services.AddOptions<ServiceConfiguration>()
    .Bind(builder.Configuration.GetSection(ServiceConfiguration.SectionName))
    .ValidateDataAnnotations();


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