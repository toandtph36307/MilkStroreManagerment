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
        private string userEmail;
        SqlConnection sqlcon = null;
        public frmChangePassword()
        {
            
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sqlcon == null) {
                sqlcon = new SqlConnection(@"Data Source=DANGTHETOAN\TOANDT11;Initial Catalog=QLPhongTro;Integrated Security=True");
            }
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            

        }
    }
}
