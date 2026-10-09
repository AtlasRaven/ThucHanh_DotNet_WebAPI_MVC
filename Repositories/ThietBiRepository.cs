using BaiTap_JavaScript_JQuery_Ajax.Data;
using BaiTap_JavaScript_JQuery_Ajax.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTap_JavaScript_JQuery_Ajax.Repositories;

public sealed class ThietBiRepository(AppDbContext context) : IThietBiRepository
{
    public async Task<IReadOnlyList<ThietBi>> TimKiemAsync(string? tuKhoa, int? loaiThietBiId = null)
    {
        var truyVan = context.ThietBis
            .AsNoTracking()
            .Include(thietBi => thietBi.LoaiThietBi)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(tuKhoa))
        {
            var tuKhoaDaChuanHoa = tuKhoa.Trim().ToLower();
            truyVan = truyVan.Where(thietBi =>
                thietBi.TenThietBi.ToLower().Contains(tuKhoaDaChuanHoa));
        }

        if (loaiThietBiId.HasValue)
        {
            truyVan = truyVan.Where(thietBi => thietBi.LoaiThietBiId == loaiThietBiId.Value);
        }

        return await truyVan
            .OrderBy(thietBi => thietBi.TenThietBi)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<LoaiThietBi>> LayDanhSachLoaiAsync()
    {
        return await context.LoaiThietBis
            .AsNoTracking()
            .OrderBy(loai => loai.TenLoai)
            .ToListAsync();
    }
}
