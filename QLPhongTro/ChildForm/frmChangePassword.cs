using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLPhongTro.ChildForm
{
    public partial class frmChangePassword : Form
    {
        private readonly string userEmail;
        private readonly bool isResetFlow;
        SqlConnection sqlcon = null;

        public frmChangePassword()
        {
            InitializeComponent();
            userEmail = string.Empty;
            isResetFlow = false;
        }


        public frmChangePassword(string email)
        {
            InitializeComponent();
            userEmail = email;
            isResetFlow = !string.IsNullOrEmpty(email);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (isResetFlow)
            {
                try
                {
                    panel3.Visible = false;
                }
                catch
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPW.Text?.Trim() ?? string.Empty;
            string confirm = txtConfirmPW.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(@"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=QLPhongTro;Integrated Security=True");
            }
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }

            if (!isResetFlow)
            {
                
                string oldPasswordInput = txtOldPW.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(oldPasswordInput))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu cũ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (var checkCmd = new SqlCommand("SELECT MatKhau FROM tblQuanLy WHERE Email = @Email", sqlcon))
                {
                    checkCmd.Parameters.AddWithValue("@Email", userEmail);
                    object dbPass = checkCmd.ExecuteScalar();
                    string currentPassword = dbPass?.ToString() ?? string.Empty;
                    if (currentPassword != oldPasswordInput)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            
            string targetEmail = isResetFlow ? userEmail : userEmail;
            if (string.IsNullOrEmpty(targetEmail))
            {
                
                MessageBox.Show("Không có email mục tiêu để cập nhật mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var updateCmd = new SqlCommand("UPDATE tblQuanLy SET MatKhau = @NewPassword WHERE Email = @Email", sqlcon))
            {
                updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                updateCmd.Parameters.AddWithValue("@Email", targetEmail);
                int rows = updateCmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật mật khẩu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
