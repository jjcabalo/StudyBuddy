using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using StudyBuddy.Models;
using Microsoft.Extensions.Logging;

namespace StudyBuddy.Services
{
    public class GoogleApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ILogger<GoogleApiService> _logger;

        public GoogleApiService(HttpClient httpClient, string apiKey, ILogger<GoogleApiService> logger)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _logger = logger;
        }

        public async Task<string> GenerateContentAsync(List<ChatMessage> conversationHistory, ChatMessage systemInstruction = null)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={_apiKey}";

            var requestBody = new
            {
                contents = conversationHistory,
                systemInstruction = systemInstruction,
                generationConfig = new
                {
                    temperature = 0.5,
                    topK = 40,
                    topP = 0.95,
                    maxOutputTokens = 3000,
                    responseMimeType = "text/plain"
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            _logger.LogInformation("Sending request to Google API: {RequestBody}", JsonConvert.SerializeObject(requestBody, Formatting.Indented));

            var response = await _httpClient.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("Received response from Google API: {Response}", responseString);

            response.EnsureSuccessStatusCode();

            // Parse the JSON response and extract the text content
            var jsonResponse = JObject.Parse(responseString);
            var textContent = jsonResponse["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

            return textContent ?? "No response from the bot.";
        }
    }
}