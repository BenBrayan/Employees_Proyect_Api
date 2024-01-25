using Test_Employees_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IExternalApiService, ExternalApiService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Add configuration external APIS
builder.Services.AddHttpClient("ExternalApi", client =>
{
    var config = builder.Configuration;
    var baseUrl = config["ExternalApiSettings:BaseUrl"];
    client.BaseAddress = new Uri(baseUrl);
});

// Add Cors 
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
    builder => builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod()));

builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
