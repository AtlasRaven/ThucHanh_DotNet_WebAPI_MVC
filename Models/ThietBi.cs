using System.ComponentModel.DataAnnotations;

namespace BaiTap_Repository_Pattern.Models;

public sealed class ThietBi
{
    public int ThietBiId { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên thiết bị.")]
    [StringLength(150, ErrorMessage = "Tên thiết bị không được vượt quá 150 ký tự.")]
    [Display(Name = "Tên thiết bị")]
    public string TenThietBi { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "9999999999999999", ErrorMessage = "Đơn giá phải lớn hơn 0.")]
    [Display(Name = "Đơn giá")]
    public decimal DonGia { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Số lượng không được âm.")]
    [Display(Name = "Số lượng")]
    public int SoLuong { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngày nhập")]
    public DateTime NgayNhap { get; set; } = DateTime.Today;

    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn loại thiết bị.")]
    [Display(Name = "Loại thiết bị")]
    public int LoaiThietBiId { get; set; }

    public LoaiThietBi? LoaiThietBi { get; set; }
}
