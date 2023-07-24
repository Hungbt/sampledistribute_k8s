using core.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger(c =>
{
    c.RouteTemplate = "api/operation/swagger/{documentName}/swagger.json";
});
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "Operation API V1");
    c.RoutePrefix = "api/operation";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
