using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TFLUZ.Application.Interfaces;
using TFLUZ.Application.Profiles;
using TFLUZ.Application.Services;
using TFLUZ.Components;
using TFLUZ.Core.Interfaces;
using TFLUZ.Core.UseCases;
using TFLUZ.Infrastructure;
using TFLUZ.Infrastructure.Interfaces;
using TFLUZ.Infrastructure.Models;
using TFLUZ.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddScoped<IBuscarTodasMovimentacoes, BuscarTodasMovimentacoes>();
//builder.Services.AddScoped<IRealizarMovimentacaoUseCase, RealizarMovimentacaoUseCase>();
builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
builder.Services.AddScoped<IDescricaoMovimentacaoRepository, DescricaoMovimentacaoRepository>();
builder.Services.AddScoped<IStatusMovimentacaoRepository, StatusMovimentacaoRepository>();
builder.Services.AddScoped<IMovimentacaoService, MovimentacaoService>();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Db"));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MovimentacaoProfile>();
});

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value?.ToLower();

    if (path == "/")
    {
        context.Response.Redirect("/dashboard");
        return;
    }

    await next();
});

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

SeedDatabase(app);

app.Run();

void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Já existe?
    if (db.Movimentacoes.Any())
        return;

    // --- Popular Status ---
    var statusPendente = new StatusMovimentacaoEntity { Id = 1, Nome = "Pendente" };
    var statusConcluido = new StatusMovimentacaoEntity { Id = 2, Nome = "Concluído" };

    db.StatusMovimentacoes.AddRange(statusPendente, statusConcluido);

    // --- Popular Descrições ---
    var descSalario = new DescricaoMovimentacaoEntity { Id = 1, Nome = "Salário" };
    var descMercado = new DescricaoMovimentacaoEntity { Id = 2, Nome = "Mercado" };

    db.DescricoesMovimentacao.AddRange(descSalario, descMercado);

    // --- Popular Movimentações ---
    var mov1 = new MovimentacaoEntity
    {
        Id = 1,
        Data = DateTime.Now.AddDays(-3),
        Valor = 3500.00m,
        Observacao = "Pagamento mensal",
        Classificacao = 1, // Receita
        StatusId = statusConcluido.Id,
        DescricaoId = descSalario.Id
    };

    var mov2 = new MovimentacaoEntity
    {
        Id = 2,
        Data = DateTime.Now.AddDays(-1),
        Valor = -250.00m,
        Observacao = "Compras no mercado",
        Classificacao = 2, // Despesa
        StatusId = statusPendente.Id,
        DescricaoId = descMercado.Id
    };

    db.Movimentacoes.AddRange(mov1, mov2);

    db.SaveChanges();
}
