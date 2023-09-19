using AutoAd.Web.Models;
using AutoAd.Web.Service;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoAd.Web.Controllers
{
    public class FuelTypeController : Controller
    {
        private readonly IFuelTypeService _fuelTypeService;

        public FuelTypeController(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        public async Task<IActionResult> FuelTypeIndex()
        {
            List<FuelTypeDto>? list = new();
            ResponseDto response = await _fuelTypeService.GetFuelTypesAsync();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<FuelTypeDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> FuelTypeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FuelTypeCreate(FuelTypeDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _fuelTypeService.CreateFuelTypeAsync(model);
                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "Fuel Type Created Successfully";
                    return RedirectToAction(nameof(FuelTypeIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> FuelTypeEdit(int fuelTypeId)
        {
            ResponseDto? response = await _fuelTypeService.GetFuelTypeByIdAsync(fuelTypeId);
            if (response != null && response.isSuccess)
            {
                FuelTypeDto? model = JsonConvert.DeserializeObject<FuelTypeDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> FuelTypeEdit(FuelTypeDto fuelTypeDto)
        {
            ResponseDto? response = await _fuelTypeService.UpdateFuelTypeAsync(fuelTypeDto);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Fuel Type Updated Successfully";
                return RedirectToAction(nameof(FuelTypeIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(fuelTypeDto);
        }

        public async Task<IActionResult> FuelTypeDelete(int fuelTypeId)
        {
            ResponseDto? response = await _fuelTypeService.GetFuelTypeByIdAsync(fuelTypeId);
            if (response != null && response.isSuccess)
            {
                FuelTypeDto? model = JsonConvert.DeserializeObject<FuelTypeDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> FuelTypeDelete(FuelTypeDto fuelTypeDto)
        {
            ResponseDto? response = await _fuelTypeService.DeleteFuelTypeAsync(fuelTypeDto.Id);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Fuel Type Deleted Successfully";
                return RedirectToAction(nameof(FuelTypeIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(fuelTypeDto);
        }
    }
}
