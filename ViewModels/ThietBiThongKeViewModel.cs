using BaiTap_Repository_Pattern.Models;

namespace BaiTap_Repository_Pattern.ViewModels;

public sealed class ThietBiThongKeViewModel
{
    public ThongKeTongQuanViewModel TongQuan { get; set; } = new();

    public IReadOnlyList<ThongKeTheoLoaiViewModel> TheoLoai { get; set; } =
        Array.Empty<ThongKeTheoLoaiViewModel>();

    public ThietBi? ThietBiGiaCaoNhat { get; set; }
}
