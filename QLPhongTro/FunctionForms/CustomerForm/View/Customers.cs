using QLPhongTro.FunctionForms.OverViewForm.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QLPhongTro.FunctionForms.CustomerForm._Repositories;
using QLPhongTro.FunctionForms.CustomerForm.Models;

namespace QLPhongTro.ChildForm
{
    public partial class Customers : Form , ICustomerView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public Customers()
        {
            InitializeComponent();
            
            try { txtCustomerId.ReadOnly = true; }
            catch { }

            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageCustomerDetail);

            LoadCustomerGroupsDetail();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            btnAddNew.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageCustomerList);
                tabControl1.TabPages.Add(tabPageCustomerDetail);
                tabPageCustomerDetail.Text = "Add new Customers";
            };

            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageCustomerList);
                tabControl1.TabPages.Add(tabPageCustomerDetail);
                tabPageCustomerDetail.Text = "Edit Customers";
            };

            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPageCustomerDetail);
                    tabControl1.TabPages.Add(tabPageCustomerList);
                }
                MessageBox.Show(Message);
            };

            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageCustomerDetail);
                tabControl1.TabPages.Add(tabPageCustomerList);
            };

            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected Customer?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }


        private void LoadCustomerGroupsDetail()
        {
            try
            {
                var repo = new CustomerGroupRepository();
                var groups = repo.GetAll().ToList();

                var items = new List<object>();
                items.Add(new { GroupId = 0, Name = "(None)" });
                foreach (var g in groups)
                {
                    items.Add(new { GroupId = g.GroupId, Name = g.Name });
                }

                if (cbbCusGrDetail != null)
                {
                    cbbCusGrDetail.DisplayMember = "Name";
                    cbbCusGrDetail.ValueMember = "GroupId";
                    cbbCusGrDetail.DataSource = items;
                    cbbCusGrDetail.SelectedValue = 0;

                    cbbCusGrDetail.SelectedIndexChanged -= Cbb_SelectedIndexChanged_RaiseGroupFilter;
                    cbbCusGrDetail.SelectedIndexChanged += Cbb_SelectedIndexChanged_RaiseGroupFilter;
                }
                if (cbbCusGrFilter != null)
                {
                    cbbCusGrFilter.SelectedIndexChanged -= Cbb_SelectedIndexChanged_RaiseGroupFilter;
                    cbbCusGrFilter.SelectedIndexChanged += Cbb_SelectedIndexChanged_RaiseGroupFilter;
                }
            }
            catch
            {
            }
        }

        
        private void Cbb_SelectedIndexChanged_RaiseGroupFilter(object sender, EventArgs e)
        {
            GroupFilterEvent?.Invoke(this, EventArgs.Empty);
        }

        public string customer_id 
        {
            get { return txtCustomerId.Text; }
            set { txtCustomerId.Text = value; }
        }
        public string full_name 
        {
            get { return txtCustomerName.Text; }
            set { txtCustomerName.Text = value; }
        }
        public string email 
        {
            get { return txtCustomerMail.Text; }
            set { txtCustomerMail.Text = value; }
        }
        public string phone 
        {
            get { return txtCustomerPhone.Text; }
            set { txtCustomerPhone.Text = value; }
        }
        public string address 
        {
            get { return txtCustomerAddress.Text; }
            set { txtCustomerAddress.Text = value; }
        }


        public string status
        {
            get
            {
                try
                {
                    if (cmbStatus.SelectedItem != null)
                        return cmbStatus.SelectedItem.ToString();
                    if (!string.IsNullOrEmpty(cmbStatus.Text))
                        return cmbStatus.Text;
                }
                catch { }
                return "Active";
            }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value)) value = "Active";
                    cmbStatus.SelectedItem = value;
                }
                catch { }
            }
        }


        public string SelectedGroupId
        {
            get
            {
                try
                {
                    if (cbbCusGrDetail == null) return "0";
                    var val = cbbCusGrDetail.SelectedValue;
                    return val == null ? "0" : val.ToString();
                }
                catch { return "0"; }
            }
            set
            {
                try
                {
                    if (cbbCusGrDetail == null) return;
                    if (string.IsNullOrEmpty(value)) value = "0";
                    int v;
                    if (int.TryParse(value, out v))
                        cbbCusGrDetail.SelectedValue = v;
                }
                catch { }
            }
        }

        public string SearchValue 
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit 
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful 
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }
        public string Message 
        {
            get { return message; }
            set { message = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public event EventHandler GroupFilterEvent;

        public void SetCustomerListBindingSource(BindingSource CustomerList)
        {
            dataGridView.DataSource = CustomerList;
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPageCustomerDetail_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
