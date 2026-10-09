using BaiTap_JavaScript_JQuery_Ajax.Models;

namespace BaiTap_JavaScript_JQuery_Ajax.ViewModels;

public sealed class AjaxSearchViewModel
{
    public IReadOnlyList<LoaiThietBi> LoaiThietBis { get; init; } = Array.Empty<LoaiThietBi>();

    public IReadOnlyList<ThietBi> ThietBis { get; init; } = Array.Empty<ThietBi>();
}
