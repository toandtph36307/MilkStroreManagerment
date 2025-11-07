using System.Reflection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLPhongTro.FunctionForms.OverViewForm.BLL;
using QLPhongTro.FunctionForms.OverViewForm.Models;

namespace QLPhongTro.FunctionForms.OverViewForm.Views
{
    public partial class Overview : Form
    {
        private readonly DashBoardBLL _dashboardBLL;
        SqlConnection sqlcon = null;

        public Overview()
        {
            InitializeComponent();
            _dashboardBLL = new DashBoardBLL();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;

            LoadData();
        }

        private void LoadData()
        {
            
        }

        private void Overview_Load(object sender, EventArgs e)
        {
            LoadTopProductsChart();
            LoadGrossRevenueChart();
            LoadUnderstockProducts();
            UpdateTotalRevenueLabel();
            UpdateCompareLabel();
            UpdateNumOrdersLabel();
            UpdateNumCustomersLabel();
            UpdateNumProductsLabel();
            UpdateNumSuppliersLabel();
        }

        private void LoadTopProductsChart()
        {
            GetTimeRange(out DateTime startDate, out DateTime endDate);
            var topProducts = _dashboardBLL.GetTop5BestSellingProducts(startDate, endDate);

            

            var series = chartTopProducts.Series[0];
            series.Points.Clear();

            foreach (var product in topProducts)
            {
                series.Points.AddXY(product.ProductName, product.TotalSold);
            }

            series.IsValueShownAsLabel = true;
        }

        private void LoadGrossRevenueChart()
        {
            GetTimeRange(out DateTime startDate, out DateTime endDate);
            string selected = cbbTimeLine.SelectedItem?.ToString() ?? "Today";
            string timeType = (selected == "Today" || selected == "Yesterday") ? "hour" : "day";

            var revenueList = _dashboardBLL.GetGrossRevenueByTime(startDate, endDate, timeType);


            Dictionary<string, decimal> revenueMap = new Dictionary<string, decimal>();
            foreach (var item in revenueList)
                revenueMap[item.TimeLabel] = item.Revenue;

            List<string> labels = new List<string>();

            if (timeType == "hour")
            {
                for (int h = 0; h < 24; h++)
                {
                    string label = h.ToString("D2") + ":00";
                    labels.Add(label);
                }
            }
            else
            {
                for (DateTime d = startDate; d < endDate; d = d.AddDays(1))
                {
                    string label = d.ToString("yyyy-MM-dd");
                    labels.Add(label);
                }
            }

            

            var series = chartGrossRevenue.Series[0];
            series.Points.Clear();

            foreach (var label in labels)
            {
                decimal value = revenueMap.ContainsKey(label) ? revenueMap[label] : 0;
                string displayLabel = label;
                if (timeType == "day" && (selected == "This Week" || selected == "Last Week"))
                {
                    DateTime d = DateTime.Parse(label);
                    string[] weekDays = { "Chủ nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };
                    displayLabel = weekDays[(int)d.DayOfWeek];
                }
                else if (timeType == "day")
                {
                    DateTime d = DateTime.Parse(label);
                    displayLabel = d.ToString("dd_MM");
                }
                series.Points.AddXY(displayLabel, value);
            }
            series.IsValueShownAsLabel = false;
        }

        private void LoadUnderstockProducts()
        {
            var understockProducts = _dashboardBLL.GetUnderstockProducts(200);
            dgvUnderstock.DataSource = understockProducts;
        }

        private void GetTimeRange(out DateTime startDate, out DateTime endDate)
        {
            string selected = cbbTimeLine.SelectedItem?.ToString() ?? "Today";
            DateTime today = DateTime.Today;
            switch (selected)
            {
                case "Today":
                    startDate = today;
                    endDate = today.AddDays(1);
                    break;
                case "Yesterday":
                    startDate = today.AddDays(-1);
                    endDate = today;
                    break;
                case "This Week":
                    int diffThisWeek = (int)today.DayOfWeek;
                    startDate = today.AddDays(-diffThisWeek);
                    endDate = startDate.AddDays(7);
                    break;
                case "Last Week":
                    int diffLastWeek = (int)today.DayOfWeek;
                    startDate = today.AddDays(-diffLastWeek - 7);
                    endDate = startDate.AddDays(7);
                    break;
                case "This Month":
                    startDate = new DateTime(today.Year, today.Month, 1);
                    endDate = startDate.AddMonths(1);
                    break;
                case "Last Month":
                    startDate = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
                    endDate = startDate.AddMonths(1);
                    break;
                default:
                    startDate = today;
                    endDate = today.AddDays(1);
                    break;
            }
        }

        private void UpdateDateRangeByTimeLine()
        {
            if (cbbTimeLine.SelectedItem == null) return;
            string selected = cbbTimeLine.SelectedItem.ToString();
            DateTime today = DateTime.Today;

            switch (selected)
            {
                case "Today":
                    dtpStartDate.Value = today;
                    dtpEndDate.Value = today.AddDays(1).AddSeconds(-1);
                    break;
                case "Yesterday":
                    dtpStartDate.Value = today.AddDays(-1);
                    dtpEndDate.Value = today.AddSeconds(-1);
                    break;
                case "This Week":
                    int diffThisWeek = (int)today.DayOfWeek;
                    DateTime thisWeekStart = today.AddDays(-diffThisWeek);
                    DateTime thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
                    dtpStartDate.Value = thisWeekStart;
                    dtpEndDate.Value = thisWeekEnd;
                    break;
                case "Last Week":
                    int diffLastWeek = (int)today.DayOfWeek;
                    DateTime lastWeekStart = today.AddDays(-diffLastWeek - 7);
                    DateTime lastWeekEnd = lastWeekStart.AddDays(7).AddSeconds(-1);
                    dtpStartDate.Value = lastWeekStart;
                    dtpEndDate.Value = lastWeekEnd;
                    break;
                case "This Month":
                    DateTime monthStart = new DateTime(today.Year, today.Month, 1);
                    DateTime monthEnd = monthStart.AddMonths(1).AddSeconds(-1);
                    dtpStartDate.Value = monthStart;
                    dtpEndDate.Value = monthEnd;
                    break;
                case "Last Month":
                    DateTime lastMonthStart = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
                    DateTime lastMonthEnd = lastMonthStart.AddMonths(1).AddSeconds(-1);
                    dtpStartDate.Value = lastMonthStart;
                    dtpEndDate.Value = lastMonthEnd;
                    break;
                default:
                    dtpStartDate.Value = today;
                    dtpEndDate.Value = today.AddDays(1).AddSeconds(-1);
                    break;
            }
        }

        private void UpdateTotalRevenueLabel()
        {
            GetTimeRange(out DateTime startDate, out DateTime endDate);
            decimal totalRevenue = _dashboardBLL.GetGrossRevenue(startDate, endDate);
            lblTotalRevenue.Text = totalRevenue.ToString("N0") + " VNĐ";
        }

        private void UpdateCompareLabel()
        {
            GetTimeRange(out DateTime startDate, out DateTime endDate);

            TimeSpan range = endDate - startDate;
            DateTime prevStart = startDate - range;
            DateTime prevEnd = startDate;

            decimal currentRevenue = _dashboardBLL.GetGrossRevenue(startDate, endDate);
            decimal prevRevenue = _dashboardBLL.GetGrossRevenue(prevStart, prevEnd);

            if (prevRevenue == 0 && currentRevenue == 0)
            {
                lblCompare.Text = "No revenue for both days.";
                lblCompare.ForeColor = System.Drawing.Color.Gray;
                return;
            }

            if (prevRevenue == 0)
            {
                lblCompare.Text = "Increase 100% ";
                lblCompare.ForeColor = System.Drawing.Color.Green;
                return;
            }

            decimal percent = ((currentRevenue - prevRevenue) / prevRevenue) * 100;
            if (percent > 0)
            {
                lblCompare.Text = $"Increase {percent:N1}% ";
                lblCompare.ForeColor = System.Drawing.Color.Green;
            }
            else if (percent < 0)
            {
                lblCompare.Text = $"{Math.Abs(percent):N1}% Off";
                lblCompare.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblCompare.Text = "No change in revenue";
                lblCompare.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void UpdateNumOrdersLabel()
        {
            GetTimeRange(out DateTime startDate, out DateTime endDate);
            int numOrders = _dashboardBLL.GetOrderCount(startDate, endDate);
            lblNumOrders.Text = numOrders.ToString("N0");
        }
        private void UpdateNumCustomersLabel()
        {
            GetTimeRange(out DateTime startDate, out DateTime endDate);
            int numCustomers = _dashboardBLL.GetCustomerCount(startDate, endDate);
            lblNumCustomers.Text = numCustomers.ToString("N0");
        }

        private void UpdateNumProductsLabel()
        {
            GetTimeRange(out DateTime startDate, out DateTime endDate);
            int numProducts = _dashboardBLL.GetTotalProductsSold(startDate, endDate);
            lblNumProducts.Text = numProducts.ToString("N0");
        }

        private void UpdateNumSuppliersLabel()
        {
            GetTimeRange(out DateTime startDate, out DateTime endDate);
            int numSuppliers = _dashboardBLL.GetNumSuppliersSold(startDate, endDate);
            lblNumSuppliers.Text = numSuppliers.ToString("N0");
        }

        private void cbbTimeLine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadGrossRevenueChart();
            UpdateDateRangeByTimeLine();
            LoadTopProductsChart();
            UpdateTotalRevenueLabel();
            UpdateNumOrdersLabel();
            UpdateNumCustomersLabel(); 
            UpdateNumProductsLabel();
            UpdateNumSuppliersLabel();
        }

        private void chartTopProducts_Click(object sender, EventArgs e)
        {

        }
    }
}
