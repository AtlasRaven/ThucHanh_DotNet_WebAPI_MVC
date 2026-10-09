namespace BaiTap_Repository_Pattern.ViewModels;

public sealed class ThongKeTheoLoaiViewModel
{
    public int LoaiThietBiId { get; set; }

    public string TenLoai { get; set; } = string.Empty;

    public int SoMatHang { get; set; }

    public int TongSoLuong { get; set; }
}
