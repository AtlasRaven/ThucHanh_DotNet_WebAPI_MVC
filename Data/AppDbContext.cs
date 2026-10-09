using BaiTap_Repository_Pattern.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTap_Repository_Pattern.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<LoaiThietBi> LoaiThietBi => Set<LoaiThietBi>();

    public DbSet<ThietBi> ThietBi => Set<ThietBi>();

    public DbSet<NhaCungCap> NhaCungCap => Set<NhaCungCap>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoaiThietBi>(entity =>
        {
            entity.ToTable("LoaiThietBi");
            entity.HasKey(loai => loai.LoaiThietBiId);
            entity.Property(loai => loai.TenLoai).HasMaxLength(100).IsRequired();
            entity.Property(loai => loai.MoTa).HasMaxLength(500);
            entity.HasData(
                new LoaiThietBi { LoaiThietBiId = 1, TenLoai = "Laptop", MoTa = "Máy tính xách tay" },
                new LoaiThietBi { LoaiThietBiId = 2, TenLoai = "Điện thoại", MoTa = "Điện thoại thông minh" },
                new LoaiThietBi { LoaiThietBiId = 3, TenLoai = "Máy tính bảng", MoTa = "Thiết bị máy tính bảng" },
                new LoaiThietBi { LoaiThietBiId = 4, TenLoai = "Màn hình", MoTa = "Màn hình máy tính" },
                new LoaiThietBi { LoaiThietBiId = 5, TenLoai = "Thiết bị mạng", MoTa = "Thiết bị kết nối mạng" });
        });

        modelBuilder.Entity<ThietBi>(entity =>
        {
            entity.ToTable("ThietBi");
            entity.HasKey(thietBi => thietBi.ThietBiId);
            entity.Property(thietBi => thietBi.TenThietBi).HasMaxLength(150).IsRequired();
            entity.Property(thietBi => thietBi.DonGia).HasPrecision(18, 2);
            entity.HasOne(thietBi => thietBi.LoaiThietBi)
                .WithMany(loai => loai.ThietBis)
                .HasForeignKey(thietBi => thietBi.LoaiThietBiId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasData(
                new ThietBi { ThietBiId = 1, TenThietBi = "Laptop Dell Inspiron 15", DonGia = 15990000m, SoLuong = 8, NgayNhap = new DateTime(2026, 1, 10), LoaiThietBiId = 1 },
                new ThietBi { ThietBiId = 2, TenThietBi = "Laptop ASUS Vivobook 15", DonGia = 17490000m, SoLuong = 6, NgayNhap = new DateTime(2026, 2, 12), LoaiThietBiId = 1 },
                new ThietBi { ThietBiId = 3, TenThietBi = "Laptop Lenovo IdeaPad Slim 5", DonGia = 18990000m, SoLuong = 5, NgayNhap = new DateTime(2026, 3, 8), LoaiThietBiId = 1 },
                new ThietBi { ThietBiId = 4, TenThietBi = "Laptop HP Pavilion 14", DonGia = 16990000m, SoLuong = 7, NgayNhap = new DateTime(2026, 4, 5), LoaiThietBiId = 1 },
                new ThietBi { ThietBiId = 5, TenThietBi = "Điện thoại Samsung Galaxy A55", DonGia = 9990000m, SoLuong = 14, NgayNhap = new DateTime(2026, 1, 22), LoaiThietBiId = 2 },
                new ThietBi { ThietBiId = 6, TenThietBi = "Điện thoại iPhone 15", DonGia = 19990000m, SoLuong = 9, NgayNhap = new DateTime(2026, 2, 18), LoaiThietBiId = 2 },
                new ThietBi { ThietBiId = 7, TenThietBi = "Điện thoại Xiaomi Redmi Note 14", DonGia = 6490000m, SoLuong = 18, NgayNhap = new DateTime(2026, 3, 17), LoaiThietBiId = 2 },
                new ThietBi { ThietBiId = 8, TenThietBi = "Điện thoại Google Pixel 9", DonGia = 21990000m, SoLuong = 4, NgayNhap = new DateTime(2026, 4, 11), LoaiThietBiId = 2 },
                new ThietBi { ThietBiId = 9, TenThietBi = "Máy tính bảng iPad Air", DonGia = 16990000m, SoLuong = 6, NgayNhap = new DateTime(2026, 1, 30), LoaiThietBiId = 3 },
                new ThietBi { ThietBiId = 10, TenThietBi = "Máy tính bảng Samsung Galaxy Tab S9 FE", DonGia = 11990000m, SoLuong = 8, NgayNhap = new DateTime(2026, 2, 24), LoaiThietBiId = 3 },
                new ThietBi { ThietBiId = 11, TenThietBi = "Màn hình LG UltraGear 27 inch", DonGia = 7490000m, SoLuong = 12, NgayNhap = new DateTime(2026, 3, 2), LoaiThietBiId = 4 },
                new ThietBi { ThietBiId = 12, TenThietBi = "Màn hình Dell UltraSharp 27 inch", DonGia = 11990000m, SoLuong = 5, NgayNhap = new DateTime(2026, 4, 2), LoaiThietBiId = 4 },
                new ThietBi { ThietBiId = 13, TenThietBi = "Router Wi-Fi TP-Link Archer AX55", DonGia = 2490000m, SoLuong = 20, NgayNhap = new DateTime(2026, 1, 15), LoaiThietBiId = 5 },
                new ThietBi { ThietBiId = 14, TenThietBi = "Router ASUS RT-AX82U", DonGia = 5790000m, SoLuong = 7, NgayNhap = new DateTime(2026, 3, 25), LoaiThietBiId = 5 },
                new ThietBi { ThietBiId = 15, TenThietBi = "Switch mạng TP-Link TL-SG108", DonGia = 790000m, SoLuong = 25, NgayNhap = new DateTime(2026, 4, 18), LoaiThietBiId = 5 });
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.ToTable("NhaCungCap");
            entity.HasKey(nhaCungCap => nhaCungCap.NhaCungCapId);
            entity.Property(nhaCungCap => nhaCungCap.TenNhaCungCap).HasMaxLength(150).IsRequired();
            entity.Property(nhaCungCap => nhaCungCap.SoDienThoai).HasMaxLength(20).IsRequired();
            entity.Property(nhaCungCap => nhaCungCap.DiaChi).HasMaxLength(250).IsRequired();
            entity.HasData(
                new NhaCungCap { NhaCungCapId = 1, TenNhaCungCap = "Công ty TNHH Công nghệ Sao Việt", SoDienThoai = "0901234567", DiaChi = "Hà Nội" },
                new NhaCungCap { NhaCungCapId = 2, TenNhaCungCap = "Công ty Cổ phần DigiWorld", SoDienThoai = "0902345678", DiaChi = "Thành phố Hồ Chí Minh" },
                new NhaCungCap { NhaCungCapId = 3, TenNhaCungCap = "Công ty TNHH Phân phối Minh Long", SoDienThoai = "0903456789", DiaChi = "Đà Nẵng" },
                new NhaCungCap { NhaCungCapId = 4, TenNhaCungCap = "Công ty Cổ phần Thiết bị số Việt", SoDienThoai = "0904567890", DiaChi = "Cần Thơ" });
        });
    }
}
