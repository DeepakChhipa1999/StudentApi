# StudentDb REST API design with ASP.NET Core Using Enitiy Framework

This repository contains an StudentDb API written in C# and ASP.NET Core 3.1.


## Testing it out

1. Clone this repository
2. Build the solution using Visual Studio, or on the [command line](https://www.microsoft.com/net/core) with `dotnet build`.
3. Run the project. The API will start up on http://localhost:20846, or http://localhost:5000 with `dotnet run`.
4. Use an HTTP client like [Postman](https://www.getpostman.com/) or [Fiddler](https://www.telerik.com/download/fiddler) to `GET http://localhost:20846`.

## Cloning the repo using the Docker Hub
1. Install the docker in your laptop.
2. Run the command `docker pull deepakchhipa1999/studentapi` to get the code.
3. Run the command `docker images` to check the docker image.
3. Run the command `docker run -it --rm -p 8080:80 deepakchhipa1999/studentapi` to run the docker image.
4. Use an HTTP client like [Postman](https://www.getpostman.com/) or [Fiddler](https://www.telerik.com/download/fiddler) or Browser to test `http://localhost:8080/api/student` using the Get tag.

### Entity Framework Core in-memory for rapid prototyping

The [in-memory provider](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory) in Entity Framework Core makes it easy to rapidly prototype without having to worry about setting up a database. You can build and test against a fast in-memory store, and then swap it out for a real database when you're ready.

With the [Microsoft.EntityFrameworkCore.InMemory](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory) package installed, create a `DbContext`:

```csharp
public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    // DbSets...
}
```

The only difference between this and a "normal" `DbContext` is the addition of a constructor that takes a `DbContextOptions<>` parameter. This is required by the in-memory provider.


### Basic API controllers and routing

API controllers in ASP.NET Core inherit from the `Controller` class and use attributes to define routes. The common pattern is naming the controller `<RouteName>Controller`, and using the `/[controller]` attribute value, which automatically names the route based on the controller name:

```csharp
// Handles all routes under /comments
[Route("/[controller]")]
public class CommentsController : Controller
{
    // Action methods...
}
```

Methods in the controller handle specific HTTP verbs and sub-routes. Returning `IActionResult` gives you the flexibility to return both HTTP status codes and object payloads:

```csharp
// Handles route:
// GET /comments
[HttpGet]
public async Task<IActionResult> GetCommentsAsync(CancellationToken ct)
{
    return NotFound(); // 404
    
    return Ok(data); // 200 with JSON payload
}


