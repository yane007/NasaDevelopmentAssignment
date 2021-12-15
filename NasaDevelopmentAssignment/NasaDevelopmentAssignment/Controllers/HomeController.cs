using Microsoft.AspNetCore.Mvc;
using NasaDevelopmentAssignment.Models;
using NasaServices.Contracts;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NasaDevelopmentAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly INasaApiService _nasaApiService;
        private readonly IExcelService _excelService;

        public HomeController(INasaApiService nasaApiService, IExcelService excelService)
        {
            this._nasaApiService = nasaApiService;
            this._excelService = excelService;
        }

        public async Task<IActionResult> Index(string page = "")
        {
            var asteroids = await _nasaApiService.GetAsteroids(page);

            ViewBag.PrevLink = null;
            ViewBag.NextLink = null;
            ViewBag.SelfLink = null;


            if (!string.IsNullOrEmpty(asteroids.Links.Prev))
            {
                var a = asteroids.Links.Prev.Split("page=")[1];
                ViewBag.PrevLink = a.Split("&")[0];
            }

            if (!string.IsNullOrEmpty(asteroids.Links.Next))
            {
                var a = asteroids.Links.Next.Split("page=")[1];
                ViewBag.NextLink = a.Split("&")[0];
            }

            if (!string.IsNullOrEmpty(asteroids.Links.Self))
            {
                var a = asteroids.Links.Self.Split("page=")[1];
                ViewBag.SelfLink = a.Split("&")[0];
            }

            return View(asteroids);
        }

        public async Task<IActionResult> APOD(string date = "")
        {
            var asteroid = await _nasaApiService.GetAPOD(date);

            if (asteroid.Explanation is null && asteroid.Hdurl is null && asteroid.MediaType is null & asteroid.Title is null & asteroid.Url is null)
            {
                ViewBag.ShowAsteroid = false;
            }
            else
            {
                ViewBag.ShowAsteroid = true;
            }

            return View(asteroid);
        }

        public async Task<IActionResult> DownloadAsteroids(string page = "")
        {
            var asteroids = await _nasaApiService.GetAsteroids(page);

            var content = await _excelService.CreateNasaFile(asteroids);

            var fileName = asteroids.Page == null ? "NoDataFound.xlsx" : $"NearEarthObjectsPage{asteroids.Page.Number + 1}.xlsx";

            var contentType = "APPLICATION/octet-stream";

            return File(content, contentType, fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
