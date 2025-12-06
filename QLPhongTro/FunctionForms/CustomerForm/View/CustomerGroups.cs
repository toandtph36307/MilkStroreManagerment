using System;
using System.ComponentModel;
using System.Windows.Forms;
using QLPhongTro.FunctionForms.CustomerForm._Repositories;
using QLPhongTro.FunctionForms.CustomerForm.Presenters;

namespace QLPhongTro.FunctionForms.CustomerForm.View
{
    public partial class CustomerGroups : Form, ICustomerGroupView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public CustomerGroups()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            try
            {
                tabControl1.TabPages.Remove(tabPageGroupDetail);
            }
            catch { }

            var repository = new CustomerGroupRepository();
            new CustomerGroupPresenter(this, repository);
        }

        private void AssociateAndRaiseViewEvents()
        {
            // Search
            try
            {
                btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            }
            catch { }
            try
            {
                txtSearch.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                        SearchEvent?.Invoke(this, EventArgs.Empty);
                };
            }
            catch { }

            // Add new
            try
            {
                btnAddNew.Click += delegate
                {
                    AddNewEvent?.Invoke(this, EventArgs.Empty);
                    tabControl1.TabPages.Remove(tabPageGroupList);
                    tabControl1.TabPages.Add(tabPageGroupDetail);
                    tabPageGroupDetail.Text = "Add new group";
                };
            }
            catch { }

            // Edit
            try
            {
                btnEdit.Click += delegate
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    tabControl1.TabPages.Remove(tabPageGroupList);
                    tabControl1.TabPages.Add(tabPageGroupDetail);
                    tabPageGroupDetail.Text = "Edit group";
                };
            }
            catch { }

            // Save
            try
            {
                btnSave.Click += delegate
                {
                    SaveEvent?.Invoke(this, EventArgs.Empty);
                    if (isSuccessful)
                    {
                        tabControl1.TabPages.Remove(tabPageGroupDetail);
                        tabControl1.TabPages.Add(tabPageGroupList);
                    }
                    MessageBox.Show(Message);
                };
            }
            catch { }

            // Cancel
            try
            {
                btnCancel.Click += delegate
                {
                    CancelEvent?.Invoke(this, EventArgs.Empty);
                    tabControl1.TabPages.Remove(tabPageGroupDetail);
                    tabControl1.TabPages.Add(tabPageGroupList);
                };
            }
            catch { }

            // Delete
            try
            {
                btnDelete.Click += delegate
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected group?", "Warning",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DeleteEvent?.Invoke(this, EventArgs.Empty);
                        MessageBox.Show(Message);
                    }
                };
            }
            catch { }
        }

        public string group_id
        {
            get
            {
                try { return txtGroupId.Text; } catch { return string.Empty; }
            }
            set
            {
                try { txtGroupId.Text = value; } catch { }
            }
        }

        public string name
        {
            get
            {
                try { return txtGroupName.Text; } catch { return string.Empty; }
            }
            set
            {
                try { txtGroupName.Text = value; } catch { }
            }
        }

        public string description
        {
            get
            {
                try { return txtGroupDescription.Text; } catch { return string.Empty; }
            }
            set
            {
                try { txtGroupDescription.Text = value; } catch { }
            }
        }

        public string SearchValue
        {
            get
            {
                try { return txtSearch.Text; } catch { return string.Empty; }
            }
            set
            {
                try { txtSearch.Text = value; } catch { }
            }
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

        public void SetGroupListBindingSource(BindingSource groupList)
        {
            try
            {
                dvgCustomerGroups.DataSource = groupList;
            }
            catch
            {
                try { dvgCustomerGroups.DataSource = groupList; } catch { }
            }
        }

        private void CustomerGroups_Load(object sender, EventArgs e) { }
        private void tabPageGroupDetail_Click(object sender, EventArgs e) { }
        private void dvgCustomerGroups_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
