using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.EntityFrameworkCore;
using static AlmoxarifadoInfrastructure.Data.Repositories.ConexaoBancoRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConexaoBanco, PrimeiraConexao>(sp =>
    new PrimeiraConexao(builder.Configuration));
builder.Services.AddSingleton<IConexaoBanco, ReplicaConexao>(sp =>
    new ReplicaConexao(builder.Configuration));
builder.Services.AddSingleton<DbContextAlmoxarifado>();

builder.Services.AddDbContext<xAlmoxarifadoContext>((serviceProvider, options) =>
{
    var dbContextStrategy = serviceProvider.GetRequiredService<DbContextAlmoxarifado>();
    var connectionString = dbContextStrategy.GetConnectionString();
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<xAlmoxarifadoContext>();

builder.Services.AddScoped<IItensNotaRepository, ItensNotaRepository>();
builder.Services.AddScoped<ItensNotaService>();
builder.Services.AddScoped<IItensRequisicaoRepository, ItensRequisicaoRepository>();
builder.Services.AddScoped<ItensRequisicaoService>();
builder.Services.AddScoped<INotaFiscalRepository, NotasFiscaisRepository>();
builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<IRequisicoesRepository, RequisicoesRepository>();
builder.Services.AddScoped<RequisicaoService>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<EstoqueService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
