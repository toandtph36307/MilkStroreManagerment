using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLPhongTro.FunctionForms.salesForm.View
{
    public partial class SalesOrders : Form
    {
        private OrderBll _orderBll;

        public SalesOrders()
        {
            InitializeComponent();
            cbbConditions.Items.Add("Mã đơn hàng");
            cbbConditions.Items.Add("Mã khách hàng");
            cbbConditions.Items.Add("Tên khách hàng");
            cbbConditions.Items.Add("Tất cả");
            cbbConditions.StartIndex = 3;
            cbbConditions.SelectedIndex = 3;
            string connectionString = @"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True";
            var orderDal = new OrderDal(connectionString);
            _orderBll = new OrderBll(orderDal);
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = _orderBll.GetOrders();
            dvgOders.DataSource = orders;
            dvgOders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            
            dvgOders.Columns[nameof(OrderDto.Ngay)].HeaderText = "Ngày";
            dvgOders.Columns[nameof(OrderDto.Ngay)].Width = 100;

            dvgOders.Columns[nameof(OrderDto.MaDonHang)].HeaderText = "Mã đơn hàng";
            dvgOders.Columns[nameof(OrderDto.MaDonHang)].Width = 90;

            dvgOders.Columns[nameof(OrderDto.MaKhachHang)].HeaderText = "Mã khách hàng";
            dvgOders.Columns[nameof(OrderDto.MaKhachHang)].Width = 100;

            dvgOders.Columns[nameof(OrderDto.TenKhachHang)].HeaderText = "Tên khách hàng";
            dvgOders.Columns[nameof(OrderDto.TenKhachHang)].Width = 120;

            dvgOders.Columns[nameof(OrderDto.TongTienHang)].HeaderText = "Tổng tiền hàng";
            dvgOders.Columns[nameof(OrderDto.TongTienHang)].Width = 110;

            dvgOders.Columns[nameof(OrderDto.KhuyenMai)].HeaderText = "Khuyến mãi";
            dvgOders.Columns[nameof(OrderDto.KhuyenMai)].Width = 90;

            dvgOders.Columns[nameof(OrderDto.HinhThucThanhToan)].HeaderText = "Hình thức thanh toán";
            dvgOders.Columns[nameof(OrderDto.HinhThucThanhToan)].Width = 120;

            dvgOders.Columns[nameof(OrderDto.BangGia)].HeaderText = "Bảng giá";
            dvgOders.Columns[nameof(OrderDto.BangGia)].Width = 80;

            dvgOders.Columns[nameof(OrderDto.TaiKhoanThuHuong)].HeaderText = "Tài khoản thụ hưởng";
            dvgOders.Columns[nameof(OrderDto.TaiKhoanThuHuong)].Width = 120;

            dvgOders.Columns[nameof(OrderDto.GiamGia)].HeaderText = "Giảm giá";
            dvgOders.Columns[nameof(OrderDto.GiamGia)].Width = 80;

            dvgOders.Columns[nameof(OrderDto.ChuongTrinhKhuyenMai)].HeaderText = "Chương trình khuyến mãi";
            dvgOders.Columns[nameof(OrderDto.ChuongTrinhKhuyenMai)].Width = 140;

            dvgOders.Columns[nameof(OrderDto.TenNhanVien)].HeaderText = "Tên nhân viên";
            dvgOders.Columns[nameof(OrderDto.TenNhanVien)].Width = 110;

            dvgOders.Columns[nameof(OrderDto.GhiChu)].HeaderText = "Ghi chú";
            dvgOders.Columns[nameof(OrderDto.GhiChu)].Width = 80;

            dvgOders.Columns[nameof(OrderDto.TrangThai)].HeaderText = "Trạng thái";
            dvgOders.Columns[nameof(OrderDto.TrangThai)].Width = 90;
        }

        private void dvgOders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dvgOders.Columns[e.ColumnIndex].Name == nameof(OrderDto.TongTienHang) && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("#,0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            library1.Visible = !library1.Visible;
            library1.BringToFront();
            library1.Size = library1.MaximumSize;
        }

        private void SalesOrders_Load(object sender, EventArgs e)
        {

        }
    }
}
