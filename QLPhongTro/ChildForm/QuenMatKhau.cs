using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QLPhongTro.ChildForm
{
    public partial class QuenMatKhau : Form
    {
        SqlConnection sqlcon = null;
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtmail.Text.Trim();
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            bool isValidEmail = Regex.IsMatch(email, pattern);
            if (!isValidEmail)
            {
                MessageBox.Show("Định dạng email không hợp lệ. Vui lòng nhập một địa chỉ email hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT * FROM tblQuanLy WHERE Email = @email";
            sqlcmd.Parameters.AddWithValue("@email", email);
            sqlcmd.Connection = sqlcon;
            SqlDataReader data = sqlcmd.ExecuteReader();

            if (data.Read())
            {

                
                data.Close();

                //// string tempPassword = "Temp1234";
                //// SqlCommand updateCmd = new SqlCommand();
                //// updateCmd.CommandType = CommandType.Text;
                //// updateCmd.CommandText = "UPDATE tblQuanLy SET MatKhau = @TempPassword WHERE email = @Email";
                //// updateCmd.Parameters.AddWithValue("@TempPassword", tempPassword);
                //// updateCmd.Parameters.AddWithValue("@Email", email);
                //// updateCmd.Connection = sqlcon;
                //// updateCmd.ExecuteNonQuery();

                //// try
                //// {
                ////     MailMessage mail = new MailMessage("toanyt0108@gmail.com", email);
                ////     SmtpClient client = new SmtpClient();
                ////     client.Port = 587;
                ////     client.DeliveryMethod = SmtpDeliveryMethod.Network;
                ////     client.UseDefaultCredentials = false;
                ////     client.Host = "smtp.example.com";
                ////     mail.Subject = "Đặt lại mật khẩu";
                ////     mail.Body = "Mật khẩu tạm thời của bạn là: " + tempPassword;
                ////     client.Send(mail);
                ////     MessageBox.Show("Một mật khẩu tạm thời đã được gửi đến email của bạn.");
                //// }
                //// catch (Exception ex)
                //// {
                ////     MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
                //// }

                try
                {
                    this.Hide();
                    using (var changeForm = new frmChangePassword(email))
                    {
                        changeForm.ShowDialog();
                    }
                    this.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chuyển sang form đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Email không được tìm thấy.");
            }
            if (data != null && !data.IsClosed)
            {
                data.Close();
            }
        }
        private void QuenMatKhau_Load(object sender, EventArgs e)
        {
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmlogin frmlogin = new frmlogin();
            frmlogin.ShowDialog();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
