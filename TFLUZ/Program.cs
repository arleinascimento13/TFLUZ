using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TFLUZ.Application.Interfaces;
using TFLUZ.Application.Profiles;
using TFLUZ.Application.Services;
using TFLUZ.Components;
using TFLUZ.Core.Interfaces;
using TFLUZ.Infrastructure;
using TFLUZ.Infrastructure.Interfaces;
using TFLUZ.Infrastructure.Models;
using TFLUZ.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
builder.Services.AddScoped<IMovimentacaoService, MovimentacaoService>();

builder.Services.AddScoped<IDescricaoMovimentacaoRepository, DescricaoMovimentacaoRepository>();
builder.Services.AddScoped<IDescricaoMovimentacaoService, DescricaoMovimentacaoService>();

builder.Services.AddScoped<IStatusMovimentacaoRepository, StatusMovimentacaoRepository>();


SQLitePCL.Batteries.Init();
//var connection = new SqliteConnection("DataSource=_temp.db");
//connection.Open();

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlite(connection));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Db"));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MovimentacaoProfile>();
});

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

//using (var scoped = app.Services.CreateScope())
//{
//    var context = scoped.ServiceProvider.GetRequiredService<AppDbContext>();
//    context.Database.EnsureCreated();
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
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

    var descricao = new DescricaoMovimentacaoEntity { Id = 1, Nome = "Reforma" };

    var classificacao = new ClassificacaoMovimentacaoEntity { Id = 1, Nome = "Receita" };

    db.DescricoesMovimentacao.Add(descricao);

    db.ClassificacaoMovimentacao.Add(classificacao);

    db.StatusMovimentacoes.AddRange(statusPendente, statusConcluido);

    // --- Popular Movimentações ---
    var mov1 = new MovimentacaoEntity
    {
        Id = 1,
        Data = DateTime.Now.AddDays(-3),
        Valor = 3500.00m,
        Observacao = "Pagamento mensal",
        ClassificacaoId = classificacao.Id,
        DescricaoId = descricao.Id,
        StatusId = statusConcluido.Id,
        Ativo = true,
    };

    db.Movimentacoes.Add(mov1);

    db.SaveChanges();
}
