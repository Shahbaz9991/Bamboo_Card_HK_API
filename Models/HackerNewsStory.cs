using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bamboo_Card_HK_API.Models
{
    public class HackerNewsStory
    {
        public string Title { get; set; }
        public string Url { get; set; }
        [JsonProperty("by")]
        public string PostedBy{ get; set; }
        public int Score { get; set; }
        [JsonProperty("descendants")]
        public int CommentCount { get; set; }
        //epoch time deserializer to datetime
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Time { get; set; }

    }
}
