using Domain.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProfessionDriverApp.Business;
using ProfessionDriverApp.Domain.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProfessionDriverProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MsLocalDB")), ServiceLifetime.Scoped);

//Swagger
builder.Services.AddSwaggerGen(options =>
{
    List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
});

//Razor Pages
builder.Services.AddRazorPages();

//DI
Dependencies.Register(builder.Services);

//AutMapper
builder.Services.AddAutoMapper(
    typeof(EntityProfile), typeof(EmployeeProfile), typeof(DriverProfile),
    typeof(DriverWorkLogEntryProfile), typeof(InsurancePolicyProfile), typeof(LargeGoodsVehicleProfile),
    typeof(VehicleInspectionProfile), typeof(VehicleInsuranceProfile), typeof(VehicleProfile)
    );

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

//Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    // options.RoutePrefix = string.Empty; //-> route directly to swagger
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
