using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<xAlmoxarifadoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDBSQL")));

builder.Services.AddScoped<xAlmoxarifadoContext>();

builder.Services.AddScoped<IItensNotaRepository, ItensNotaRepository>();
builder.Services.AddScoped<ItensNotaService>();
builder.Services.AddScoped<IItensRequisicaoRepository, ItensRequisicaoRepository>();
builder.Services.AddScoped<ItensRequisicaoService>();
builder.Services.AddScoped<INotaFiscalRepository, NotasFiscaisRepository>();
builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<IRequisicoesRepository, RequisicoesRepository>();
builder.Services.AddScoped<RequisicaoService>();

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
