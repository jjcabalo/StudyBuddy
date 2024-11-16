using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudyBuddy.Services;
using StudyBuddy.Models;
using StudyBuddy.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StudyBuddy.Controllers
{
    public class ChatController : Controller
    {
        private readonly GoogleApiService _googleApiService;
        private readonly ILogger<ChatController> _logger;

        public ChatController(GoogleApiService googleApiService, ILogger<ChatController> logger)
        {
            _googleApiService = googleApiService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult ChatSystem()
        {
            var chatHistory = HttpContext.Session.GetObjectFromJson<List<ChatMessage>>("ChatHistory") ?? new List<ChatMessage>();
            return View(chatHistory);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return BadRequest("Message cannot be empty.");
            }

            try
            {
                var chatHistory = HttpContext.Session.GetObjectFromJson<List<ChatMessage>>("ChatHistory") ?? new List<ChatMessage>();
                chatHistory.Add(new ChatMessage { Role = "user", Parts = new List<ChatPart> { new ChatPart { Text = message } } });

                // Add your system instruction here
                var systemInstruction = new ChatMessage
                {
                    Role = "user",
                    Parts = new List<ChatPart>
                    {
                        new ChatPart
                        {
                            Text = "You are a Keepy the ai chat assistant of StudyBuddy and you aim to help students with their questions regarding their studies. If the questions they asked are about academics provide them the APA Citation Link of the source, if not needed don't. Please provide concise and accurate responses."
                        }
                    }
                };

                var responseText = await _googleApiService.GenerateContentAsync(chatHistory, systemInstruction);

                chatHistory.Add(new ChatMessage { Role = "model", Parts = new List<ChatPart> { new ChatPart { Text = responseText } } });

                HttpContext.Session.SetObjectAsJson("ChatHistory", chatHistory);

                return Json(new { response = responseText });
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, "HTTP request error occurred while sending message.");
                return StatusCode(500, "HTTP request error");
            }
            catch (JsonReaderException jsonEx)
            {
                _logger.LogError(jsonEx, "JSON parsing error occurred while sending message.");
                return StatusCode(500, "JSON parsing error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while sending message.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}