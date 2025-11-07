using QLPhongTro.ChildForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using QLPhongTro.FunctionForms.OverViewForm.View;
using QLPhongTro.FunctionForms.OverViewForm.Models;
using QLPhongTro.FunctionForms.OverViewForm.Presenters;
using QLPhongTro.FunctionForms.OverViewForm._Repositories;


namespace QLPhongTro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }
        public bool menuExpand = false;
       

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }



        // select1
        private void selectDrowdown_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                dropdown.Height += 10;
                if (dropdown.Height >= dropdown.MaximumSize.Height)
                {
                    selectDrowdown.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                dropdown.Height -= 10;
                if (dropdown.Height <= dropdown.MinimumSize.Height)
                {
                    selectDrowdown.Stop();
                    menuExpand = false;
                }
            }
        }
        private void Select_Click(object sender, EventArgs e)
        {
            selectDrowdown.Start();
        }



        //Category2
        private void CategoryDrowdown_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                Category.Height += 10;
                if (Category.Height >= Category.MaximumSize.Height)
                {
                    CategoryDrowdown.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                Category.Height -= 10;
                if (Category.Height <= Category.MinimumSize.Height)
                {
                    CategoryDrowdown.Stop();
                    menuExpand = false;
                }
            }
        }
        private void Caregory_Click(object sender, EventArgs e)
        {
            CategoryDrowdown.Start();
        }
        private void Category_Paint(object sender, PaintEventArgs e)
        {

        }


        //Information3
        private void Information_Click(object sender, EventArgs e)
        {
            InformationDropdown.Start();
        }
        private void InformationDropdown_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                InformationGroup.Height += 10;
                if (InformationGroup.Height >= InformationGroup.MaximumSize.Height)
                {
                    InformationDropdown.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                InformationGroup.Height -= 10;
                if (InformationGroup.Height <= InformationGroup.MinimumSize.Height)
                {
                    InformationDropdown.Stop();
                    menuExpand = false;
                }
            }
        }
        private void InformationGroup_click(object sender, EventArgs e)
        {
            
        }



        //statistis4
        private void StatisticsGroup_Click(object sender, EventArgs e)
        {

        }
        private void StatisticDrowndown_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                StatisticsGroup.Height += 10;
                if (StatisticsGroup.Height >= StatisticsGroup.MaximumSize.Height)
                {
                    StatisticDrowndown.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                StatisticsGroup.Height -= 10;
                if (StatisticsGroup.Height <= StatisticsGroup.MinimumSize.Height)
                {
                    StatisticDrowndown.Stop();
                    menuExpand = false;
                }
            }
        }
        private void Statistics_click(object sender, EventArgs e)
        {
            StatisticDrowndown.Start();
        }





        //Task5
        private void TaskDrowndown_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                TaskGroup.Height += 10;
                if (TaskGroup.Height >= TaskGroup .MaximumSize.Height)
                {
                    TaskDrowndown.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                TaskGroup .Height -= 10;
                if (TaskGroup.Height <= TaskGroup.MinimumSize.Height)
                {
                    TaskDrowndown.Stop();
                    menuExpand = false;
                }
            }
        }
       


        private void WarehouseGroup_Click(object sender, EventArgs e)
        {

        }

        private void WarehouseDrown_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                WarehouseGroup .Height += 10;
                if (WarehouseGroup .Height >= WarehouseGroup.MaximumSize.Height)
                {
                    WarehouseDrown.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                WarehouseGroup.Height -= 10;
                if (WarehouseGroup.Height <= WarehouseGroup.MinimumSize.Height)
                {
                    WarehouseDrown.Stop();
                    menuExpand = false;
                }
            }
        }       
        private void Warehouse_Click(object sender, EventArgs e)
        {
            WarehouseDrown.Start();
        }


        private void VendorDrowndown_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                VendorGroup.Height += 10;
                if (VendorGroup.Height >= VendorGroup.MaximumSize.Height)
                {
                    VendorDrowndown.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                VendorGroup.Height -= 10;
                if (VendorGroup.Height <= VendorGroup.MinimumSize.Height)
                {
                    VendorDrowndown.Stop();
                    menuExpand = false;
                }
            }
        }
        private void Vendor_Click(object sender, EventArgs e)
        {
            VendorDrowndown.Start();
        }

        #region gui
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        private void AddForm(Form f)
        {
            this.grbContent.Controls.Clear();//xóa các control hiện có trên groupbox
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;//bỏ viền của form
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.grbContent.Controls.Add(f);
            f.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var f = new frmWelcome();
            AddForm(f);
        }


        //Controlmain
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
               
            }
        }

        private void btnMin_click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //System
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword();
            changePassword.Show();
        }

        // Khóa màn hình
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWorkStation();
        private void LockScreen_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        private void Settings_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Service_Click(object sender, EventArgs e)
        {
            var f = new FunctionForms.salesForm.View.SalesOrders();
            AddForm(f);
        }

        private void RentedRoom_Click(object sender, EventArgs e)
        {
            
        }

        private void VacantRoom_Click(object sender, EventArgs e)
        {
           
        }

        private void Revenue_Click(object sender, EventArgs e)
        {
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

       

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                btnState.Image = Properties.Resources.minimize__3_;

            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnState.Image = Properties.Resources.minimize__4_;
            }
        }

        private void Minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Overview_click(object sender, EventArgs e)
        {

            var f = new FunctionForms.OverViewForm.Views.Overview();
            AddForm(f);
        }

        private void Customers_Click(object sender, EventArgs e)
        {
             string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            ICustomerView view = new Customers();
            ICustomerRepository repository = new CustomerRepository(sqlConnectionString);
            new CustomerPresenter(view,repository);
            
            AddForm((Form)view);
        }

        private void CustomerList_Click(object sender, EventArgs e)
        {
            TaskDrowndown.Start();
        }

        private void PosSales_Click(object sender, EventArgs e)
        {
            var f = new FunctionForms.salesForm.View.Sales();
            AddForm(f);
        }
    }
}
