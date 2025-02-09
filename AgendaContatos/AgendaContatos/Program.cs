using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Criação do Startup e configuração dos serviços
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configuração do pipeline de requisição com o Startup
startup.Configure(app, app.Environment);

app.Run();
