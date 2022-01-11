using Microsoft.Net.Http.Headers;
using MVCWizard.Web.Application.Contracts;
using MVCWizard.Web.Application.Handlers;
using MVCWizard.Web.Application.Services;
using MVCWizard.Web.Configuration;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ValidateHeaderHandler>();

builder.Services.Configure<EmpApi>(builder.Configuration.GetSection("EmpApi"));


builder.Services.AddHttpClient<IEmployeeService,EmployeeService>("EmpApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("EmpApi:Url").Value);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    client.DefaultRequestHeaders.Add("X-API-KEY", "11223344455");
}
)
 .SetHandlerLifetime(TimeSpan.FromMinutes(3))
 .AddHttpMessageHandler<ValidateHeaderHandler>()
 .AddTransientHttpErrorPolicy(policyBuilder =>policyBuilder.WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(5)))
 .AddTransientHttpErrorPolicy(policyBuilder =>policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
