using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using FluentAssertions.ProblemDetail.Common;

namespace FluentAssertions.ProblemDetail.HttpResponse;

public static class HttpResponseMessageExtensions
{

    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);


    /// <summary>
    /// Reads the content of <paramref name="httpResponseMessage"/> into a <see cref="HttpResponseMessage"/>.
    /// </summary>
    /// <param name="httpResponseMessage">HTTP response message to parse its content.</param>
    /// <returns>A <see cref="ProblemDetails"/> if the content of the <paramref name="httpResponseMessage"/> be a <see cref="ProblemDetails"/>; otherwise, null.</returns>
    public static ProblemDetails? GetProblemDetails(this HttpResponseMessage? httpResponseMessage)
    {
        string? mediaType = httpResponseMessage?.Content.Headers.ContentType?.MediaType;

        if (mediaType is null ||
            !mediaType.Equals("application/problem+json", StringComparison.InvariantCultureIgnoreCase))
            return null;

        var stream = ReadAsStreamAndResetItsCurrentPosition(httpResponseMessage!.Content);

        var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(stream, JsonSerializerOptions);

        return problemDetails;
    }


    private static Stream ReadAsStreamAndResetItsCurrentPosition(HttpContent content)
    {
        var stream = content.ReadAsStream();
        stream.Position = 0;
        return stream;
    }

}