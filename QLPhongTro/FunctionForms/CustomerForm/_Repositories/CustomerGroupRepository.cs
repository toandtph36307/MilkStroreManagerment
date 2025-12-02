using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using QLPhongTro.FunctionForms.CustomerForm.Models;

namespace QLPhongTro.FunctionForms.CustomerForm._Repositories
{
    public class CustomerGroupRepository : ICustomerGroupRepository
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

        public void Add(CustomerGroupModel model)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CustomerGroups ([name], [description], created_at) VALUES (@name, @description, @created_at)";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = model.Name ?? string.Empty;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = (object)model.Description ?? DBNull.Value;
                cmd.Parameters.Add("@created_at", SqlDbType.DateTime).Value = model.CreatedAt == DateTime.MinValue ? DateTime.Now : model.CreatedAt;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(CustomerGroupModel model)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CustomerGroups SET [name] = @name, [description] = @description WHERE group_id = @group_id";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = model.Name ?? string.Empty;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = (object)model.Description ?? DBNull.Value;
                cmd.Parameters.Add("@group_id", SqlDbType.Int).Value = model.GroupId;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM CustomerGroups WHERE group_id = @group_id";
                cmd.Parameters.Add("@group_id", SqlDbType.Int).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
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
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new CustomerGroupModel
                        {
                            GroupId = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                            Name = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                            Description = rdr.IsDBNull(2) ? null : rdr.GetString(2),
                            CreatedAt = rdr.IsDBNull(3) ? DateTime.MinValue : rdr.GetDateTime(3)
                        });
                    }
                }
            }
            return list;
        }

        public IEnumerable<CustomerGroupModel> GetByValue(string value)
        {
            var list = new List<CustomerGroupModel>();
            int id = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT group_id, [name], [description], created_at FROM CustomerGroups WHERE group_id = @id OR [name] LIKE @name + '%' ORDER BY group_id DESC";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = value ?? string.Empty;

                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new CustomerGroupModel
                        {
                            GroupId = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                            Name = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                            Description = rdr.IsDBNull(2) ? null : rdr.GetString(2),
                            CreatedAt = rdr.IsDBNull(3) ? DateTime.MinValue : rdr.GetDateTime(3)
                        });
                    }
                }
            }
            return list;
        }
    }
}