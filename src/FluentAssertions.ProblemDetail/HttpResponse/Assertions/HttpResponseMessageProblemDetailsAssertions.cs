using System.Collections.Generic;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System.Net.Http;
using FluentAssertions.ProblemDetail.Common;
using System.Text.Json;

namespace FluentAssertions.ProblemDetail.HttpResponse.Assertions;

/// <summary>
/// Contains a number of methods to assert that an <see cref="HttpResponseMessage"/> have a <see cref="Common.ProblemDetails"/> as expected.
/// </summary>
public class HttpResponseMessageProblemDetailsAssertions : HttpResponseMessageAssertions
{
    public HttpResponseMessageProblemDetailsAssertions(HttpResponseMessage value) : base(value)
    {
        ProblemDetails = value.GetProblemDetails();
    }

    public HttpResponseMessageProblemDetailsAssertions(HttpResponseMessage value, ProblemDetails problemDetails) : base(value)
    {
        ProblemDetails = problemDetails;
    }


    /// <summary>
    /// Returns the type of the subject the assertion applies on.
    /// </summary>
    protected override string Identifier => "HttpResponseMessageProblemDetails";

    protected internal ProblemDetails? ProblemDetails { get; }


    /// <summary>
    /// Asserts that the HTTP response have a <see cref="Common.ProblemDetails"/>.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public AndConstraint<HttpResponseMessageProblemDetailsAssertions> HaveProblemDetails(
        string because = "", params object[] becauseArgs)
    {

        var success = Execute.Assertion
            .ForCondition(Subject is not null)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context} to have ProblemDetails{reason}, but HttpResponseMessage was <null>.");


        if (success)
        {
            Execute.Assertion
                .ForCondition(ProblemDetails is not null)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context} to have ProblemDetails{reason}, but was not found.");
        }


        return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
    }


    /// <summary>
    /// Asserts that <see cref="ProblemDetails.Type"/> is equal to <paramref name="expectedType"/>.
    /// </summary>
    /// <param name="expectedType"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithType(string? expectedType,
        string because = "", params object[] becauseArgs)
    {

        Execute.Assertion
            .ForCondition(ProblemDetails!.Type == expectedType)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context} to have a ProblemDetails whose {0} is {1}{reason}, but found {2}.",
                "Type", expectedType, ProblemDetails!.Type);


        return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
    }



    /// <summary>
    /// Asserts that <see cref="Common.ProblemDetails.Title"/> is equal to <paramref name="expectedTitle"/>.
    /// </summary>
    /// <param name="expectedTitle"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithTitle(string? expectedTitle,
        string because = "", params object[] becauseArgs)
    {

        Execute.Assertion
            .ForCondition(ProblemDetails!.Title == expectedTitle)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context} to have a ProblemDetails whose {0} is {1}{reason}, but found {2}.",
                "Title", expectedTitle, ProblemDetails!.Title);

        return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
    }



    /// <summary>
    /// Asserts that <see cref="Common.ProblemDetails.Status"/> is equal to <paramref name="expectedStatusCode"/>.
    /// </summary>
    /// <param name="expectedStatusCode"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithStatus(int? expectedStatusCode,
        string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(ProblemDetails!.Status == expectedStatusCode)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context} to have a ProblemDetails whose {0} is {1}{reason}, but found {2}.",
                "StatusCode", expectedStatusCode, ProblemDetails!.Status);

        return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
    }





    /// <summary>
    /// Asserts that <see cref="Common.ProblemDetails.Detail"/> is equal to <paramref name="expectedDetail"/>.
    /// </summary>
    /// <param name="expectedDetail"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithDetail(string? expectedDetail,
        string because = "", params object[] becauseArgs)
    {

        Execute.Assertion
            .ForCondition(ProblemDetails!.Detail == expectedDetail)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context} to have a ProblemDetails whose {0} is {1}{reason}, but found {2}.",
                "Detail", expectedDetail, ProblemDetails!.Detail);

        return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
    }




    /// <summary>
    /// Asserts that <see cref="Common.ProblemDetails.Detail"/> contains <paramref name="expected"/> string.
    /// </summary>
    /// <param name="expected"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithDetailThatContains(string expected,
        string because = "", params object[] becauseArgs)
    {
        var success = ProblemDetails!.Detail is not null &&
                      ProblemDetails!.Detail.Contains(expected);

        Execute.Assertion
            .ForCondition(success)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context} to have a ProblemDetails whose {0} contains {1}{reason}.",
                "Detail", expected);

        return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
    }



    /// <summary>
    /// Asserts that <see cref="ProblemDetails.Extensions"/> contains the specified <paramref name="value" /> for the supplied
    /// <paramref name="key" />.
    /// </summary>
    /// <param name="key">The key for which to validate the value</param>
    /// <param name="value">The value to validate</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    [CustomAssertion]
    public AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithExtensionsThatContain<TValue>(
        string key, TValue value,
        string because = "", params object[] becauseArgs)
    {

        IDictionary<string, object?> extensions = ProblemDetails!.Extensions;

        var context = $"{Execute.Assertion.CallerIdentity}.ProblemDetails.Extensions";
        using var scope = new AssertionScope(context);


        var expectedKeyExist = extensions.ContainsKey(key);

        Execute.Assertion
            .ForCondition(expectedKeyExist)
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context:dictionary} {0} to contain key {1}{reason}.", extensions, key);


        object? actualValue = extensions[key];


        if (actualValue is null)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:dictionary} {0} to contain value {1} at key {2}{reason}, but value was <null>.",
                    extensions, value, key, actualValue);

            return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
        }


        var valueMismatchMessage = "Expected {context:dictionary} {0} to contain value {1} at key {2}{reason}, but found {3}.";

        if (actualValue is JsonElement jsonElement)
        {
            try
            {
                var jsonElementValue = jsonElement.Deserialize<TValue>();

                Execute.Assertion
                    .ForCondition(jsonElementValue is not null && jsonElementValue.Equals(value))
                    .BecauseOf(because, becauseArgs)
                    .FailWith(valueMismatchMessage, extensions, value, key, jsonElement);
            }
            catch (JsonException)
            {
                scope.Discard();

                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .FailWith(valueMismatchMessage, extensions, value, key, jsonElement);
            }

            return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
        }


        Execute.Assertion
            .ForCondition(((TValue)actualValue).Equals(value))
            .BecauseOf(because, becauseArgs)
            .FailWith(valueMismatchMessage, extensions, value, key, actualValue);


        return new AndConstraint<HttpResponseMessageProblemDetailsAssertions>(this);
    }

}