using FluentAssertions.ProblemDetail.Common;
using FluentAssertions.ProblemDetail.HttpResponse.Assertions;
using FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;
using Xunit.Sdk;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Assertions;

public class WithExtensionsAssertionTests
{
    [Fact]
    public void Should_Succeed_WhenExtensionsContainKeyAndValueAsExpected()
    {
        // Given
        var problemDetails = new ProblemDetails
        {
            Extensions = new Dictionary<string, object?>
            {
                {"ExceptionCode", "InvalidEmail"}
            }
        };


        // When
        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);


        // Then
        responseMessage
            .Should()
            .HaveProblemDetails()
            .WithExtensionsThatContain("ExceptionCode", "InvalidEmail");
    }



    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenKeyDoesNotExist()
    {
        // Given
        var problemDetails = new ProblemDetails
        {
            Extensions = new Dictionary<string, object?>
            {
                {"ExceptionCode", "InvalidEmail"}
            }
        };

        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);


        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithExtensionsThatContain("ExCode", "InvalidEmail", "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage.ProblemDetails.Extensions {["ExceptionCode"] = InvalidEmail} to contain key "ExCode" because we want to test the failure message.""");
    }



    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenKeyExistButValueIsNull()
    {
        // Given
        var problemDetails = new ProblemDetails
        {
            Extensions = new Dictionary<string, object?>
            {
                {"ExceptionCode", null}
            }
        };

        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);


        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithExtensionsThatContain("ExceptionCode", "InvalidEmail", "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage.ProblemDetails.Extensions {["ExceptionCode"] = <null>} to contain value "InvalidEmail" at key "ExceptionCode" because we want to test the failure message, but value was <null>.""");
    }



    [Fact]
    public void Should_FailWithDescriptiveMessage_WhenKeyExistButValueIsNotAsExpected()
    {
        // Given
        var problemDetails = new ProblemDetails
        {
            Extensions = new Dictionary<string, object?>
            {
                {"ExceptionCode", "InvalidEmail"}
            }
        };

        HttpResponseMessage responseMessage = FakeHttpResponseMessage.NewFakeThatHaveProblemDetails(problemDetails);


        // When
        Action action = () => responseMessage
            .Should()
            .HaveProblemDetails()
            .WithExtensionsThatContain("ExceptionCode", "InvalidPassport", "because we want to test the failure {0}", "message");

        // Then
        action
            .Should()
            .Throw<XunitException>()
            .WithMessage("""Expected responseMessage.ProblemDetails.Extensions {["ExceptionCode"] = InvalidEmail} to contain value "InvalidPassport" at key "ExceptionCode" because we want to test the failure message, but found InvalidEmail.""");
    }

}