using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositoryProjects repositoryProjects;
        private readonly IEmailSendGrid emailSendGrid;

        public HomeController(
            IRepositoryProjects repositoryProjects, IEmailSendGrid emailSendGrid
            )
        {
            this.repositoryProjects = repositoryProjects;
            this.emailSendGrid = emailSendGrid;
        }

        public IActionResult Index()
        {

            var project = repositoryProjects.ObtainProyect().Take(3).ToList();

            var model = new HomeIndexDTO()
            {
                Project = project,
            };
            return View(model);
        }

        public IActionResult Projects()
        {
            var projects = repositoryProjects.ObtainProyect();

            return View(projects);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactDTO contactDTO)
        {
            await emailSendGrid.Enviar(contactDTO);
            return RedirectToAction("Thanks");
        }

        public IActionResult Thanks()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
