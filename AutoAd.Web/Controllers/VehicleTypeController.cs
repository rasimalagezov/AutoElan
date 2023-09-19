using AutoAd.Web.Models;
using AutoAd.Web.Service;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoAd.Web.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        public async Task<IActionResult> VehicleTypeIndex()
        {
            List<VehicleTypeDto>? list = new();
            ResponseDto response = await _vehicleTypeService.GetVehicleTypesAsync();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VehicleTypeDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> VehicleTypeCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VehicleTypeCreate(VehicleTypeDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _vehicleTypeService.CreateVehicleTypeAsync(model);
                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "Vehicle Type Created Successfully";
                    return RedirectToAction(nameof(VehicleTypeIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> VehicleTypeEdit(int vehicleTypeId)
        {
            ResponseDto? response = await _vehicleTypeService.GetVehicleTypeByIdAsync(vehicleTypeId);
            if (response != null && response.isSuccess)
            {
                VehicleTypeDto? model = JsonConvert.DeserializeObject<VehicleTypeDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> VehicleTypeEdit(VehicleTypeDto vehicleTypeDto)
        {
            ResponseDto? response = await _vehicleTypeService.UpdateVehicleTypeAsync(vehicleTypeDto);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Vehicle Type Updated Successfully";
                return RedirectToAction(nameof(VehicleTypeIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(vehicleTypeDto);
        }

        public async Task<IActionResult> VehicleTypeDelete(int vehicleTypeId)
        {
            ResponseDto? response = await _vehicleTypeService.GetVehicleTypeByIdAsync(vehicleTypeId);
            if (response != null && response.isSuccess)
            {
                VehicleTypeDto? model = JsonConvert.DeserializeObject<VehicleTypeDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> VehicleTypeDelete(VehicleTypeDto vehicleTypeDto)
        {
            ResponseDto? response = await _vehicleTypeService.DeleteVehicleTypeAsync(vehicleTypeDto.Id);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Vehicle Type Deleted Successfully";
                return RedirectToAction(nameof(VehicleTypeIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(vehicleTypeDto);
        }
    }
}
