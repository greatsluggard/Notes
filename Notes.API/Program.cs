using Notes.API;
using Notes.Application.DependencyInjection;
using Notes.DAL.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwagger();

builder.Services.AddDataAccessLayer(builder.Configuration);

builder.Services.AddApplication();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes.API version 1.0");
});

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();