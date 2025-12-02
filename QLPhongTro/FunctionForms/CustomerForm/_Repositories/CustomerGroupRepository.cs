csharp FunctionForms\CustomerForm\_Repositories\CustomerGroupRepository.cs
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using QLPhongTro.FunctionForms.CustomerForm.Models;

namespace QLPhongTro.FunctionForms.CustomerForm._Repositories
{
    public class CustomerGroupRepository
    {
        private readonly string _connectionString;

        public CustomerGroupRepository(string connectionString = null)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                _connectionString = connectionString;
                return;
            }

            var cs = ConfigurationManager.ConnectionStrings["SqlConnection"]?.ConnectionString;
            _connectionString = !string.IsNullOrEmpty(cs)
                ? cs
                : @"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True";
        }

        public IEnumerable<CustomerGroupModel> GetAll()
        {
            var list = new List<CustomerGroupModel>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT group_id, [name], [description], created_at FROM CustomerGroups ORDER BY group_id DESC";
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var g = new CustomerGroupModel
                        {
                            GroupId = r.IsDBNull(0) ? 0 : r.GetInt32(0),
                            Name = r.IsDBNull(1) ? null : r.GetString(1),
                            Description = r.IsDBNull(2) ? null : r.GetString(2),
                            CreatedAt = r.IsDBNull(3) ? DateTime.MinValue : r.GetDateTime(3)
                        };
                        list.Add(g);
                    }
                }
            }
            return list;
        }

        public int Insert(CustomerGroupModel model)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CustomerGroups ([name], [description], created_at) VALUES (@name, @description, @created_at); SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@description", (object)model.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@created_at", model.CreatedAt == DateTime.MinValue ? (object)DateTime.Now : model.CreatedAt);

                conn.Open();
                var scalar = cmd.ExecuteScalar();
                return Convert.ToInt32(scalar);
            }
        }
    }
}