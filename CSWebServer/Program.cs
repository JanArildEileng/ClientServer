var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => $"Hello World  at {DateTime.Now }!");

app.Run();
