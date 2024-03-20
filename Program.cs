using Bamboo_Card_HK_API.Services;

var builder = WebApplication.CreateBuilder(args);

// add dependency injection
builder.Services.AddTransient<IHackerNewsService, HackerNewsService>(); 
builder.Services.AddHttpClient<IHackerNewsService, HackerNewsService>();

var app = builder.Build();

app.MapGet("stories", async (IHackerNewsService hackerNewsService, int limit=0) =>
{
	try
	{
		if(limit < 0)
		{
			return Results.BadRequest("Limit must be a positive number");
		}
		if (limit > 15)
		{
			return Results.BadRequest("You can only request up to 15 stories at a time");
		}

		var stories = await hackerNewsService.GetTopStories(limit);
		stories= stories.OrderByDescending(e=>e.Score); //for better reading experience
		return Results.Ok(stories);
	}
	catch (Exception ex)
	{
        // TO DO log exceptions
        return Results.Problem("An error occurred while processing your request.", statusCode: 500);
    }
});

app.Run();
