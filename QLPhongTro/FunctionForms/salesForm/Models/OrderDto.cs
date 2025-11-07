using System;

public class OrderDto
{
    public DateTime? Ngay { get; set; }
    public int MaDonHang { get; set; }
    public int MaKhachHang { get; set; }
    public string TenKhachHang { get; set; }
    public decimal TongTienHang { get; set; }
    public string KhuyenMai { get; set; }
    public string HinhThucThanhToan { get; set; }
    public decimal BangGia { get; set; }
    public decimal TaiKhoanThuHuong { get; set; }
    public decimal GiamGia { get; set; }
    public string ChuongTrinhKhuyenMai { get; set; }
    public string TenNhanVien { get; set; }
    public string GhiChu { get; set; }
    public string TrangThai { get; set; }
}