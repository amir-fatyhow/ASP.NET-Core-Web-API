using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IEventService, EventService>(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Events API v1");
    });
    
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();