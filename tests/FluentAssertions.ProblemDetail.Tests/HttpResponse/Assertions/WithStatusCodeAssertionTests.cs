using FluentAssertions.ProblemDetail.Common;
using FluentAssertions.ProblemDetail.HttpResponse.Assertions;
using FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;
using Xunit.Sdk;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Assertions;

public class WithStatusCodeAssertionTests
{
    [Fact]
    public void Should_Succeed_WhenStatusCodeIsAsExpected()
    {
        // Given
        ProblemDetails problemDetails = FakeProblemDetails.BadRequestProblemDetails;

        // When
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // Then
        responseMessage
            .Should()
            .HaveProblemDetails()
            .WithStatusCode(problemDetails.Status);
    }



    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenAssertingThatProblemDetailsStatusCodeIsAsExpectedButItIsNot()
    {
        // Given
        var problemDetails = new ProblemDetails { Status = 400};
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithStatusCode(500, "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage to have a ProblemDetails whose "StatusCode" is 500 because we want to test the failure message, but found 400.""");
    }
}