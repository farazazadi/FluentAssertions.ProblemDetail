using FluentAssertions.ProblemDetail.Common;
using FluentAssertions.ProblemDetail.HttpResponse.Assertions;
using FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;
using Xunit.Sdk;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Assertions;

public class WithTitleAssertionTests
{
    [Fact]
    public void Should_Succeed_WhenTitleIsAsExpected()
    {
        // Given
        ProblemDetails problemDetails = FakeProblemDetails.BadRequestProblemDetails;

        // When
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // Then
        responseMessage
            .Should()
            .HaveProblemDetails()
            .WithTitle(problemDetails.Title);
    }



    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenAssertingThatProblemDetailsTitleIsAsExpectedButItIsNot()
    {
        // Given
        var problemDetails = new ProblemDetails { Title = "TitleA" };
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithTitle("TitleB", "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage to have a ProblemDetails whose "Title" is "TitleB" because we want to test the failure message, but found "TitleA".""");
    }
}