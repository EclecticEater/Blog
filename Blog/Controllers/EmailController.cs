using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net.Mail;
using System.Text;

namespace Blog.Controllers
{
    public class EmailController : Controller
    {

        private string FunctionUrl = Environment.GetEnvironmentVariable("AZURE_FUNCTION_CONNECTIONSTRING");
        private readonly ApplicationDbContext _context;

        public EmailController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Email email)
        {
            if (!ModelState.IsValid)
            {
                return View(email);
            }
            try
            {
                await _context.AddAsync(email);
                await _context.SaveChangesAsync();

                // Prepare the JSON payload
                var payload = new
                {
                    email.emailAddress,
                    email.userName,
                    email.message,
                };

                var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

                using (var client = new HttpClient())
                {
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(FunctionUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to send email. Please try again later.";
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred while processing your request. Please try again later.";
                return View("Error");
            }
        }
    }
}
