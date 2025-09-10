using BilleteraVirtual.BD.Datos;
using BilleteraVirtual.BD.Datos.Entidades;
using BilleteraVirtual.Repositorio.Repositorios;
using BilleteraVirtual.Server.Client.Pages;
using BilleteraVirtual.Server.Components;
using Microsoft.EntityFrameworkCore;

//congigura el constructor de la aplicacion
var builder = WebApplication.CreateBuilder(args);

#region Configura el constructor de la aplicacion y sus servicios

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConexionSqlServer")
                            ?? throw new InvalidOperationException(
                                    "El string de conexion no existe.");
builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));


//builder.Services.AddScoped<IRepositorio<Extraccion>, Repositorio<Extraccion>>();
builder.Services.AddScoped<IMonedaRepositorio, MonedaRepositorio>();
builder.Services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
builder.Services.AddScoped<ICompraRepositorio, CompraRepositorio>();
builder.Services.AddScoped<ITransferenciaRepositorio, TransferenciaRepositorio>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

#endregion
var app = builder.Build();

#region Construccion de la aplicacion y area de middlewares

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 10 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BilleteraVirtual.Server.Client._Imports).Assembly);

app.MapControllers();

#endregion
app.Run();
