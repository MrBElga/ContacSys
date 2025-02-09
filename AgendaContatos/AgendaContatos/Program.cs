using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Cria��o do Startup e configura��o dos servi�os
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configura��o do pipeline de requisi��o com o Startup
startup.Configure(app, app.Environment);

app.Run();
