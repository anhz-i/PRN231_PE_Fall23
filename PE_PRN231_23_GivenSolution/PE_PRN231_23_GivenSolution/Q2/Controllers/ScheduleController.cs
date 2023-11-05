using Q2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Q2.Controllers
{
    public class ScheduleController : Controller
    {

        private readonly HttpClient client = null;
        private string BaseUrl = "";

        public ScheduleController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BaseUrl = "https://localhost:5100/api/Schedule";
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListAsync()
        {
            DateTime current = new DateTime();
            HttpResponseMessage respone = await client.GetAsync("https://localhost:5100/api/Schedule/List/" + current);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var list = JsonSerializer.Deserialize<List<Schedule>>(strData, options) ?? new List<Schedule>();
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ListAsync(DateTime date)
        {            
            HttpResponseMessage respone = await client.GetAsync("https://localhost:5100/api/Schedule/List/" + date);
            string strData = await respone.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var list = JsonSerializer.Deserialize<List<Schedule>>(strData, options) ?? new List<Schedule>();
            return View(list);
        }
    }
}
