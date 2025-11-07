using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPhongTro.FunctionForms.OverViewForm.Models;
using QLPhongTro.FunctionForms.OverViewForm.DAL;
using QLPhongTro.FunctionForms.OverViewForm.DB;

namespace QLPhongTro.FunctionForms.OverViewForm.DAL
{
    public class DashboardService
    {
        private readonly string _connectionString = "Data Source=DANGTHETOAN\\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True";

        public DashboardService()
        {
            _connectionString = "Data Source=DANGTHETOAN\\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True";
        }

        public List<TopProductDto> GetTop5BestSellingProducts(DateTime startDate, DateTime endDate)
        {
            var result = new List<TopProductDto>();
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT TOP 5 
                        p.product_id, 
                        p.name, 
                        SUM(od.quantity) AS TotalSold
                    FROM Order_Details od
                    INNER JOIN Products p ON od.product_id = p.product_id
                    INNER JOIN Orders o ON od.order_id = o.order_id
                    WHERE o.order_date >= @startDate AND o.order_date < @endDate
                    GROUP BY p.product_id, p.name
                    ORDER BY TotalSold DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new TopProductDto
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                TotalSold = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            return result;
        }

        public decimal GetGrossRevenue(DateTime startDate, DateTime endDate)
        {
            decimal total = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT ISNULL(SUM(total_price), 0)
                    FROM Orders
                    WHERE order_date >= @startDate AND order_date < @endDate
                          AND status = 'completed'";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        total = Convert.ToDecimal(result);
                }
            }
            return total;
        }

        public List<RevenueByTimeDto> GetGrossRevenueByTime(DateTime startDate, DateTime endDate, string timeType)
        {
            var result = new List<RevenueByTimeDto>();
            using (var conn = new SqlConnection(_connectionString))
            {
                string groupBy, selectTime;
                if (timeType == "hour")
                {
                    groupBy = "DATEPART(HOUR, order_date)";
                    selectTime = "RIGHT('0' + CAST(DATEPART(HOUR, order_date) AS VARCHAR), 2) + ':00'";
                }
                else // "day"
                {
                    groupBy = "CONVERT(date, order_date)";
                    selectTime = "CONVERT(varchar(10), CONVERT(date, order_date), 120)";
                }

                string query = $@"
                    SELECT {selectTime} AS TimeLabel, ISNULL(SUM(total_price), 0) AS Revenue
                    FROM Orders
                    WHERE order_date >= @startDate AND order_date < @endDate AND status = 'completed'
                    GROUP BY {groupBy}
                    ORDER BY {groupBy}";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new RevenueByTimeDto
                            {
                                TimeLabel = reader.GetString(0),
                                Revenue = reader.GetDecimal(1)
                            });
                        }
                    }
                }
            }
            return result;
        }

        public List<UnderstockProductDto> GetUnderstockProducts(int threshold = 10)
        {
            var result = new List<UnderstockProductDto>();
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT p.product_id, p.name, p.quantity, c.name AS category
                    FROM Products p
                    INNER JOIN Categories c ON p.category_id = c.category_id
                    WHERE p.quantity < @threshold
                    ORDER BY p.quantity ASC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@threshold", threshold);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new UnderstockProductDto
                            {
                                ProductId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                Category = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return result;
        }

        public int GetOrderCount(DateTime startDate, DateTime endDate)
        {
            int count = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT COUNT(*)
                    FROM Orders
                    WHERE order_date >= @startDate AND order_date < @endDate";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    count = (int)cmd.ExecuteScalar();
                }
            }
            return count;
        }

        public int GetCustomerCount(DateTime startDate, DateTime endDate)
        {
            int count = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT COUNT(DISTINCT customer_id)
                    FROM Orders
                    WHERE order_date >= @startDate AND order_date < @endDate";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    count = (int)cmd.ExecuteScalar();
                }
            }
            return count;
        }

        public int GetTotalProductsSold(DateTime startDate, DateTime endDate)
        {
            int total = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT ISNULL(SUM(od.quantity), 0)
                    FROM Order_Details od
                    INNER JOIN Orders o ON od.order_id = o.order_id
                    WHERE o.order_date >= @startDate AND o.order_date < @endDate";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        total = Convert.ToInt32(result);
                }
            }
            return total;
        }

        public int GetNumSuppliersSold(DateTime startDate, DateTime endDate)
        {
            int count = 0;
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT COUNT(DISTINCT p.supplier_id)
                    FROM Order_Details od
                    INNER JOIN Orders o ON od.order_id = o.order_id
                    INNER JOIN Products p ON od.product_id = p.product_id
                    WHERE o.order_date >= @startDate AND o.order_date < @endDate";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                        count = Convert.ToInt32(result);
                }
            }
            return count;
        }
    }
}
