using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QLPhongTro.FunctionForms.OverViewForm.Models;


namespace QLPhongTro.FunctionForms.OverViewForm._Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {

        public CustomerRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }



        public void Add(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(@"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True"))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Customers (full_name, email, phone, address) VALUES (@full_name, @email, @phone, @address)";
                    command.Parameters.Add("@full_name", SqlDbType.VarChar).Value = customerModel.Full_name;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = customerModel.Email;
                    command.Parameters.Add("@phone", SqlDbType.VarChar).Value = customerModel.Phone;
                    command.Parameters.Add("@address", SqlDbType.Text ).Value = customerModel.Address;
                    command.ExecuteNonQuery();
                }
            }
            
        }

        public void Delete(int id)
        {
            
                using (var connection = new SqlConnection(@"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True"))
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
            using (var connection = new SqlConnection(@"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True"))
            {
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "UPDATE Customers SET full_name = @full_name, email = @email, phone = @phone, address = @address WHERE customer_id = @customer_id";
                    command.Parameters.Add("@full_name", SqlDbType.VarChar).Value = customerModel.Full_name;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = customerModel.Email;
                    command.Parameters.Add("@phone", SqlDbType.VarChar).Value = customerModel.Phone;
                    command.Parameters.Add("@address", SqlDbType.Text).Value = customerModel.Address;
                    command.Parameters.Add("@customer_id", SqlDbType.Int).Value = customerModel.Customer_id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            var customerList = new List<CustomerModel>();
            using (var connection = new SqlConnection(@"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Customers order by customer_id desc;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        var customerModel = new CustomerModel(); 
                        customerModel.Customer_id = (int)reader[0];
                        customerModel.Full_name = reader[1].ToString();
                        customerModel.Email = reader[2].ToString();
                        customerModel.Phone = reader[3].ToString();
                        customerModel.Address = reader[4].ToString();
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
            using (var connection = new SqlConnection(@"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Customers "
                        + "WHERE customer_id = @customer_id OR full_name LIKE @full_name + '%' "
                        + "ORDER BY customer_id DESC;";
                command.Parameters.Add("@customer_id", SqlDbType.Int).Value = Customer_id;
                command.Parameters.Add("@full_name", SqlDbType.VarChar).Value = Full_name;  


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        var customerModel = new CustomerModel(); 
                        customerModel.Customer_id = (int)reader[0];
                        customerModel.Full_name = reader[1].ToString();
                        customerModel.Email = reader[2].ToString();
                        customerModel.Phone = reader[3].ToString();
                        customerModel.Address = reader[4].ToString();
                        customerList.Add(customerModel);
                    }
                }
            }
            return customerList;
        }
    }
}
