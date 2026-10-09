using System.ComponentModel.DataAnnotations;

namespace BaiTap_JavaScript_JQuery_Ajax.Models;

public sealed class LoaiThietBi
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string TenLoai { get; set; } = string.Empty;

    public ICollection<ThietBi> ThietBis { get; set; } = new List<ThietBi>();
}
