using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class HealthTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public HealthTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Health_ReturnsOk()
    {
        var response = await _client.GetAsync("/health");
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Health_ReturnsHealthyText()
    {
        var body = await _client.GetStringAsync("/health");
        Assert.Equal("Healthy", body);
    }

    [Fact]
    public async Task Root_ReportsLocalEnvironment()
    {
        var body = await _client.GetStringAsync("/");
        Assert.Contains("environment: local", body);
    }
}
