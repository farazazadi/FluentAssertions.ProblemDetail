using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions.ProblemDetail.Common;
using FluentAssertions.ProblemDetail.HttpResponse;
using FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse;

public class HttpResponseMessageExtensionsTests
{
    //private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);

    [Fact]
    public void GetProblemDetails_ShouldReturnNull_WhenHttpResponseMessageIsNull()
    {
        // Given
        HttpResponseMessage httpResponseMessage = null!;

        // When
        var problemDetails = httpResponseMessage.GetProblemDetails();

        // Then
        problemDetails.Should().BeNull();
    }


    [Fact]
    public void GetProblemDetails_ShouldReturnNull_WhenHttpResponseMessageContentTypeIsNotApplicationProblemJson()
    {
        // Given
        var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("This is not a problem details response.")
        };

        // When
        var problemDetails = httpResponseMessage.GetProblemDetails();

        // Then
        problemDetails.Should().BeNull();
    }



    [Fact]
    public void GetProblemDetails_ShouldReturnProblemDetailsAsExpected_WhenHttpResponseMessageContentContainsProblemDetails()
    {
        // Given
        ProblemDetails expectedProblemDetails = FakeProblemDetails.BadRequestProblemDetails;

        HttpResponseMessage httpResponseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(expectedProblemDetails);

        // When
        ProblemDetails? problemDetails = httpResponseMessage.GetProblemDetails();

        // Then
        problemDetails.Should().BeEquivalentTo(expectedProblemDetails);
    }
}