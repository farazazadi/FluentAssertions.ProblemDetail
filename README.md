[![CI](https://github.com/farazazadi/FluentAssertions.ProblemDetail/actions/workflows/ci.yml/badge.svg)](https://github.com/farazazadi/FluentAssertions.ProblemDetail/actions/workflows/ci.yml) [![Release](https://github.com/farazazadi/FluentAssertions.ProblemDetail/actions/workflows/release.yml/badge.svg)](https://github.com/farazazadi/FluentAssertions.ProblemDetail/actions/workflows/release.yml) [![](https://img.shields.io/nuget/dt/FluentAssertions.ProblemDetail.svg?label=nuget%20downloads)](https://www.nuget.org/packages/FluentAssertions.ProblemDetail) ![](https://img.shields.io/badge/release%20strategy-githubflow-blue.svg)


## FluentAssertions.ProblemDetail
Fluent Assertions extensions for ProblemDetails within HttpResponseMessage

### Installation
You can install this [NuGet package](https://www.nuget.org/packages/FluentAssertions.ProblemDetail) via .NET CLI:
```
dotnet add package FluentAssertions.ProblemDetail 
```


### Available extension methods
- `HaveProblemDetails()`
- `WithTitle()`
- `WithStatusCode()`
- `WithDetail()`
- `WithDetailThatContains()`
- `WithInstance()`
- `WithExtensionsThatContain()`
- `WithType()`


### Usage
```csharp
using FluentAssertions;
using FluentAssertions.ProblemDetail.HttpResponse.Assertions;

... 

// Given
User user = CreateUserWithInvalidEmailAddress();

// When
HttpResponseMessage response = await Client.PostAsJsonAsync("api/users", user);

// Then
response
    .Should()
    .HaveProblemDetails()
    .WithTitle("Bad Request")
    .WithStatusCode(StatusCodes.Status400BadRequest)
    .WithDetail("User's email address is not valid!")
    .WithInstance("/api/users")
    .WithExtensionsThatContain("exceptionCode", "InvalidUserEmail")
    .WithType("https://tools.ietf.org/html/rfc7231#section-6.5.1");
```
