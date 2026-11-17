var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (IConfiguration config) =>
    $"Demo app, environment: {config["ENVIRONMENT_NAME"] ?? "local"}");

app.MapGet("/health", () => Results.Text("Healthy"));

app.Run();

public partial class Program { }
