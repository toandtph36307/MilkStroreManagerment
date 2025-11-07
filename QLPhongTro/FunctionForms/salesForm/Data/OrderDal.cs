using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class OrderDal
{
    private readonly string _connectionString;

    public OrderDal(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<OrderDto> GetAllOrders()
    {
        var orders = new List<OrderDto>();
        string query = @"
            SELECT 
                o.order_date AS Ngay,
                o.order_id AS MaDonHang,
                c.customer_id AS MaKhachHang,
                c.full_name AS TenKhachHang,
                o.total_price AS TongTienHang,
                d.code AS KhuyenMai,
                pmt.payment_method AS HinhThucThanhToan,
                o.total_price AS BangGia,
                pmt.amount_paid AS TaiKhoanThuHuong,
                d.value AS GiamGia,
                d.description AS ChuongTrinhKhuyenMai,
                u.full_name AS TenNhanVien,
                '' AS GhiChu,
                o.status AS TrangThai
            FROM Orders o
            JOIN Customers c ON o.customer_id = c.customer_id
            LEFT JOIN Discounts d ON o.discount_id = d.discount_id
            JOIN Users u ON o.user_id = u.user_id
            LEFT JOIN Payments pmt ON o.order_id = pmt.order_id
        ";

        using (var conn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    orders.Add(new OrderDto
                    {
                        Ngay = reader["Ngay"] as DateTime?,
                        MaDonHang = (int)reader["MaDonHang"],
                        MaKhachHang = (int)reader["MaKhachHang"],
                        TenKhachHang = reader["TenKhachHang"].ToString(),
                        TongTienHang = (decimal)reader["TongTienHang"],
                        KhuyenMai = reader["KhuyenMai"]?.ToString(),
                        HinhThucThanhToan = reader["HinhThucThanhToan"]?.ToString(),
                        BangGia = (decimal)reader["BangGia"],
                        TaiKhoanThuHuong = reader["TaiKhoanThuHuong"] == DBNull.Value ? 0 : (decimal)reader["TaiKhoanThuHuong"],
                        GiamGia = reader["GiamGia"] == DBNull.Value ? 0 : (decimal)reader["GiamGia"],
                        ChuongTrinhKhuyenMai = reader["ChuongTrinhKhuyenMai"]?.ToString(),
                        TenNhanVien = reader["TenNhanVien"].ToString(),
                        GhiChu = reader["GhiChu"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    });
                }
            }
        }
        return orders;
    }
}