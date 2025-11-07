using System;
using QLPhongTro.ChildForm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace QLPhongTro.ChildForm
{
    public partial class frmlogin : Form
    {
        SqlConnection sqlcon = null;
        public frmlogin()
        {
            InitializeComponent();
        }

       

        
        private void frmlogin_Load(object sender, EventArgs e)
        {

        }

      

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmSignUp frmSignUp = new frmSignUp();
            frmSignUp.ShowDialog();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuenMatKhau frmForgotPw = new QuenMatKhau();
            frmForgotPw.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(@"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=MilkStoreManagement;Integrated Security=True");
            }
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            string tk = txtTk.Text.Trim();
            string mk = txtMK.Text.Trim();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT username, password FROM Users WHERE username = @username AND password = @password";
            sqlcmd.Parameters.AddWithValue("@username", tk);
            sqlcmd.Parameters.AddWithValue("@password", mk);
            sqlcmd.Connection = sqlcon;
            SqlDataReader data = sqlcmd.ExecuteReader();
            if (data.Read())
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
            data.Close();
        }
    }
}
