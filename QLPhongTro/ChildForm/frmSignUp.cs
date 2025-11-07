using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlTypes;


namespace QLPhongTro.ChildForm
{
    public partial class frmSignUp : Form
    {
        SqlConnection sqlcon = null;
        public frmSignUp()
        {
            InitializeComponent();
        }

        private void frmSignUp_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmlogin frmlogin = new frmlogin();
            frmlogin.ShowDialog();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            
            string tk = txtTk.Text.Trim();
            string mk = txtMK.Text.Trim();
            string mail = txtMail.Text.Trim();
            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk) || string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(mail, emailPattern))
            {
                MessageBox.Show("Định dạng email không hợp lệ. Vui lòng nhập một địa chỉ email hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tk) || tk.Length < 6 || !tk.Any(char.IsUpper))
            {
                MessageBox.Show("Tài khoản phải có ít nhất 6 ký tự, có ít nhất 1 chữ in hoa.");
                return;
            }


            if (string.IsNullOrEmpty(mk) || mk.Length < 8 || !mk.Any(char.IsUpper) || !mk.Any(char.IsDigit) || !mk.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự, có ít nhất 1 chữ in hoa, 1 số và 1 ký tự đặc biệt.");
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

            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tblQuanLy WHERE TaiKhoan = @username OR email = @email", sqlcon);
            checkCmd.Parameters.AddWithValue("@username", tk);
            checkCmd.Parameters.AddWithValue("@email", mail);
            int existingUserCount = (int)checkCmd.ExecuteScalar();

            if (existingUserCount > 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc email đã tồn tại. Vui lòng chọn tên đăng nhập hoặc email khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand insertCmd = new SqlCommand("INSERT INTO tblQuanLy (TaiKhoan, MatKhau, email) VALUES (@username, @password, @email)", sqlcon);
            insertCmd.Parameters.AddWithValue("@username", tk);
            insertCmd.Parameters.AddWithValue("@password", mk);
            insertCmd.Parameters.AddWithValue("@email", mail);


            int rowsAffected = insertCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Đăng ký thành công!");
                this.Hide();
                frmlogin Login = new frmlogin();
                Login.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Đăng ký thất bại.");
            }

            sqlcon.Close();
        }
    }
}
