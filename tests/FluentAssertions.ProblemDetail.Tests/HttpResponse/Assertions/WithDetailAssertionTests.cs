﻿using FluentAssertions.ProblemDetail.Common;
using FluentAssertions.ProblemDetail.HttpResponse.Assertions;
using FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;
using Xunit.Sdk;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Assertions;

public class WithDetailAssertionTests
{
    [Fact]
    public void Should_Succeed_WhenDetailIsAsExpected()
    {
        // Given
        ProblemDetails problemDetails = FakeProblemDetails.BadRequestProblemDetails;

        // When
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // Then
        responseMessage
            .Should()
            .HaveProblemDetails()
            .WithDetail(problemDetails.Detail);
    }



    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenAssertingThatProblemDetailsDetailIsAsExpectedButItIsNot()
    {
        // Given
        var problemDetails = new ProblemDetails { Detail = "DetailA" };
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithDetail("DetailB", "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage to have a ProblemDetails whose "Detail" is "DetailB" because we want to test the failure message, but found "DetailA".""");
    }



    [Fact]
    public void Should_Succeed_WhenDetailContainsExpectedValue()
    {
        // Given
        var problemDetails = new ProblemDetails { Detail = "Email address is not correct." };

        // When
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // Then
        responseMessage
            .Should()
            .HaveProblemDetails()
            .WithDetailThatContains("address");
    }



    [Theory]
    [InlineData("A descriptive detail.")]
    [InlineData("")]
    [InlineData(null)]
    public void Should_FailWithDescriptiveMessage_WhenAssertingThatProblemDetailsDetailContainsExpectedValueButItDoesNot(string? detail)
    {
        // Given
        var problemDetails = new ProblemDetails { Detail = detail };
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);

        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithDetailThatContains("Email", "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage to have a ProblemDetails whose "Detail" contains "Email" because we want to test the failure message.""");
    }


}