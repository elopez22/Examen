using BusinessLogic.Services;
using BusinessLogic.Services.Interface;
using Microsoft.EntityFrameworkCore;
using DataAcces.DataXml.Interfaces;
using DataAcces.DataXml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<IAccesoService, AccesoService>();
builder.Services.AddScoped<IRamoService, RamoService>();
builder.Services.AddScoped<IDataXmls, DataXmls>();
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
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
// custom jwt auth middleware
//app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
