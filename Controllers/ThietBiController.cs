using BaiTap_Repository_Pattern.Models;
using BaiTap_Repository_Pattern.Repositories;
using BaiTap_Repository_Pattern.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap_Repository_Pattern.Controllers;

public sealed class ThietBiController : Controller
{
    private readonly IThietBiRepository thietBiRepository;

    public ThietBiController(IThietBiRepository thietBiRepository)
    {
        this.thietBiRepository = thietBiRepository;
    }

    public async Task<IActionResult> Index(ThietBiFilterViewModel filter)
    {
        filter.ThietBis = await thietBiRepository.SearchFilterSortAsync(
            filter.Keyword,
            filter.LoaiId,
            filter.SortBy);
        filter.LoaiThietBis = await thietBiRepository.GetAllLoaiAsync();
        return View(filter);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var thietBi = await thietBiRepository.GetByIdAsync(id.Value);
        return thietBi is null ? NotFound() : View(thietBi);
    }

    public async Task<IActionResult> Create()
    {
        await NapDanhSachLoaiAsync();
        return View(new ThietBi { NgayNhap = DateTime.Today });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ThietBi thietBi)
    {
        if (!ModelState.IsValid)
        {
            await NapDanhSachLoaiAsync();
            return View(thietBi);
        }

        await thietBiRepository.AddAsync(thietBi);
        TempData["ThongBao"] = "Đã thêm thiết bị mới.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var thietBi = await thietBiRepository.GetByIdAsync(id.Value);
        if (thietBi is null)
        {
            return NotFound();
        }

        await NapDanhSachLoaiAsync();
        return View(thietBi);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ThietBi thietBi)
    {
        if (id != thietBi.ThietBiId)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            await NapDanhSachLoaiAsync();
            return View(thietBi);
        }

        if (!await thietBiRepository.ExistsAsync(id))
        {
            return NotFound();
        }

        await thietBiRepository.UpdateAsync(thietBi);
        TempData["ThongBao"] = "Đã cập nhật thông tin thiết bị.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var thietBi = await thietBiRepository.GetByIdAsync(id.Value);
        return thietBi is null ? NotFound() : View(thietBi);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!await thietBiRepository.DeleteAsync(id))
        {
            return NotFound();
        }

        TempData["ThongBao"] = "Đã xóa thiết bị.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ThongKe()
    {
        var model = new ThietBiThongKeViewModel
        {
            TongQuan = await thietBiRepository.GetThongKeTongQuanAsync(),
            TheoLoai = await thietBiRepository.ThongKeSoLuongTheoLoaiAsync(),
            ThietBiGiaCaoNhat = await thietBiRepository.GetThietBiGiaCaoNhatAsync()
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }

    private async Task NapDanhSachLoaiAsync()
    {
        ViewData["LoaiThietBis"] = await thietBiRepository.GetAllLoaiAsync();
    }
}
