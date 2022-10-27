using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PA2022.Data;
using PA2022.Data.Context;
using PA2022.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddSqlite<Pa2022DbContext>("Data Source=.//Data//Context//localDB.db");
//Agregamos los servicios para la base de datos
builder.Services.AddScoped<IPa2022DbContext,Pa2022DbContext>();
builder.Services.AddScoped<ISolicitudesService,SolicitudesService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Pa2022DbContext>();
    if (db.Database.EnsureCreated())
    {
        
    }
}

app.Run();
