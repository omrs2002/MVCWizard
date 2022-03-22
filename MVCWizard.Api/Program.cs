using MVCWizard.Api.Application.Contracts;
using MVCWizard.Api.Data;
using MVCWizard.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          ;
                      });
});


builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//add swagger:
builder.Services.AddSwaggerGen(
    c =>
    {
        //c.CustomSchemaIds(i => i.FullName);
        c.CustomSchemaIds(type => type.FriendlyId().Replace("[", "Of").Replace("]", ""));
        c.CustomOperationIds(options => $"{options.ActionDescriptor.RouteValues["controller"]}{options.ActionDescriptor.RouteValues["action"]}");
    }
    );

builder.Logging.ClearProviders();

builder.Logging.AddConsole();

builder.Services.AddDbContext<EmployeeDBContext>();


builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "10.1.1.132:6300";
});

var app = builder.Build();


app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
