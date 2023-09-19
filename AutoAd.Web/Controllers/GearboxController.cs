using AutoAd.Web.Models;
using AutoAd.Web.Service;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoAd.Web.Controllers
{
    public class GearboxController : Controller
    {
        private readonly IGearboxService _gearboxService;

        public GearboxController(IGearboxService gearboxService)
        {
            _gearboxService = gearboxService;
        }

        public async Task<IActionResult> GearboxIndex()
        {
            List<GearboxDto>? list = new();
            ResponseDto response = await _gearboxService.GetGearboxesAsync();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<GearboxDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> GearboxCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GearboxCreate(GearboxDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _gearboxService.CreateGearboxAsync(model);
                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "Gearbox Created Successfully";
                    return RedirectToAction(nameof(GearboxIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> GearboxEdit(int gearboxId)
        {
            ResponseDto? response = await _gearboxService.GetGearboxByIdAsync(gearboxId);
            if (response != null && response.isSuccess)
            {
                GearboxDto? model = JsonConvert.DeserializeObject<GearboxDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> GearboxEdit(GearboxDto gearboxDto)
        {
            ResponseDto? response = await _gearboxService.UpdateGearboxAsync(gearboxDto);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Gearbox Updated Successfully";
                return RedirectToAction(nameof(GearboxIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(gearboxDto);
        }

        public async Task<IActionResult> GearboxDelete(int gearboxId)
        {
            ResponseDto? response = await _gearboxService.GetGearboxByIdAsync(gearboxId);
            if (response != null && response.isSuccess)
            {
                GearboxDto? model = JsonConvert.DeserializeObject<GearboxDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> GearboxDelete(GearboxDto gearboxDto)
        {
            ResponseDto? response = await _gearboxService.DeleteGearboxAsync(gearboxDto.Id);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Gearbox Deleted Successfully";
                return RedirectToAction(nameof(GearboxIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(gearboxDto);
        }

    }
}
