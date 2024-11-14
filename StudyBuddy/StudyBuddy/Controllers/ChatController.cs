using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StudyBuddy.Services;

namespace YourNamespace.Controllers
{
    public class ChatController : Controller
    {
        private readonly GeminiClient _geminiClient;

        public ChatController(GeminiClient geminiClient)
        {
            _geminiClient = geminiClient;
        }

        [HttpGet]
        public IActionResult ChatSystem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest("Message cannot be empty.");
            }

            string systemInstructions = "You are Keepy, the A.I. bot of Study Buddy and you aim to help students to assist with their studies.";
            string prompt = $"{systemInstructions}\nUser: {message}\nAssistant:";

            string responseText = await _geminiClient.GenerateContentAsync(prompt, HttpContext.RequestAborted);

            return Json(responseText); // Return the assistant's response as JSON
        }
    }
}