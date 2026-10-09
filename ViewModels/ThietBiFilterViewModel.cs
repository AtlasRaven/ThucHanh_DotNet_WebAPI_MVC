using BaiTap_Repository_Pattern.Models;

namespace BaiTap_Repository_Pattern.ViewModels;

public sealed class ThietBiFilterViewModel
{
    public string? Keyword { get; set; }

    public int? LoaiId { get; set; }

    public string SortBy { get; set; } = "ten";

    public IReadOnlyList<LoaiThietBi> LoaiThietBis { get; set; } = Array.Empty<LoaiThietBi>();

    public IReadOnlyList<ThietBi> ThietBis { get; set; } = Array.Empty<ThietBi>();
}
