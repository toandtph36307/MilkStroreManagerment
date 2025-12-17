using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLPhongTro.FunctionForms.salesForm.Models;

namespace QLPhongTro.FunctionForms.salesForm.Data
{
    public class OrderRepository
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
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Orders (customer_id, user_id, total_price, order_date, status, created_at, discount_id)
                    OUTPUT INSERTED.order_id
                    VALUES (@customer_id, @user_id, @total_price, @order_date, @status, @created_at, @discount_id)", conn))
                {
                    cmd.Parameters.Add("@customer_id", SqlDbType.Int).Value = customerId;
                    cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = userId;
                    cmd.Parameters.Add("@total_price", SqlDbType.Decimal).Value = totalPrice;
                    cmd.Parameters.Add("@order_date", SqlDbType.DateTime).Value = orderDate;
                    cmd.Parameters.Add("@status", SqlDbType.NVarChar, 20).Value = status ?? string.Empty;
                    cmd.Parameters.Add("@created_at", SqlDbType.DateTime).Value = DateTime.Now;
                    if (discountId.HasValue)
                        cmd.Parameters.Add("@discount_id", SqlDbType.Int).Value = discountId.Value;
                    else
                        cmd.Parameters.Add("@discount_id", SqlDbType.Int).Value = DBNull.Value;

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void InsertOrderDetail(int orderId, int productId, decimal price, int quantity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
            INSERT INTO Order_Details (order_id, product_id, price, quantity)
            VALUES (@order_id, @product_id, @price, @quantity)", conn))
                {
                    cmd.Parameters.Add("@order_id", SqlDbType.Int).Value = orderId;
                    cmd.Parameters.Add("@product_id", SqlDbType.Int).Value = productId;
                    cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertPayment(int orderId, string paymentMethod, DateTime paymentDate, decimal amountPaid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Payments (order_id, payment_method, payment_date, amount_paid)
                    VALUES (@order_id, @payment_method, @payment_date, @amount_paid)", conn))
                {
                    cmd.Parameters.Add("@order_id", SqlDbType.Int).Value = orderId;
                    cmd.Parameters.Add("@payment_method", SqlDbType.NVarChar, 50).Value = paymentMethod ?? string.Empty;
                    cmd.Parameters.Add("@payment_date", SqlDbType.DateTime).Value = paymentDate;
                    cmd.Parameters.Add("@amount_paid", SqlDbType.Decimal).Value = amountPaid;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddOrUpdateCustomerDebt(int customerId, decimal amountToAdd, string note = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (var updateCmd = new SqlCommand(@"
                            UPDATE CustomerDebts
                            SET balance = balance + @change, last_updated = GETDATE()
                            WHERE customer_id = @customer_id", conn, tran))
                        {
                            updateCmd.Parameters.Add("@change", SqlDbType.Decimal).Value = amountToAdd;
                            updateCmd.Parameters.Add("@customer_id", SqlDbType.Int).Value = customerId;
                            int rows = updateCmd.ExecuteNonQuery();
                            if (rows == 0)
                            {
                                using (var insertCmd = new SqlCommand(@"
                                    INSERT INTO CustomerDebts (customer_id, balance, last_updated)
                                    VALUES (@customer_id, @balance, GETDATE())", conn, tran))
                                {
                                    insertCmd.Parameters.Add("@customer_id", SqlDbType.Int).Value = customerId;
                                    insertCmd.Parameters.Add("@balance", SqlDbType.Decimal).Value = amountToAdd;
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        using (var histCmd = new SqlCommand(@"
                            INSERT INTO CustomerDebtHistory (customer_id, change_amount, note, created_at)
                            VALUES (@customer_id, @change, @note, GETDATE())", conn, tran))
                        {
                            histCmd.Parameters.Add("@customer_id", SqlDbType.Int).Value = customerId;
                            histCmd.Parameters.Add("@change", SqlDbType.Decimal).Value = amountToAdd;
                            histCmd.Parameters.Add("@note", SqlDbType.NVarChar, 500).Value = (object)note ?? DBNull.Value;
                            histCmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}