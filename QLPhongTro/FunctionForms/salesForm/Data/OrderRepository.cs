using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLPhongTro.FunctionForms.salesForm.Models;

namespace QLPhongTro.FunctionForms.salesForm.Data
{
    public class    OrderRepository
    {
        private readonly string _connectionString;
        public OrderRepository(string connectionString = @"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True")
        {
            _connectionString = connectionString;
        }

        

        public int InsertOrder(int customerId, int userId, decimal totalPrice, DateTime orderDate, string status, int? discountId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Orders (customer_id, user_id, total_price, order_date, status, created_at, discount_id)
                    OUTPUT INSERTED.order_id
                    VALUES (@customer_id, @user_id, @total_price, @order_date, @status, @created_at, @discount_id)", conn);

                cmd.Parameters.AddWithValue("@customer_id", customerId);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@total_price", totalPrice);
                cmd.Parameters.AddWithValue("@order_date", orderDate);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@created_at", DateTime.Now);
                if (discountId.HasValue)
                    cmd.Parameters.AddWithValue("@discount_id", discountId.Value);
                else
                    cmd.Parameters.AddWithValue("@discount_id", DBNull.Value);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void InsertOrderDetail(int orderId, int productId, decimal price, int quantity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            INSERT INTO Order_Details (order_id, product_id, price, quantity)
            VALUES (@order_id, @product_id, @price, @quantity)", conn);

                cmd.Parameters.AddWithValue("@order_id", orderId);
                cmd.Parameters.AddWithValue("@product_id", productId);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertPayment(int orderId, string paymentMethod, DateTime paymentDate, decimal amountPaid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Payments (order_id, payment_method, payment_date, amount_paid)
                    VALUES (@order_id, @payment_method, @payment_date, @amount_paid)", conn);

                cmd.Parameters.AddWithValue("@order_id", orderId);
                cmd.Parameters.AddWithValue("@payment_method", paymentMethod);
                cmd.Parameters.AddWithValue("@payment_date", paymentDate);
                cmd.Parameters.AddWithValue("@amount_paid", amountPaid);

                cmd.ExecuteNonQuery();
            }
        }
    }
}