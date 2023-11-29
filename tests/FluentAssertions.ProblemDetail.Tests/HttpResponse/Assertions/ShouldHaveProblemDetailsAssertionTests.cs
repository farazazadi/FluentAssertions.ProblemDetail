using FluentAssertions.ProblemDetail.HttpResponse.Assertions;
using FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;
using Xunit.Sdk;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Assertions;

public class ShouldHaveProblemDetailsAssertionTests
{
    [Fact]
    public void Should_Succeed_WhenHttpResponseMessageContainsProblemDetails()
    {
        // Given
        // When
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails();


        // Then
        responseMessage
            .Should()
            .HaveProblemDetails();
    }


    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenHttpResponseMessageDoesNotHaveProblemDetails()
    {
        // Given
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatDoesNotHaveProblemDetails();


        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails("because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage(
                "Expected responseMessage to have ProblemDetails because we want to test the failure message, but was not found.");

    }


    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenAssertingThatResponseHaveProblemDetailsButResponseIsNull()
    {
        // Given
        HttpResponseMessage responseMessage = null!;

        // When
        Action action = () => responseMessage
                .Should()
                .HaveProblemDetails("because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage(
                "Expected responseMessage to have ProblemDetails because we want to test the failure message, but HttpResponseMessage was <null>.");
    }
}