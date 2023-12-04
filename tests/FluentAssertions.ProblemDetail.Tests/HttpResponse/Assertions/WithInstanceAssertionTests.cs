using FluentAssertions.ProblemDetail.Common;
using FluentAssertions.ProblemDetail.HttpResponse.Assertions;
using FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;
using Xunit.Sdk;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Assertions;

public class WithInstanceAssertionTests
{
    [Fact]
    public void Should_Succeed_WhenInstanceIsAsExpected()
    {
        // Given
        ProblemDetails problemDetails = FakeProblemDetails.BadRequestProblemDetails;

        // When
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // Then
        responseMessage
            .Should()
            .HaveProblemDetails()
            .WithInstance(problemDetails.Instance);
    }



    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenAssertingThatProblemDetailsInstanceIsAsExpectedButItIsNot()
    {
        // Given
        var problemDetails = new ProblemDetails { Instance = "https://tools.ietf.org/html/rfc7231#section-6.5.1" };
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithInstance("https://tools.ietf.org/html/rfc7231#section-6.5.3", "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage to have a ProblemDetails whose "Instance" is "https://tools.ietf.org/html/rfc7231#section-6.5.3" because we want to test the failure message, but found "https://tools.ietf.org/html/rfc7231#section-6.5.1".""");
    }
}