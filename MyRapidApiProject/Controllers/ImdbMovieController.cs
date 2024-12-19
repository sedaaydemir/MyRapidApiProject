using Microsoft.AspNetCore.Mvc;
using MyRapidApiProject.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyRapidApiProject.Controllers
{
    public class ImdbMovieController : Controller
    {
        public async Task< IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "67431eb8c3msh123231d4b3e9191p1ffc1fjsn6bbbc174495d" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ImdbMovieViewModel>>(body);
                return View(values.ToList());
            }
            
        }
    }
}
