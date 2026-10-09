using System.ComponentModel.DataAnnotations;

namespace BaiTap_JavaScript_JQuery_Ajax.Models;

public sealed class ThietBi
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string TenThietBi { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal DonGia { get; set; }

    [Range(1, int.MaxValue)]
    public int SoLuong { get; set; }

    [Required]
    public int LoaiThietBiId { get; set; }

    public LoaiThietBi? LoaiThietBi { get; set; }
}
