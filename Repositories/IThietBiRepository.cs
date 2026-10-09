using BaiTap_JavaScript_JQuery_Ajax.Models;

namespace BaiTap_JavaScript_JQuery_Ajax.Repositories;

public interface IThietBiRepository
{
    Task<IReadOnlyList<ThietBi>> TimKiemAsync(string? tuKhoa, int? loaiThietBiId = null);

    Task<IReadOnlyList<LoaiThietBi>> LayDanhSachLoaiAsync();
}
