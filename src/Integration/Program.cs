Console.WriteLine($"Integration started, version {typeof(Program).Assembly.GetName().Version}");
while (true)
{
    Console.WriteLine($"{DateTime.UtcNow:O} heartbeat");
    await Task.Delay(TimeSpan.FromSeconds(10));
}
