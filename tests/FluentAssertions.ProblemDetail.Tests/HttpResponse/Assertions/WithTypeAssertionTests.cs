using FluentAssertions.ProblemDetail.Common;
using FluentAssertions.ProblemDetail.HttpResponse.Assertions;
using FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;
using Xunit.Sdk;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Assertions;

public class WithTypeAssertionTests
{
    [Fact]
    public void Should_Succeed_WhenTypeIsAsExpected()
    {
        // Given
        ProblemDetails problemDetails = FakeProblemDetails.BadRequestProblemDetails;

        // When
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // Then
        responseMessage
            .Should()
            .HaveProblemDetails()
            .WithType(problemDetails.Type);
    }



    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenAssertingThatProblemDetailsTypeIsAsExpectedButItIsNot()
    {
        // Given
        var problemDetails = new ProblemDetails{Type = "TypeA"};
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithType("TypeB", "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage to have a ProblemDetails whose "Type" is "TypeB" because we want to test the failure message, but found "TypeA".""");
    }
}