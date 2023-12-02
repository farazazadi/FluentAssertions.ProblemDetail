using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FluentAssertions.ProblemDetail.Common;

namespace FluentAssertions.ProblemDetail.Tests.HttpResponse.Fakes;

public static class FakeHttpResponseMessage
{
    public static HttpResponseMessage NewFakeThatHaveProblemDetails()
    {
        return NewFakeThatHaveProblemDetails(FakeProblemDetails.BadRequestProblemDetails);
    }

    public static HttpResponseMessage NewFakeThatHaveProblemDetails(ProblemDetails problemDetails)
    {
        string problemDetailsJsonString = JsonSerializer.Serialize(problemDetails);

        var stream = new MemoryStream(Encoding.UTF8.GetBytes(problemDetailsJsonString));

        var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            Content = new StreamContent(stream)
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/problem+json")
                }
            }
        };


        return response;
    }


    public static HttpResponseMessage NewFakeThatDoesNotHaveProblemDetails()
    {
        return new HttpResponseMessage(HttpStatusCode.BadRequest);
    }
}