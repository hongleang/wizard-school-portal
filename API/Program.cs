using Microsoft.AspNetCore.Identity;
using SchoolPortalApi.Core.Middlewares;
using SchoolPortalApi.Core.Services;
using SchoolPortalApi.Data.Entities;
using SchoolPortalAPI.Data;
using SchoolPortalAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddConfigureService(builder.Configuration);

// Seeding users

var app = builder.Build();

using var scope = app.Services.CreateScope();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
var context = scope.ServiceProvider.GetRequiredService<DataContext>();

SeedingUsers.Seeds(userManager, builder.Configuration, context);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();


