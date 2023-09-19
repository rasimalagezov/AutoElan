using AutoAd.Web.Models;
using AutoAd.Web.Service;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AutoAd.Web.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;
        private readonly IBrandService _brandService;

        public ModelController(IModelService modelService, IBrandService brandService)
        {
            _modelService = modelService;
            _brandService = brandService;
        }

        public async Task<IActionResult> ModelIndex()
        {
            List<ModelDto>? list = new();
            ResponseDto response = await _modelService.GetModelsAsync();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ModelDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> ModelCreate()
        {
            ViewBag.Brands = await GetBrands();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ModelCreate(ModelDto model)
        {

            if (ModelState.IsValid)
            {
                ResponseDto? response = await _modelService.CreateModelAsync(model);
                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "Model Created Successfully";
                    return RedirectToAction(nameof(ModelIndex));
                }
                else
                {
                    TempData["error"] = response.Message;
                }
            }

            ViewBag.Brands = await GetBrands();
            return View(model);
        }

        public async Task<IActionResult> ModelEdit(int modelId)
        {
            ViewBag.Brands = await GetBrands();
            ResponseDto? response = await _modelService.GetModelByIdAsync(modelId);
            if (response != null && response.isSuccess)
            {
                ModelDto? model = JsonConvert.DeserializeObject<ModelDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ModelEdit(ModelDto modelDto)
        {
            ResponseDto? response = await _modelService.UpdateModelAsync(modelDto);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Model Updated Successfully";
                return RedirectToAction(nameof(ModelIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            ViewBag.Brands = await GetBrands();
            return View(modelDto);
        }

        public async Task<IActionResult> ModelDelete(int modelId)
        {
            ViewBag.Brands = await GetBrands();
            ResponseDto? response = await _modelService.GetModelByIdAsync(modelId);
            if (response != null && response.isSuccess)
            {
                ModelDto? model = JsonConvert.DeserializeObject<ModelDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ModelDelete(ModelDto modelDto)
        {
            ResponseDto? response = await _modelService.DeleteModelAsync(modelDto.Id);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Model Deleted Successfully";
                return RedirectToAction(nameof(ModelIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            ViewBag.Brands = await GetBrands();
            return View(modelDto);
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
    }
}
