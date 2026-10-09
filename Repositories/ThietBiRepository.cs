using BaiTap_Repository_Pattern.Data;
using BaiTap_Repository_Pattern.Models;
using BaiTap_Repository_Pattern.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BaiTap_Repository_Pattern.Repositories;

public sealed class ThietBiRepository : IThietBiRepository
{
    private readonly AppDbContext context;

    public ThietBiRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<IReadOnlyList<ThietBi>> GetAllAsync()
    {
        return await context.ThietBi
            .AsNoTracking()
            .OrderBy(thietBi => thietBi.ThietBiId)
            .ToListAsync();
    }

    public async Task<ThietBi?> GetByIdAsync(int id)
    {
        return await context.ThietBi
            .AsNoTracking()
            .Include(thietBi => thietBi.LoaiThietBi)
            .FirstOrDefaultAsync(thietBi => thietBi.ThietBiId == id);
    }

    public async Task AddAsync(ThietBi entity)
    {
        context.ThietBi.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ThietBi entity)
    {
        context.ThietBi.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await context.ThietBi.FindAsync(id);
        if (entity is null)
        {
            return false;
        }

        context.ThietBi.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public Task<bool> ExistsAsync(int id)
    {
        return context.ThietBi.AnyAsync(thietBi => thietBi.ThietBiId == id);
    }

    public async Task<IReadOnlyList<ThietBi>> SearchFilterSortAsync(
        string? keyword,
        int? loaiId,
        string? sortBy)
    {
        var truyVan = context.ThietBi
            .AsNoTracking()
            .Include(thietBi => thietBi.LoaiThietBi)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            var tuKhoa = keyword.Trim().ToLower();
            truyVan = truyVan.Where(thietBi => thietBi.TenThietBi.ToLower().Contains(tuKhoa));
        }

        if (loaiId.HasValue)
        {
            truyVan = truyVan.Where(thietBi => thietBi.LoaiThietBiId == loaiId.Value);
        }

        var sortOrder = sortBy?.ToLowerInvariant();
        if (sortOrder is "gia_tang" or "gia_giam")
        {
            var ketQua = await truyVan.ToListAsync();
            return sortOrder == "gia_tang"
                ? ketQua.OrderBy(thietBi => thietBi.DonGia).ToList()
                : ketQua.OrderByDescending(thietBi => thietBi.DonGia).ToList();
        }

        return sortOrder == "ngay_moi"
            ? await truyVan.OrderByDescending(thietBi => thietBi.NgayNhap).ToListAsync()
            : await truyVan.OrderBy(thietBi => thietBi.TenThietBi).ToListAsync();
    }

    public async Task<IReadOnlyList<ThietBi>> GetAllWithLoaiAsync()
    {
        return await context.ThietBi
            .AsNoTracking()
            .Include(thietBi => thietBi.LoaiThietBi)
            .OrderBy(thietBi => thietBi.ThietBiId)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<ThongKeTheoLoaiViewModel>> ThongKeSoLuongTheoLoaiAsync()
    {
        return await context.ThietBi
            .AsNoTracking()
            .GroupBy(thietBi => new { thietBi.LoaiThietBiId, thietBi.LoaiThietBi!.TenLoai })
            .Select(nhom => new ThongKeTheoLoaiViewModel
            {
                LoaiThietBiId = nhom.Key.LoaiThietBiId,
                TenLoai = nhom.Key.TenLoai,
                SoMatHang = nhom.Count(),
                TongSoLuong = nhom.Sum(thietBi => thietBi.SoLuong)
            })
            .OrderBy(thongKe => thongKe.TenLoai)
            .ToListAsync();
    }

    public async Task<decimal> TinhTongGiaTriHangTonAsync()
    {
        var thietBis = await context.ThietBi
            .AsNoTracking()
            .Select(thietBi => thietBi.DonGia * thietBi.SoLuong)
            .ToListAsync();

        return thietBis.Sum();
    }

    public async Task<ThietBi?> GetThietBiGiaCaoNhatAsync()
    {
        var thietBis = await context.ThietBi
            .AsNoTracking()
            .Include(thietBi => thietBi.LoaiThietBi)
            .ToListAsync();

        return thietBis.OrderByDescending(thietBi => thietBi.DonGia).FirstOrDefault();
    }

    public async Task<ThongKeTongQuanViewModel> GetThongKeTongQuanAsync()
    {
        var thietBis = await context.ThietBi
            .AsNoTracking()
            .ToListAsync();

        return new ThongKeTongQuanViewModel
        {
            TongSoMatHang = thietBis.Count,
            TongSoLuongSanPham = thietBis.Sum(thietBi => thietBi.SoLuong),
            GiaCaoNhat = thietBis.Count == 0 ? null : thietBis.Max(thietBi => thietBi.DonGia),
            GiaThapNhat = thietBis.Count == 0 ? null : thietBis.Min(thietBi => thietBi.DonGia),
            TongGiaTriHangTon = thietBis.Sum(thietBi => thietBi.DonGia * thietBi.SoLuong)
        };
    }

    public async Task<IReadOnlyList<LoaiThietBi>> GetAllLoaiAsync()
    {
        return await context.LoaiThietBi
            .AsNoTracking()
            .OrderBy(loai => loai.TenLoai)
            .ToListAsync();
    }
}
