using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Logging;
using Presistance;

using Serilog;
using UI;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
IConfiguration configuration = builder.Configuration;
builder.Host.UseSerilog((ctx, conf, looger) =>
{
    looger.ReadFrom.Configuration(ctx.Configuration);

    //looger.ReadFrom.Configuration(configuration, "Serilog").CreateLogger();
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddPresistanceService(builder.Configuration);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(options => options.RegisterModule(new IocModule()));
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
app.UseEndpoints(options =>
{
    options.MapControllerRoute("default", "{controller=Product}/{action=Index}/{Id?}");
});

app.Run();
