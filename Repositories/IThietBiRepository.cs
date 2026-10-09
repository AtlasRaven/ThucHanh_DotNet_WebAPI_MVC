using BaiTap_Repository_Pattern.Models;
using BaiTap_Repository_Pattern.ViewModels;

namespace BaiTap_Repository_Pattern.Repositories;

public interface IThietBiRepository
{
    Task<IReadOnlyList<ThietBi>> GetAllAsync();

    Task<ThietBi?> GetByIdAsync(int id);

    Task AddAsync(ThietBi entity);

    Task UpdateAsync(ThietBi entity);

    Task<bool> DeleteAsync(int id);

    Task<bool> ExistsAsync(int id);

    Task<IReadOnlyList<ThietBi>> SearchFilterSortAsync(string? keyword, int? loaiId, string? sortBy);

    Task<IReadOnlyList<ThietBi>> GetAllWithLoaiAsync();

    Task<IReadOnlyList<ThongKeTheoLoaiViewModel>> ThongKeSoLuongTheoLoaiAsync();

    Task<decimal> TinhTongGiaTriHangTonAsync();

    Task<ThietBi?> GetThietBiGiaCaoNhatAsync();

    Task<ThongKeTongQuanViewModel> GetThongKeTongQuanAsync();

    Task<IReadOnlyList<LoaiThietBi>> GetAllLoaiAsync();
}
