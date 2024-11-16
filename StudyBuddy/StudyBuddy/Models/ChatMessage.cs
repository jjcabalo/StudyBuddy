using Newtonsoft.Json;

namespace StudyBuddy.Models
{
    public class ChatMessage
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("parts")]
        public List<ChatPart> Parts { get; set; }
    }

    public class ChatPart
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}