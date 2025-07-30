using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Data;
using MyApp.Backend.Repositories;
using MyApp.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container
builder.Services.AddControllers();

// Configuração do Entity Framework com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Injeção de dependências
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
