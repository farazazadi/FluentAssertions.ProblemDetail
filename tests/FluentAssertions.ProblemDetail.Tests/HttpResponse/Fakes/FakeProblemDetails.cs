using FluentAssertions.ProblemDetail.Common;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;

public static class FakeProblemDetails
{
    public static ProblemDetails BadRequestProblemDetails => new()
    {
        Title = "Bad Request",
        Status = 400,
        Detail = "User's email address is not valid!",
        Instance = "/api/users",
        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
    };

}