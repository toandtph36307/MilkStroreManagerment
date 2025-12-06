using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QLPhongTro.FunctionForms.OverViewForm.Models;
using System.Configuration;

namespace QLPhongTro.FunctionForms.OverViewForm._Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly string _conn;

        public CustomerRepository(string connectionString = null)
        {
            _conn = !string.IsNullOrEmpty(connectionString)
                ? connectionString
                : ConfigurationManager.ConnectionStrings["SqlConnection"]?.ConnectionString
                    ?? @"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True";
        }

        public void Add(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(_conn))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Customers (full_name, email, phone, address, status) VALUES (@full_name, @email, @phone, @address, @statusCus)";
                    command.Parameters.Add("@full_name", SqlDbType.NVarChar).Value = customerModel.Full_name ?? string.Empty;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = (object)customerModel.Email ?? DBNull.Value;
                    command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = (object)customerModel.Phone ?? DBNull.Value;
                    command.Parameters.Add("@address", SqlDbType.NVarChar).Value = (object)customerModel.Address ?? DBNull.Value;
                    command.Parameters.Add("@statusCus", SqlDbType.NVarChar, 10).Value = string.IsNullOrEmpty(customerModel.Status) ? "Active" : customerModel.Status;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_conn))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Customers WHERE customer_id = @customer_id";
                    command.Parameters.Add("@customer_id", SqlDbType.Int).Value = id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(_conn))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "UPDATE Customers SET full_name = @full_name, email = @email, phone = @phone, address = @address, status = @statusCus WHERE customer_id = @customer_id";
                    command.Parameters.Add("@full_name", SqlDbType.NVarChar).Value = customerModel.Full_name ?? string.Empty;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = (object)customerModel.Email ?? DBNull.Value;
                    command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = (object)customerModel.Phone ?? DBNull.Value;
                    command.Parameters.Add("@address", SqlDbType.NVarChar).Value = (object)customerModel.Address ?? DBNull.Value;
                    command.Parameters.Add("@statusCus", SqlDbType.NVarChar, 10).Value = string.IsNullOrEmpty(customerModel.Status) ? "Active" : customerModel.Status;
                    command.Parameters.Add("@customer_id", SqlDbType.Int).Value = customerModel.Customer_id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            var customerList = new List<CustomerModel>();
            using (var connection = new SqlConnection(_conn))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT customer_id, full_name, email, phone, address, statusCus FROM Customers order by customer_id desc;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        var customerModel = new CustomerModel(); 
                        customerModel.Customer_id = reader.GetInt32(reader.GetOrdinal("customer_id"));
                        customerModel.Full_name = reader["full_name"] as string;
                        customerModel.Email = reader["email"] as string;
                        customerModel.Phone = reader["phone"] as string;
                        customerModel.Address = reader["address"] as string;
                        customerModel.Status = reader["statusCus"] as string;
                        customerList.Add(customerModel);
                    }
                }
            }
            return customerList;
        }

        public IEnumerable<CustomerModel> GetByValue(string value)
        {
            var customerList = new List<CustomerModel>();
            int Customer_id = int.TryParse(value, out _)? Convert.ToInt32(value) : 0;
            string Full_name = value;
            using (var connection = new SqlConnection(_conn))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT customer_id, full_name, email, phone, address, statusCus FROM Customers "
                        + "WHERE customer_id = @customer_id OR full_name LIKE @full_name + '%' "
                        + "ORDER BY customer_id DESC;";
                command.Parameters.Add("@customer_id", SqlDbType.Int).Value = Customer_id;
                command.Parameters.Add("@full_name", SqlDbType.NVarChar).Value = Full_name;  


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        var customerModel = new CustomerModel(); 
                        customerModel.Customer_id = reader.GetInt32(reader.GetOrdinal("customer_id"));
                        customerModel.Full_name = reader["full_name"] as string;
                        customerModel.Email = reader["email"] as string;
                        customerModel.Phone = reader["phone"] as string;
                        customerModel.Address = reader["address"] as string;
                        customerModel.Status = reader["statusCus"] as string; 
                        customerList.Add(customerModel);
                    }
                }
            }
            return customerList;
        }
    }
}
