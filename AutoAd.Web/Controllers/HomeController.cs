using AutoAd.Web.Models;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AutoAd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public HomeController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index()
        {
            List<VehicleDto>? list = new();
            ResponseDto response = await _vehicleService.GetVehiclesAsync();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VehicleDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> VehicleDetails(int vehicleId)
        {
            VehicleDto? vehicle = new();
            ResponseDto response = await _vehicleService.GetVehicleByIdAsync(vehicleId);
            if (response != null && response.isSuccess)
            {
                vehicle = JsonConvert.DeserializeObject<VehicleDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(vehicle);
        }

        public IActionResult Privacy()
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
