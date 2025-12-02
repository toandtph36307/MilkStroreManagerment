using QLPhongTro.FunctionForms.CustomerForm.View;
using QLPhongTro.FunctionForms.salesForm.Business;
using QLPhongTro.FunctionForms.salesForm.Data;
using QLPhongTro.FunctionForms.salesForm.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongTro.FunctionForms.salesForm.View
{
    public partial class Sales : Form
    {
        private string connectionString = @"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True";
        private DataTable cartTable = new DataTable();
        private int hoveredIndex = -1;
        private int hoveredCustomerIndex = -1;
        private OrderService _orderService;
        private int? _selectedCustomerId = null;
        private System.Collections.Generic.Dictionary<TabPage, PanelThanhToanState> panelStates = new System.Collections.Generic.Dictionary<TabPage, PanelThanhToanState>();
        private int _lastSelectedTabIndex = 0;
        private bool _isAutoUpdatingCusPay = false;
        private bool _isAutoUpdatingDiscount = false;

        public Sales()
        {
            InitializeComponent();
            lstProductSuggestion.Visible = false;
            lstProductSuggestion.BringToFront();

            lstProductSuggestion.DrawMode = DrawMode.OwnerDrawFixed;
            lstProductSuggestion.DrawItem += lstProductSuggestion_DrawItem;
            lstProductSuggestion.MouseMove += lstProductSuggestion_MouseMove;
            lstProductSuggestion.MouseLeave += lstProductSuggestion_MouseLeave;

            lstCustomerSuggestion.DrawMode = DrawMode.OwnerDrawFixed;
            lstCustomerSuggestion.DrawItem += lstCustomerSuggestion_DrawItem;
            lstCustomerSuggestion.MouseMove += lstCustomerSuggestion_MouseMove;
            lstCustomerSuggestion.MouseLeave += lstCustomerSuggestion_MouseLeave;

            tabControlOrders.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlOrders.SelectedIndexChanged += tabControlOrders_SelectedIndexChanged;
            AddNewOrderTab();

            var orderRepo = new OrderRepository(connectionString);
            _orderService = new OrderService(orderRepo);
        }

        #region listProductSuggestion
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchProduct.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var suggestions = GetProductSuggestions(searchText);
                if (suggestions.Any())
                {
                    lstProductSuggestion.DataSource = suggestions;
                    lstProductSuggestion.DisplayMember = null;

                    ShowProductSuggestion();

                    int itemCount = suggestions.Length;
                    int itemHeight = lstProductSuggestion.ItemHeight;
                    int borderHeight = SystemInformation.BorderSize.Height * 4;
                    int desiredHeight = (itemHeight * itemCount) + borderHeight;
                    lstProductSuggestion.Height = Math.Min(desiredHeight, 676);
                    return;
                }
            }

            lstProductSuggestion.Visible = false;
        }

        private void lstProductSuggestion_Leave(object sender, EventArgs e)
        {
            lstProductSuggestion.Visible = false;
        }

        private void lstProductSuggestion_Click(object sender, EventArgs e)
        {
            lstProductSuggestion.Visible = false;
            if (lstProductSuggestion.SelectedItem is ProductSuggestion selectedProduct)
            {
                var currentTab = tabControlOrders.SelectedTab;
                if (currentTab != null && currentTab.Controls.Count > 0)
                {
                    var orderContent = currentTab.Controls[0] as OderContent;
                    if (orderContent != null)
                    {
                        orderContent.AddProductToCart(selectedProduct);
                    }
                }
            }
            txtSearchProduct.Clear();
        }

        private ProductSuggestion[] GetProductSuggestions(string searchText)
        {
            var list = new System.Collections.Generic.List<ProductSuggestion>();
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP 20 product_id, name, price, quantity
                    FROM Products
                    WHERE LOWER(name) LIKE @search OR CAST(product_id AS VARCHAR) LIKE @search
                    ORDER BY name";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductSuggestion
                            {
                                ProductId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Quantity = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return list.ToArray();
        }

        private void lstProductSuggestion_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            bool isHovered = (e.Index == hoveredIndex);
            var font = isHovered ? new System.Drawing.Font(e.Font, System.Drawing.FontStyle.Bold) : e.Font;
            var brush = System.Drawing.SystemBrushes.ControlText;

            e.DrawBackground();
            e.Graphics.DrawString(lstProductSuggestion.Items[e.Index].ToString(), font, brush, e.Bounds);

            e.DrawFocusRectangle();
        }

        private void lstProductSuggestion_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lstProductSuggestion.IndexFromPoint(e.Location);
            if (index != hoveredIndex)
            {
                hoveredIndex = index;
                lstProductSuggestion.Invalidate();
            }
        }

        private void lstProductSuggestion_MouseLeave(object sender, EventArgs e)
        {
            hoveredIndex = -1;
            lstProductSuggestion.Invalidate();
        }

        #endregion

        #region lstCussomerSuggestion
        private void txtCustomersSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtCustomersSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var suggestions = GetCustomerSuggestions(searchText);
                if (suggestions.Any())
                {
                    lstCustomerSuggestion.DataSource = suggestions;
                    lstCustomerSuggestion.DisplayMember = null;

                    ShowCustomerSuggestion();

                    int itemCount = suggestions.Length;
                    int itemHeight = lstCustomerSuggestion.ItemHeight;
                    int borderHeight = SystemInformation.BorderSize.Height * 4;
                    int desiredHeight = (itemHeight * itemCount) + borderHeight;
                    lstCustomerSuggestion.Height = Math.Min(desiredHeight, 400);
                    return;
                }
            }

            lstCustomerSuggestion.Visible = false;
        }

        private CustomerSuggestion[] GetCustomerSuggestions(string searchText)
        {
            var list = new System.Collections.Generic.List<CustomerSuggestion>();
            using (var conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TOP 20 customer_id, full_name, phone, email
                    FROM Customers
                    WHERE LOWER(full_name) LIKE @search OR phone LIKE @search OR email LIKE @search
                    ORDER BY full_name";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new CustomerSuggestion
                            {
                                CustomerId = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                Phone = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Email = reader.IsDBNull(3) ? "" : reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return list.ToArray();
        }

        private void lstCustomerSuggestion_Leave(object sender, EventArgs e)
        {
            lstCustomerSuggestion.Visible = false;
        }

        private void lstCustomerSuggestion_Click(object sender, EventArgs e)
        {
            lstCustomerSuggestion.Visible = false;
            if (lstCustomerSuggestion.SelectedItem is CustomerSuggestion selectedCustomer)
            {
                lblCustomers.Text = selectedCustomer.FullName;
                _selectedCustomerId = selectedCustomer.CustomerId;
            }
            txtCustomersSearch.Clear();
        }

        private void lstCustomerSuggestion_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            bool isHovered = (e.Index == hoveredCustomerIndex);
            var font = isHovered ? new System.Drawing.Font(e.Font, System.Drawing.FontStyle.Bold) : e.Font;
            var brush = System.Drawing.SystemBrushes.ControlText;

            e.DrawBackground();
            e.Graphics.DrawString(lstCustomerSuggestion.Items[e.Index].ToString(), font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void lstCustomerSuggestion_MouseMove(object sender, MouseEventArgs e)
        {
            int index = lstCustomerSuggestion.IndexFromPoint(e.Location);
            if (index != hoveredCustomerIndex)
            {
                hoveredCustomerIndex = index;
                lstCustomerSuggestion.Invalidate();
            }
        }

        private void lstCustomerSuggestion_MouseLeave(object sender, EventArgs e)
        {
            hoveredCustomerIndex = -1;
            lstCustomerSuggestion.Invalidate();
        }
        #endregion

        #region addOrderTab
        private void AddNewOrderTab()
        {
            var tabPage = new TabPage("Order " + (tabControlOrders.TabCount + 1));
            var orderContent = new OderContent
            {
                Dock = DockStyle.Fill
            };


            orderContent.TotalMoneyChanged += (total) =>
            {
                lblTotalMoney.Text = total.ToString("N0") + " VND";
                UpdateTotalAfterDiscount();
            };

            orderContent.CloseTabRequested += (s, e) =>
            {
                if (tabControlOrders.TabCount > 1)
                {
                    tabControlOrders.TabPages.Remove(tabPage);
                    tabPage.Dispose();
                }
                else
                {
                    MessageBox.Show("Cannot close the last order tab.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            tabPage.Controls.Add(orderContent);
            tabControlOrders.TabPages.Add(tabPage);
            tabControlOrders.SelectedTab = tabPage;

            ResetPanelThanhToan();
            panelStates[tabPage] = GetPanelThanhToanState();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            AddNewOrderTab();
        }

        private void ResetPanelThanhToan()
        {
            lblTotalMoney.Text = "0 VND";
            txtDiscount.Text = "0";
            txtCusPay.Text = "0";
            lblCashChange.Text = "0 VND";
            lblCustomers.Text = "Khách lẻ";
            _selectedCustomerId = null;
            UpdateTotalAfterDiscount();
        }
        #endregion

        private void Sales_Load(object sender, EventArgs e)
        {
            lstProductSuggestion.BringToFront();
        }

        private void TS_Discount_CheckedChanged(object sender, EventArgs e)
        {
            lblVND.Visible = !TS_Discount.Checked;
            lblPercent.Visible = TS_Discount.Checked;
            UpdateTotalAfterDiscount();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (_isAutoUpdatingDiscount) return;

            int selectionStart = txtDiscount.SelectionStart;
            int selectionLength = txtDiscount.SelectionLength;

            string raw = new string(txtDiscount.Text.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(raw))
            {
                txtDiscount.Text = "";
                UpdateTotalAfterDiscount();
                return;
            }

            decimal value = decimal.Parse(raw);
            string formatted = value.ToString("N0");

            if (txtDiscount.Text != formatted)
            {
                _isAutoUpdatingDiscount = true;
                txtDiscount.Text = formatted;

                int diff = txtDiscount.Text.Length - raw.Length;
                txtDiscount.SelectionStart = Math.Max(0, selectionStart + diff);
                txtDiscount.SelectionLength = selectionLength;
                _isAutoUpdatingDiscount = false;
            }

            UpdateTotalAfterDiscount();
        }

        private void UpdateTotalAfterDiscount()
        {
            decimal total = 0;
            decimal.TryParse(lblTotalMoney.Text.Replace("VND", "").Replace(",", "").Trim(), out total);

            decimal discount = 0;
            decimal.TryParse(txtDiscount.Text.Replace(",", "").Trim(), out discount);

            decimal finalTotal = total;

            if (discount > 0)
            {
                if (TS_Discount.Checked)
                {
                    if (discount > 100) discount = 100;
                    finalTotal = total - (total * discount / 100);
                }
                else
                {
                    if (discount > total) discount = total;
                    finalTotal = total - discount;
                }
            }

            lblTotalAfterDiscount.Text = finalTotal.ToString("N0") + " VND";

            _isAutoUpdatingCusPay = true;
            txtCusPay.Text = finalTotal.ToString("N0");
            _isAutoUpdatingCusPay = false;

            txtCusPay_TextChanged(null, null);
        }

        private void txtCusPay_TextChanged(object sender, EventArgs e)
        {
            if (_isAutoUpdatingCusPay) return;


            int selectionStart = txtCusPay.SelectionStart;
            int selectionLength = txtCusPay.SelectionLength;

            string raw = new string(txtCusPay.Text.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(raw))
            {
                txtCusPay.Text = "";
                lblCashChange.Text = "0 VND";
                return;
            }

            decimal value = decimal.Parse(raw);
            string formatted = value.ToString("N0");

            if (txtCusPay.Text != formatted)
            {
                _isAutoUpdatingCusPay = true;
                txtCusPay.Text = formatted;

                int diff = txtCusPay.Text.Length - raw.Length;
                txtCusPay.SelectionStart = Math.Max(0, selectionStart + diff);
                txtCusPay.SelectionLength = selectionLength;
                _isAutoUpdatingCusPay = false;
            }

            decimal cusPay = value;
            decimal totalAfterDiscount = 0;
            decimal.TryParse(lblTotalAfterDiscount.Text.Replace("VND", "").Replace(",", "").Trim(), out totalAfterDiscount);

            decimal change = cusPay - totalAfterDiscount;
            if (change < 0) change = 0;

            lblCashChange.Text = change.ToString("N0") + " VND";
        }

        private void btnPayPrinter_Click(object sender, EventArgs e)
        {
            var currentTab = tabControlOrders.SelectedTab;
            if (currentTab != null && currentTab.Controls.Count > 0)
            {
                var orderContent = currentTab.Controls[0] as OderContent;
                if (orderContent != null)
                {
                    var orderRows = orderContent.GetOrderRows();
                    if (orderRows.Count == 0)
                    {
                        MessageBox.Show("Chưa có sản phẩm trong giỏ hàng!");
                        return;
                    }

                    if (_selectedCustomerId == null)
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng!");
                        return;
                    }

                    int userId = 1;
                    int? discountId = null;

                    decimal totalPrice = 0;
                    decimal.TryParse(lblTotalAfterDiscount.Text.Replace("VND", "").Replace(",", "").Trim(), out totalPrice);

                    string paymentMethod = "cash";
                    decimal amountPaid = 0;
                    decimal.TryParse(txtCusPay.Text.Replace(",", "").Trim(), out amountPaid);

                    string status = "completed";

                    int orderId = _orderService.CreateOrder(
                        customerId: _selectedCustomerId.Value,
                        userId: userId,
                        totalPrice: totalPrice,
                        orderDate: DateTime.Now,
                        status: status,
                        discountId: discountId,
                        orderRows: orderRows,
                        paymentMethod: paymentMethod,
                        amountPaid: amountPaid
                    );

                    MessageBox.Show($"Tạo hóa đơn thành công! Mã hóa đơn: {orderId}");
                }
            }
        }

        private void tabControlOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControlOrders.TabCount > 0 && _lastSelectedTabIndex >= 0 && _lastSelectedTabIndex < tabControlOrders.TabCount)
            {
                var prevTab = tabControlOrders.TabPages[_lastSelectedTabIndex];
                panelStates[prevTab] = GetPanelThanhToanState();
            }

            var currentTab = tabControlOrders.SelectedTab;
            if (currentTab != null && panelStates.ContainsKey(currentTab))
            {
                SetPanelThanhToanState(panelStates[currentTab]);
            }
            else
            {
                ResetPanelThanhToan();
            }

            _lastSelectedTabIndex = tabControlOrders.SelectedIndex;
        }

        private PanelThanhToanState GetPanelThanhToanState()
        {
            return new PanelThanhToanState
            {
                TotalMoney = lblTotalMoney.Text,
                Discount = txtDiscount.Text,
                TotalAfterDiscount = lblTotalAfterDiscount.Text,
                CusPay = txtCusPay.Text,
                CashChange = lblCashChange.Text,
                Customers = lblCustomers.Text,
                SelectedCustomerId = _selectedCustomerId
            };
        }

        private void SetPanelThanhToanState(PanelThanhToanState state)
        {
            lblTotalMoney.Text = state.TotalMoney;
            txtDiscount.Text = state.Discount;
            txtCusPay.Text = state.CusPay;
            lblCashChange.Text = state.CashChange;
            lblCustomers.Text = state.Customers;
            _selectedCustomerId = state.SelectedCustomerId;
            UpdateTotalAfterDiscount();
        }

        private void tabControlOrders_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowProductSuggestion()
        {
            if (lstProductSuggestion.Parent != this)
            {
                var prev = lstProductSuggestion.Parent;
                prev?.Controls.Remove(lstProductSuggestion);
                this.Controls.Add(lstProductSuggestion);
            }

            var screenPoint = txtSearchProduct.PointToScreen(new System.Drawing.Point(0, txtSearchProduct.Height));
            var clientPoint = this.PointToClient(screenPoint);
            lstProductSuggestion.Location = new System.Drawing.Point(clientPoint.X, clientPoint.Y);

            lstProductSuggestion.Width = txtSearchProduct.Width;

            lstProductSuggestion.BringToFront();
            lstProductSuggestion.Visible = true;
        }

        private void ShowCustomerSuggestion()
        {
            if (lstCustomerSuggestion.Parent != this)
            {
                var prev = lstCustomerSuggestion.Parent;
                prev?.Controls.Remove(lstCustomerSuggestion);
                this.Controls.Add(lstCustomerSuggestion);
            }

            var screenPoint = txtCustomersSearch.PointToScreen(new System.Drawing.Point(0, txtCustomersSearch.Height));
            var clientPoint = this.PointToClient(screenPoint);
            lstCustomerSuggestion.Location = new System.Drawing.Point(clientPoint.X, clientPoint.Y);
            lstCustomerSuggestion.Width = txtCustomersSearch.Width;

            lstCustomerSuggestion.BringToFront();
            lstCustomerSuggestion.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}





