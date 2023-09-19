using AutoAd.Web.Models;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace AutoAd.Web.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IBrandService _brandService;
        private readonly IModelService _modelService;
        private readonly IColorService _colorService;
        private readonly IFuelTypeService _fuelTypeService;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IGearboxService _gearboxService;

        public VehicleController(IVehicleService vehicleService, IBrandService brandService, IModelService modelService, IColorService colorService, IFuelTypeService fuelTypeService, IVehicleTypeService vehicleTypeService, IGearboxService gearboxService)
        {
            _vehicleService = vehicleService;
            _brandService = brandService;
            _modelService = modelService;
            _colorService = colorService;
            _fuelTypeService = fuelTypeService;
            _vehicleTypeService = vehicleTypeService;
            _gearboxService = gearboxService;
        }

        public async Task<IActionResult> VehicleIndex()
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

        public async Task<IActionResult> VehicleCreate()
        {
            ViewBag.Brands = await GetBrands();
            ViewBag.Colors = await GetColors();
            ViewBag.VehicleTypes = await GetVehicleTypes();
            ViewBag.FuelTypes = await GetFuelTypes();
            ViewBag.Gearboxes = await GetGearboxes();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VehicleCreate(VehicleDto vehicleDto)
        {

            if (ModelState.IsValid)
            {
                ResponseDto? response = await _vehicleService.CreateVehicleAsync(vehicleDto);
                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "Vehicle Created Successfully";
                    return RedirectToAction(nameof(VehicleIndex));
                }
                else
                {
                    TempData["error"] = response.Message;
                }
            }

            ViewBag.Brands = await GetBrands();
            ViewBag.Models = await GetModels();
            ViewBag.Colors = await GetColors();
            ViewBag.VehicleTypes = await GetVehicleTypes();
            ViewBag.FuelTypes = await GetFuelTypes();
            ViewBag.Gearboxes = await GetGearboxes();
            return View(vehicleDto);
        }

        public async Task<IActionResult> VehicleEdit(int vehicleId)
        {
            ViewBag.Brands = await GetBrands();
            ViewBag.Models = await GetModels();
            ViewBag.Colors = await GetColors();
            ViewBag.VehicleTypes = await GetVehicleTypes();
            ViewBag.FuelTypes = await GetFuelTypes();
            ViewBag.Gearboxes = await GetGearboxes();
            ResponseDto? response = await _vehicleService.GetVehicleByIdAsync(vehicleId);
            if (response != null && response.isSuccess)
            {
                VehicleDto? vehicle = JsonConvert.DeserializeObject<VehicleDto>(Convert.ToString(response.Result));
                return View(vehicle);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> VehicleEdit(VehicleDto vehicleDto)
        {
            ResponseDto? response = await _vehicleService.UpdateVehicleAsync(vehicleDto);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Vehicle Updated Successfully";
                return RedirectToAction(nameof(VehicleIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            ViewBag.Brands = await GetBrands();
            ViewBag.Models = await GetModels();
            ViewBag.Colors = await GetColors();
            ViewBag.VehicleTypes = await GetVehicleTypes();
            ViewBag.FuelTypes = await GetFuelTypes();
            ViewBag.Gearboxes = await GetGearboxes();
            return View(vehicleDto);
        }

        public async Task<IActionResult> VehicleDelete(int vehicleId)
        {
            ViewBag.Brands = await GetBrands();
            ResponseDto? response = await _vehicleService.GetVehicleByIdAsync(vehicleId);
            if (response != null && response.isSuccess)
            {
                VehicleDto? model = JsonConvert.DeserializeObject<VehicleDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> VehicleDelete(VehicleDto vehicleDto)
        {
            ResponseDto? response = await _vehicleService.DeleteVehicleAsync(vehicleDto.Id);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Vehicle Deleted Successfully";
                return RedirectToAction(nameof(VehicleIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            ViewBag.Brands = await GetBrands();
            return View(vehicleDto);
        }


        private async Task<List<SelectListItem>> GetBrands()
        {
            var brandList = new List<SelectListItem>();
            List<BrandDto>? brands = new();
            ResponseDto result = await _brandService.GetBrandsAsync();

            if (result != null && result.isSuccess)
            {
                brands = JsonConvert.DeserializeObject<List<BrandDto>>(Convert.ToString(result.Result));
            }
            foreach (var brand in brands)
            {
                brandList.Add(new SelectListItem { Text = brand.Name, Value = brand.Id.ToString() });
            }
            return brandList;
        }

        private async Task<List<SelectListItem>> GetModels()
        {
            var modelList = new List<SelectListItem>();
            List<ModelDto>? models = new();
            ResponseDto result = await _modelService.GetModelsAsync();

            if (result != null && result.isSuccess)
            {
                models = JsonConvert.DeserializeObject<List<ModelDto>>(Convert.ToString(result.Result));
            }
            foreach (var model in models)
            {
                modelList.Add(new SelectListItem { Text = model.Name, Value = model.Id.ToString() });
            }
            return modelList;
        }


        public async Task<JsonResult> GetModelsByBrandId(int brandId)
        {
            List<ModelDto>? list = new();
            ResponseDto response = await _modelService.GetModelsByBrandIdAsync(brandId);
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ModelDto>>(Convert.ToString(response.Result));
            }
            return Json(list);
        }

        private async Task<List<SelectListItem>> GetColors()
        {
            var colorList = new List<SelectListItem>();
            List<ColorDto>? colors = new();
            ResponseDto result = await _colorService.GetColorsAsync();
            if (result != null && result.isSuccess)
            {
                colors = JsonConvert.DeserializeObject<List<ColorDto>>(Convert.ToString(result.Result));
            }
            foreach (var color in colors)
            {
                colorList.Add(new SelectListItem { Text = color.Name, Value = color.Id.ToString() });
            }
            return colorList;
        }

        private async Task<List<SelectListItem>> GetVehicleTypes()
        {
            var vehicleTypeList = new List<SelectListItem>();
            List<VehicleTypeDto>? vehicleTypes = new();
            ResponseDto result = await _vehicleTypeService.GetVehicleTypesAsync();
            if (result != null && result.isSuccess)
            {
                vehicleTypes = JsonConvert.DeserializeObject<List<VehicleTypeDto>>(Convert.ToString(result.Result));
            }
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleTypeList.Add(new SelectListItem { Text = vehicleType.Name, Value = vehicleType.Id.ToString() });
            }
            return vehicleTypeList;
        }

        private async Task<List<SelectListItem>> GetFuelTypes()
        {
            var fuelTypeList = new List<SelectListItem>();
            List<FuelTypeDto>? fuelTypes = new();
            ResponseDto result = await _fuelTypeService.GetFuelTypesAsync();
            if (result != null && result.isSuccess)
            {
                fuelTypes = JsonConvert.DeserializeObject<List<FuelTypeDto>>(Convert.ToString(result.Result));
            }
            foreach (var fuelType in fuelTypes)
            {
                fuelTypeList.Add(new SelectListItem { Text = fuelType.Name, Value = fuelType.Id.ToString() });
            }
            return fuelTypeList;
        }

        private async Task<List<SelectListItem>> GetGearboxes()
        {
            var gearboxList = new List<SelectListItem>();
            List<GearboxDto>? gearboxes = new();
            ResponseDto result = await _gearboxService.GetGearboxesAsync();
            if (result != null && result.isSuccess)
            {
                gearboxes = JsonConvert.DeserializeObject<List<GearboxDto>>(Convert.ToString(result.Result));
            }
            foreach (var gearbox in gearboxes)
            {
                gearboxList.Add(new SelectListItem { Text = gearbox.Name, Value = gearbox.Id.ToString() });
            }
            return gearboxList;
        }
    }
}
