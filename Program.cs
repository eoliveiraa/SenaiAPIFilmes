
using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filme_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//adicionar o rep�sitorio e a interface ao container de inje��o de dep�ndencia
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

//adicionar o servi�o de Controllers
builder.Services.AddControllers();

var app = builder.Build();

//adicionar o mapeamento dos controllers
app.MapControllers();

app.Run();
