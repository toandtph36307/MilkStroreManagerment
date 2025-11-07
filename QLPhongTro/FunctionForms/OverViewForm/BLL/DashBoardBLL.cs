using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPhongTro.FunctionForms.OverViewForm.DAL;
using QLPhongTro.FunctionForms.OverViewForm.Models;

namespace QLPhongTro.FunctionForms.OverViewForm.BLL
{
    internal class DashBoardBLL
    {
        private readonly DashboardService _dashboardService;

        public DashBoardBLL()
        {
            _dashboardService = new DashboardService();
        }

        public List<TopProductDto> GetTop5BestSellingProducts(DateTime startDate, DateTime endDate)
        {
            return _dashboardService.GetTop5BestSellingProducts(startDate, endDate);
        }

        public decimal GetGrossRevenue(DateTime startDate, DateTime endDate)
        {
            return _dashboardService.GetGrossRevenue(startDate, endDate);
        }

        public List<RevenueByTimeDto> GetGrossRevenueByTime(DateTime startDate, DateTime endDate, string timeType)
        {
            return _dashboardService.GetGrossRevenueByTime(startDate, endDate, timeType);
        }

        public List<UnderstockProductDto> GetUnderstockProducts(int threshold = 10)
        {
            return _dashboardService.GetUnderstockProducts(threshold);
        }

        public int GetOrderCount(DateTime startDate, DateTime endDate)
        {
            return _dashboardService.GetOrderCount(startDate, endDate);
        }

        public int GetCustomerCount(DateTime startDate, DateTime endDate)
        {
            return _dashboardService.GetCustomerCount(startDate, endDate);
        }

        public int GetTotalProductsSold(DateTime startDate, DateTime endDate)
        {
            return _dashboardService.GetTotalProductsSold(startDate, endDate);
        }

        public int GetNumSuppliersSold(DateTime startDate, DateTime endDate)
        {
            return _dashboardService.GetNumSuppliersSold(startDate, endDate);
        }
    }
}
