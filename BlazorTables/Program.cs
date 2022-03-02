using BlazorTables.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Data.Tables;
using BlazorTables.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var connectionString = builder.Configuration.GetValue<string>("ConnectionString");
builder.Services.AddSingleton<TableClient<WeatherForecastEntity>>(new TableClient<WeatherForecastEntity>(connectionString));
builder.Services.AddTransient<ITableService<WeatherForecastEntity>, TableService<WeatherForecastEntity>>();
builder.Services.AddSingleton<TableClient<PersonEntity>>(new TableClient<PersonEntity>(connectionString));
builder.Services.AddTransient<ITableService<PersonEntity>, TableService<PersonEntity>>();
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

app.Run();
