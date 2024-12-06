using ThalesAssesment.Business.Repositories;
using ThalesAssesment.Business.Services;
using ThalesAssesment.Business.Repositories.Interfaces;
using ThalesAssesment.Model.Helpers;
using ThalesAssesment.Model.Helpers.Interfaces;
using ThalesAssesment.Business.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// CORS
var AllowAllOrigins = "AllowAllOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllOrigins, builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

var baseUrl = builder.Configuration["Urls:baseUrl"];
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IHttpHelper, HttpHelper>(client =>
{
    client.BaseAddress = new Uri(baseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(provider =>
{
    var http = provider.GetService<IHttpHelper>();
    return new EmployeeRepository(http, baseUrl);
});
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    // Logging
    builder.Logging.AddConsole().AddDebug();

    // OpenAPI
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
        }
    );
}

app.UseCors(AllowAllOrigins);

app.UseAuthorization();
app.MapControllers();

app.Run();
