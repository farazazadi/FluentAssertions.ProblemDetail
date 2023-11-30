using System.Diagnostics;
using FluentAssertions.Primitives;
using FluentAssertions.ProblemDetail.Common;

namespace FluentAssertions.ProblemDetail.HttpResponse.Assertions;

/// <summary>
/// Contains extension methods for custom assertions in unit tests related to <see cref="HttpResponseMessageProblemDetailsAssertions"/>.
/// </summary>
[DebuggerNonUserCode]
public static class HttpResponseMessageProblemDetailsAssertionsExtensions
{
    /// <summary>
    /// Asserts that the HTTP response have a <see cref="ProblemDetails"/>.
    /// </summary>
    /// <param name="parentAssertions"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <paramref name="because" />.
    /// </param>
    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageProblemDetailsAssertions> HaveProblemDetails(
        this HttpResponseMessageAssertions parentAssertions,
        string because = "", params object[] becauseArgs)
        => new HttpResponseMessageProblemDetailsAssertions(parentAssertions.Subject)
            .HaveProblemDetails(because, becauseArgs);



    /// <summary>
    /// Asserts that <see cref="ProblemDetails.Type"/> is equal to <paramref name="expectedType"/>.
    /// </summary>
    /// <param name="assertion"></param>
    /// <param name="expectedType"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithType(
        this AndConstraint<HttpResponseMessageProblemDetailsAssertions> assertion,
        string? expectedType,
        string because = "", params object[] becauseArgs)
        => new HttpResponseMessageProblemDetailsAssertions(assertion.And.Subject, assertion.And.ProblemDetails!)
            .WithType(expectedType, because, becauseArgs);


    /// <summary>
    /// Asserts that <see cref="ProblemDetails.Title"/> is equal to <paramref name="expectedTitle"/>.
    /// </summary>
    /// <param name="assertion"></param>
    /// <param name="expectedTitle"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithTitle(
        this AndConstraint<HttpResponseMessageProblemDetailsAssertions> assertion,
        string? expectedTitle,
        string because = "", params object[] becauseArgs)
        => new HttpResponseMessageProblemDetailsAssertions(assertion.And.Subject, assertion.And.ProblemDetails!)
            .WithTitle(expectedTitle, because, becauseArgs);



    /// <summary>
    /// Asserts that <see cref="ProblemDetails.Status"/> is equal to <paramref name="expectedStatusCode"/>.
    /// </summary>
    /// <param name="assertion"></param>
    /// <param name="expectedStatusCode"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithStatusCode(
        this AndConstraint<HttpResponseMessageProblemDetailsAssertions> assertion,
        int? expectedStatusCode,
        string because = "", params object[] becauseArgs)
        => new HttpResponseMessageProblemDetailsAssertions(assertion.And.Subject, assertion.And.ProblemDetails!)
            .WithStatus(expectedStatusCode, because, becauseArgs);



    /// <summary>
    /// Asserts that <see cref="ProblemDetails.Detail"/> is equal to <paramref name="expectedDetail"/>.
    /// </summary>
    /// <param name="assertion"></param>
    /// <param name="expectedDetail"></param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see paramref="because" />.
    /// </param>
    [CustomAssertion]
    public static AndConstraint<HttpResponseMessageProblemDetailsAssertions> WithDetail(
        this AndConstraint<HttpResponseMessageProblemDetailsAssertions> assertion,
        string? expectedDetail,
        string because = "", params object[] becauseArgs)
        => new HttpResponseMessageProblemDetailsAssertions(assertion.And.Subject, assertion.And.ProblemDetails!)
            .WithDetail(expectedDetail, because, becauseArgs);

}