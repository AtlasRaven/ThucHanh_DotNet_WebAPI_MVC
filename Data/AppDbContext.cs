using BaiTap_JavaScript_JQuery_Ajax.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTap_JavaScript_JQuery_Ajax.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ThietBi> ThietBis => Set<ThietBi>();

    public DbSet<LoaiThietBi> LoaiThietBis => Set<LoaiThietBi>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoaiThietBi>(entity =>
        {
            entity.ToTable("LoaiThietBis");
            entity.HasKey(loai => loai.Id);
            entity.Property(loai => loai.TenLoai).HasMaxLength(100).IsRequired();
            entity.HasData(
                new LoaiThietBi { Id = 1, TenLoai = "Loa" },
                new LoaiThietBi { Id = 2, TenLoai = "Micro" },
                new LoaiThietBi { Id = 3, TenLoai = "Thiết bị xử lý âm thanh" },
                new LoaiThietBi { Id = 4, TenLoai = "Phụ kiện" });
        });

        modelBuilder.Entity<ThietBi>(entity =>
        {
            entity.ToTable("ThietBis");
            entity.HasKey(thietBi => thietBi.Id);
            entity.Property(thietBi => thietBi.TenThietBi).HasMaxLength(150).IsRequired();
            entity.Property(thietBi => thietBi.DonGia).HasPrecision(18, 2);
            entity.HasOne(thietBi => thietBi.LoaiThietBi)
                .WithMany(loai => loai.ThietBis)
                .HasForeignKey(thietBi => thietBi.LoaiThietBiId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasData(
                new ThietBi { Id = 1, TenThietBi = "Loa JBL PartyBox 110", DonGia = 8490000m, SoLuong = 8, LoaiThietBiId = 1 },
                new ThietBi { Id = 2, TenThietBi = "Loa Bose SoundLink Flex", DonGia = 3990000m, SoLuong = 12, LoaiThietBiId = 1 },
                new ThietBi { Id = 3, TenThietBi = "Loa kiểm âm Yamaha HS5", DonGia = 5790000m, SoLuong = 6, LoaiThietBiId = 1 },
                new ThietBi { Id = 4, TenThietBi = "Micro không dây Shure BLX24", DonGia = 7990000m, SoLuong = 5, LoaiThietBiId = 2 },
                new ThietBi { Id = 5, TenThietBi = "Micro có dây Shure SM58", DonGia = 2790000m, SoLuong = 20, LoaiThietBiId = 2 },
                new ThietBi { Id = 6, TenThietBi = "Micro thu âm Rode NT1", DonGia = 5990000m, SoLuong = 7, LoaiThietBiId = 2 },
                new ThietBi { Id = 7, TenThietBi = "Mixer Yamaha MG10XU", DonGia = 7490000m, SoLuong = 4, LoaiThietBiId = 3 },
                new ThietBi { Id = 8, TenThietBi = "Sound card Focusrite Scarlett 2i2", DonGia = 4690000m, SoLuong = 9, LoaiThietBiId = 3 },
                new ThietBi { Id = 9, TenThietBi = "Tai nghe Audio-Technica M50x", DonGia = 4290000m, SoLuong = 11, LoaiThietBiId = 4 },
                new ThietBi { Id = 10, TenThietBi = "Chân micro On-Stage MS7701B", DonGia = 890000m, SoLuong = 30, LoaiThietBiId = 4 });
        });
    }
}
