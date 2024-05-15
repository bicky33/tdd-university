using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace UniversityTest;

public class StudentTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    
    public StudentTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GivenIamStudent_WhenIRegister()
    {
        var client = _factory.CreateClient();
        var response = await client.PostAsync("/students", null);
        ItShouldRegisterANewStudent(response);
    }

    private void ItShouldRegisterANewStudent(HttpResponseMessage response)
    {
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}