using GestaoPedidos.Infrastructure.Data.Configuration;
using GestaoPedidos.Web;
using GestaoPedidos.Web.DependencyInjections;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
AppSettings appSettings = new();
configuration.GetSection(nameof(AppSettings)).Bind(appSettings);

builder.Services.AddControllers(options => { });
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddServices();
builder.Services.AddMappers();
builder.Services.AddDatabase(appSettings.DatabaseConnection);
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new()
    {
        Title = "Swagger Gestão de Pedidos WEB API",
        Description = "Aplicação para gestão de pedidos do restaurante"
    });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "GestaoPedidos.xml");
    c.IncludeXmlComments(filePath);
});

WebApplication app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

        options.RoutePrefix = string.Empty;
    });

}

app.Run();
