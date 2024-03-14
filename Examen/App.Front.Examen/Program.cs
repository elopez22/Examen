using App.Front.Examen.BusinessLogic.Services;
using App.Front.Examen.BusinessLogic.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var configValue = builder.Configuration.GetValue<string>("SecurityApi");
var timeput = builder.Configuration.GetValue<string>("ApiTimeout");
builder.Services.AddHttpClient("ApiExamen", client =>
{
    client.BaseAddress = new Uri(configValue);
    client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeput));
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});
builder.Services.AddScoped<IAccesoService, AccesoService>();
builder.Services.AddScoped<ICallApiService, CallApiService>();
builder.Services.AddScoped<IRamoService, RamoService>();
builder.Services.AddScoped<IProductosService, ProductosService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Index}/{id?}");

app.Run();
