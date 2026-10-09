using System.ComponentModel.DataAnnotations;

namespace BaiTap_Repository_Pattern.Models;

public sealed class LoaiThietBi
{
    public int LoaiThietBiId { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên loại thiết bị.")]
    [StringLength(100)]
    [Display(Name = "Tên loại")]
    public string TenLoai { get; set; } = string.Empty;

    [StringLength(500)]
    [Display(Name = "Mô tả")]
    public string? MoTa { get; set; }

    public ICollection<ThietBi> ThietBis { get; set; } = new List<ThietBi>();
}
