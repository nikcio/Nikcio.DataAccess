using Nikcio.DataAccess.TestBase.Contexts.Extensions;

var builder = WebApplication.CreateBuilder(args);

var contextOptions = new ContextOptions("Default", builder.Configuration);
builder.Services.AddContexts(contextOptions);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
