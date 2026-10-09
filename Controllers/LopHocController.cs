using BaiTap_JavaScript_JQuery_Ajax.Repositories;
using BaiTap_JavaScript_JQuery_Ajax.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap_JavaScript_JQuery_Ajax.Controllers;

public sealed class LopHocController(IThietBiRepository thietBiRepository) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }

    public IActionResult JavaScript()
    {
        return View();
    }

    public IActionResult JQuery()
    {
        return View();
    }

    public async Task<IActionResult> Ajax()
    {
        var model = new AjaxSearchViewModel
        {
            LoaiThietBis = await thietBiRepository.LayDanhSachLoaiAsync(),
            ThietBis = await thietBiRepository.TimKiemAsync(null)
        };

        return View(model);
    }

    [HttpGet]
    public ContentResult XinChao()
    {
        return Content("Xin chào từ Server", "text/plain; charset=utf-8");
    }

    [HttpGet]
    public JsonResult TimKiemTuKhoa(string? keyword)
    {
        var ketQua = string.IsNullOrWhiteSpace(keyword)
            ? "Vui lòng nhập từ khóa."
            : $"Server đã nhận từ khóa: {keyword.Trim()}";

        return Json(new { message = ketQua });
    }

    [HttpGet]
    public async Task<IActionResult> TimKiemThietBi(string? keyword, int? loaiThietBiId)
    {
        var thietBis = await thietBiRepository.TimKiemAsync(keyword, loaiThietBiId);
        return PartialView("_DanhSachThietBiPartial", thietBis);
    }
}
