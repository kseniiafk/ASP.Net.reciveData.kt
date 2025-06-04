using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AspNet_reciveData_kt.Controllers
{
    public class EchoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Content("GET request received", "text/plain");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Content("POST request received", "text/plain");
        }

        [HttpGet]
        public IActionResult Headers()
        {
            return Json(Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()));
        }

        [HttpGet]
        public IActionResult Query()
        {
            return Json(Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString()));
        }

        [HttpPost]
        public async Task<IActionResult> Body()
        {
            Request.EnableBuffering(); 
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8, true, 1024, true))
            {
                var body = await reader.ReadToEndAsync();
                Request.Body.Position = 0;
                return Content(body, "text/plain");
            }
        }
    }
}