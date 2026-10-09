using System.ComponentModel.DataAnnotations;

namespace BaiTap_Repository_Pattern.Models;

public sealed class NhaCungCap
{
    public int NhaCungCapId { get; set; }

    [Required]
    [StringLength(150)]
    public string TenNhaCungCap { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string SoDienThoai { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    public string DiaChi { get; set; } = string.Empty;
}
