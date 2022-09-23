using ConfigurationApp.Configuration;
using ConfigurationApp.Services;
using Microsoft.Extensions.Options;

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

//4 validation in class as attribute and additional validations according you
//builder.Services.AddOptions<ServiceConfiguration>()
//    .Bind(builder.Configuration.GetSection(ServiceConfiguration.SectionName))
//    .ValidateDataAnnotations()
//    .Validate((config) =>
//    {
//        return config.ApiKey.Length > 6;
//    },"Apikey value has to be lenght more than 6!");

//5 special classes custom validator
builder.Services.AddOptions<ServiceConfiguration>()
    .Bind(builder.Configuration.GetSection(ServiceConfiguration.SectionName));
  //.ValidateOnStart();//od razu na starcie apki

builder.Services.AddSingleton<IValidateOptions<ServiceConfiguration>, ServiceConfigurationValidator>();

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
