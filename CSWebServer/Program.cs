
using CSShared.Dto;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => $"Hello World  at {DateTime.Now }!");


app.MapGet("/Info", () => new InfoData());



app.Run();



