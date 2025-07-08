using Pedido.API.Messaging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMessageBus, RabbitMqMessageBus>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pedido API V1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();

public partial class Program { }