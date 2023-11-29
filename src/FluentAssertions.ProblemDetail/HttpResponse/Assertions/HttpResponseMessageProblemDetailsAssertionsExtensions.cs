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

}