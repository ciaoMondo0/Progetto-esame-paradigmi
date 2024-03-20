using Progetto_paradigmi.Progetto.Application.Extensions;
using Progetto_paradigmi.Progetto.Application.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWebServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware().AddApplicationMiddleware();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
