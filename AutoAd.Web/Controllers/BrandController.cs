using AutoAd.Web.Models;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoAd.Web.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> BrandIndex()
        {
            List<BrandDto>? list = new();
            ResponseDto response = await _brandService.GetBrandsAsync();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BrandDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(list);
        }


        public async Task<IActionResult> BrandCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BrandCreate(BrandDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _brandService.CreateBrandAsync(model);
                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "Brand Created Successfully";
                    return RedirectToAction(nameof(BrandIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> BrandEdit(int brandId)
        {
            ResponseDto? response = await _brandService.GetBrandByIdAsync(brandId);
            if (response != null && response.isSuccess)
            {
                BrandDto? model = JsonConvert.DeserializeObject<BrandDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> BrandEdit(BrandDto brandDto)
        {
            ResponseDto? response = await _brandService.UpdateBrandAsync(brandDto);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Brand Updated Successfully";
                return RedirectToAction(nameof(BrandIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(brandDto);
        }

        public async Task<IActionResult> BrandDelete(int brandId)
        {
            ResponseDto? response = await _brandService.GetBrandByIdAsync(brandId);
            if (response != null && response.isSuccess)
            {
                BrandDto? model = JsonConvert.DeserializeObject<BrandDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> BrandDelete(BrandDto brandDto)
        {
            ResponseDto? response = await _brandService.DeleteBrandAsync(brandDto.Id);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Brand Deleted Successfully";
                return RedirectToAction(nameof(BrandIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(brandDto);
        }
    }
}
