using Bamboo_Card_HK_API.Models;
using Newtonsoft.Json;


namespace Bamboo_Card_HK_API.Services
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<HackerNewsStory>> GetTopStories(int storyCount);
    }

    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;

        public HackerNewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<IEnumerable<HackerNewsStory>> GetTopStories(int limit)
        {
            var response = await _httpClient.GetAsync("https://hacker-news.firebaseio.com/v0/topstories.json");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var storyIds = JsonConvert.DeserializeObject<IEnumerable<int>>(stringResponse);

            var stories = new List<HackerNewsStory>();
            foreach (var storyId in storyIds.Take(limit))
            {
                var storyResponse = await _httpClient.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
                var storyStringResponse = await storyResponse.Content.ReadAsStringAsync();
                var story = JsonConvert.DeserializeObject<HackerNewsStory>(storyStringResponse);

                stories.Add(story);
            }

            return stories;
        }
    }
}
