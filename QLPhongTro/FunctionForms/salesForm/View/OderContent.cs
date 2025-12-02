using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLPhongTro.FunctionForms.salesForm.Models;

namespace QLPhongTro.FunctionForms.CustomerForm.View
{
    public partial class OderContent : UserControl
    {
        public event EventHandler CloseTabRequested;
        public event Action<decimal> TotalMoneyChanged;

        public OderContent()
        {
            InitializeComponent();

            dvgOrder.AutoGenerateColumns = false;
            dvgOrder.Dock = DockStyle.Fill; 

            this.dvgOrder.Columns.Add("colSTT", "STT");
            this.dvgOrder.Columns.Add("colBarcode", "Mã vạch");
            this.dvgOrder.Columns.Add("colProductName", "Tên sản phẩm");
            this.dvgOrder.Columns.Add("colUnit", "Đơn vị tính");

            var btnMinus = new DataGridViewButtonColumn();
            btnMinus.Name = "colMinus";
            btnMinus.HeaderText = "";
            btnMinus.Width = 32;
            btnMinus.Text = "−";
            btnMinus.UseColumnTextForButtonValue = true;
            dvgOrder.Columns.Add(btnMinus);

            this.dvgOrder.Columns.Add("colQuantity", "Số lượng");

            var btnPlus = new DataGridViewButtonColumn();
            btnPlus.Name = "colPlus";
            btnPlus.HeaderText = "";
            btnPlus.Width = 32;
            btnPlus.Text = "+";
            btnPlus.UseColumnTextForButtonValue = true;
            dvgOrder.Columns.Add(btnPlus);

            this.dvgOrder.Columns.Add("colPrice", "Giá bán");
            this.dvgOrder.Columns.Add("colTotal", "Thành tiền");

            var btnCol = new DataGridViewButtonColumn();
            btnCol.Name = "colDelete";
            btnCol.HeaderText = "";
            btnCol.Text = "X";
            btnCol.Width = 32;
            btnCol.UseColumnTextForButtonValue = true;
            this.dvgOrder.Columns.Add(btnCol);

            dvgOrder.Columns["colSTT"].Width = 50;
            dvgOrder.Columns["colProductName"].Width = 150;
            dvgOrder.Columns["colBarcode"].Width = 80;
            dvgOrder.Columns["colUnit"].Width = 80;
            dvgOrder.Columns["colMinus"].Width = 32;
            dvgOrder.Columns["colQuantity"].Width = 70;
            dvgOrder.Columns["colPlus"].Width = 32;
            dvgOrder.Columns["colPrice"].Width = 100;
            dvgOrder.Columns["colTotal"].Width = 120;
            dvgOrder.Columns["colDelete"].Width = 32;

            dvgOrder.Columns["colProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dvgOrder.Columns["colProductName"].FillWeight = 60;
            dvgOrder.Columns["colSTT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colBarcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colUnit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colMinus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dvgOrder.Columns["colPlus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colDelete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dvgOrder.Columns["colDelete"].FillWeight = 10;

            
            this.Resize += OderContent_Resize;
            this.Layout += OderContent_Layout;
            this.ParentChanged += OderContent_ParentChanged;

            PositionCloseButton();
            btnClose.BringToFront();
        }
            
        private void OderContent_ParentChanged(object sender, EventArgs e)
        {
            PositionCloseButton();
            btnClose.BringToFront();
        }

        private void OderContent_Layout(object sender, LayoutEventArgs e)
        {
            PositionCloseButton();
        }

        private void OderContent_Resize(object sender, EventArgs e)
        {
            PositionCloseButton();
        }

        private void PositionCloseButton()
        {
            const int margin = 6;

            if (btnClose == null) return;

            int x = Math.Max(0, this.ClientSize.Width - btnClose.Width - margin);
            int y = Math.Max(0, margin);
            btnClose.Location = new Point(x, y);

            btnClose.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTabRequested?.Invoke(this, EventArgs.Empty);
        }

        public void AddProductToCart(ProductSuggestion product)
        {
            foreach (DataGridViewRow row in dvgOrder.Rows)
            {
                if (row.Cells["colBarcode"].Value != null && row.Cells["colBarcode"].Value.ToString() == product.ProductId.ToString())
                {
                    int currentQty = Convert.ToInt32(row.Cells["colQuantity"].Value);
                    row.Cells["colQuantity"].Value = currentQty + 1;
                    decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                    row.Cells["colTotal"].Value = price * (currentQty + 1);
                    UpdateTotalMoney();
                    return;
                }
            }

            int stt = dvgOrder.Rows.Count + 1;
            dvgOrder.Rows.Add(
                stt,
                product.ProductId,
                product.Name,
                "Cái",
                null,
                1,
                null,
                product.Price.ToString("N0"),
                product.Price.ToString("N0"),
                null
            );
            UpdateTotalMoney();
        }

        private void dvgOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dvgOrder.Columns[e.ColumnIndex].Name == "colMinus")
            {
                var row = dvgOrder.Rows[e.RowIndex];
                int qty = Convert.ToInt32(row.Cells["colQuantity"].Value);
                if (qty > 1)
                {
                    qty--;
                    row.Cells["colQuantity"].Value = qty;
                    decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                    row.Cells["colTotal"].Value = price * qty;
                    UpdateTotalMoney();
                }
            }
            else if (dvgOrder.Columns[e.ColumnIndex].Name == "colPlus")
            {
                var row = dvgOrder.Rows[e.RowIndex];
                int qty = Convert.ToInt32(row.Cells["colQuantity"].Value);
                qty++;
                row.Cells["colQuantity"].Value = qty;
                decimal price = Convert.ToDecimal(row.Cells["colPrice"].Value);
                row.Cells["colTotal"].Value = price * qty;
                UpdateTotalMoney();
            }
            else if (dvgOrder.Columns[e.ColumnIndex].Name == "colDelete")
            {
                dvgOrder.Rows.RemoveAt(e.RowIndex);
                for (int i = 0; i < dvgOrder.Rows.Count; i++)
                {
                    dvgOrder.Rows[i].Cells["colSTT"].Value = i + 1;
                }
                UpdateTotalMoney();
            }
        }

        private void UpdateTotalMoney()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dvgOrder.Rows)
            {
                if (row.Cells["colTotal"].Value != null && decimal.TryParse(row.Cells["colTotal"].Value.ToString(), out decimal value))
                {
                    total += value;
                }
            }

            TotalMoneyChanged?.Invoke(total);
        }

        public List<OrderRow> GetOrderRows()
        {
            var list = new List<OrderRow>();
            foreach (DataGridViewRow row in dvgOrder.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["colBarcode"].Value != null)
                {
                    list.Add(new OrderRow
                    {
                        ProductId = Convert.ToInt32(row.Cells["colBarcode"].Value),
                        ProductName = row.Cells["colProductName"].Value?.ToString(),
                        Quantity = Convert.ToInt32(row.Cells["colQuantity"].Value),
                        Price = Convert.ToDecimal(row.Cells["colPrice"].Value)
                    });
                }
            }
            return list;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }
    }
}
