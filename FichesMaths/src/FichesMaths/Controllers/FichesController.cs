using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace FichesMaths.Controllers
{
    [Route("api")]
    public class FichesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FichesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("demonstration-second-degre")]
        public virtual FileResult FicheSecondDegre()
        {

            var bytes = System.IO.File.ReadAllBytes($"{ _hostingEnvironment.WebRootPath}\\Fiche-Démonstration-Second-degré.pdf");
            return File(bytes,"application/pdf");

        }
    }
}
