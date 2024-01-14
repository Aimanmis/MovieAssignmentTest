// Test/MovieControllerTests.cs
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MovieAssignmentTest.Models;
using Newtonsoft.Json;
using Xunit;
using MovieAssignmentTest;
namespace MovieAssignmentTest.Services;

public class MovieControllerTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> _factory;

    public MovieControllerTests(WebApplicationFactory<Startup> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/Movie");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Post_CreatesNewMovie()
    {
        // Arrange
        var client = _factory.CreateClient();

        var newItem = new MovieModel
        {
            // Set properties for a new movie
        };

        var content = new StringContent(JsonConvert.SerializeObject(newItem), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/api/Movie", content);

        // Assert
        response.EnsureSuccessStatusCode();

        // Additional assertions if needed
    }

    // Add more test methods for other controller actions
}
