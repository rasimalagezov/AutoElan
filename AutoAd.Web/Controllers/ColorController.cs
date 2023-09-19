using AutoAd.Web.Models;
using AutoAd.Web.Service;
using AutoAd.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AutoAd.Web.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        public async Task<IActionResult> ColorIndex()
        {
            List<ColorDto>? list = new();
            ResponseDto response = await _colorService.GetColorsAsync();
            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ColorDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            return View(list);
        }

        public async Task<IActionResult> ColorCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ColorCreate(ColorDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _colorService.CreateColorAsync(model);
                if (response != null && response.isSuccess)
                {
                    TempData["success"] = "Color Created Successfully";
                    return RedirectToAction(nameof(ColorIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ColorEdit(int colorId)
        {
            ResponseDto? response = await _colorService.GetColorByIdAsync(colorId);
            if (response != null && response.isSuccess)
            {
                ColorDto? model = JsonConvert.DeserializeObject<ColorDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ColorEdit(ColorDto colorDto)
        {
            ResponseDto? response = await _colorService.UpdateColorAsync(colorDto);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Color Updated Successfully";
                return RedirectToAction(nameof(ColorIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(colorDto);
        }

        public async Task<IActionResult> ColorDelete(int colorId)
        {
            ResponseDto? response = await _colorService.GetColorByIdAsync(colorId);
            if (response != null && response.isSuccess)
            {
                ColorDto? model = JsonConvert.DeserializeObject<ColorDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ColorDelete(ColorDto colorDto)
        {
            ResponseDto? response = await _colorService.DeleteColorAsync(colorDto.Id);
            if (response != null && response.isSuccess)
            {
                TempData["success"] = "Color Deleted Successfully";
                return RedirectToAction(nameof(ColorIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(colorDto);
        }

    }
}
