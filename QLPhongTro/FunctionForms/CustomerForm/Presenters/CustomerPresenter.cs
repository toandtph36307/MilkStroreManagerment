using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLPhongTro.FunctionForms.CustomerForm.Presenters.Common;
using QLPhongTro.FunctionForms.OverViewForm.View;
using QLPhongTro.FunctionForms.OverViewForm.Models;
using System.Windows.Forms;

namespace QLPhongTro.FunctionForms.CustomerForm.Presenters
{
    public class CustomerPresenter
    {
        private ICustomerView view;
        private ICustomerRepository repository;
        private BindingSource customersBindingSource;
        private IEnumerable<CustomerModel> customerList;

        public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
        {
            this.customersBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += SearchCustomer;
            this.view.AddNewEvent += AddCustomer;
            this.view.EditEvent += LoadSelectCustomerToEdit;
            this.view.DeleteEvent += DeleteSelectCustomer;
            this.view.SaveEvent += SaveCustomer;
            this.view.CancelEvent += CancelAction;


            this.view.GroupFilterEvent += FilterByGroupOrStatus;

            this.view.SetCustomerListBindingSource(customersBindingSource);

            LoadAllCustomerPetList();

            this.view.Show();
        }

        private void LoadAllCustomerPetList()
        {
            customerList = repository.GetAll();
            customersBindingSource.DataSource = customerList;
        }

        private void SearchCustomer(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                customerList = repository.GetByValue(this.view.SearchValue);
            else customerList = repository.GetAll();
            customersBindingSource.DataSource = customerList;
        }


        private void FilterByGroupOrStatus(object sender, EventArgs e)
        {
            try
            {
                var list = repository.GetAll().ToList();

                int groupId = 0;
                if (int.TryParse(view.SelectedGroupId, out var gid))
                    groupId = gid;

                var statusFilter = (view.SelectedStatusFilter ?? "All").Trim();

                if (groupId > 0)
                    list = list.Where(c => c.GroupId.HasValue && c.GroupId.Value == groupId).ToList();

                if (!string.IsNullOrEmpty(statusFilter) && !statusFilter.Equals("All", StringComparison.OrdinalIgnoreCase))
                    list = list.Where(c => string.Equals(c.Status ?? string.Empty, statusFilter, StringComparison.OrdinalIgnoreCase)).ToList();

                customersBindingSource.DataSource = list;
            }
            catch
            {
                LoadAllCustomerPetList();
            }
        }

        private void CleanviewFields()
        {
            view.customer_id = ""; 
            view.full_name = "";
            view.email = "";
            view.phone = "";
            view.address = "";
            try { view.status = "Active"; } catch { }
            try { view.SelectedGroupId = "0"; } catch { }
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void LoadAllPetList()
        {
            customerList = repository.GetAll();
            customersBindingSource.DataSource = customerList;//Set data source.
        }

        private void SaveCustomer(object sender, EventArgs e)
        {
            var model = new CustomerModel();
            model.Customer_id = string.IsNullOrWhiteSpace(view.customer_id) ? 0 : Convert.ToInt32(view.customer_id);
            model.Full_name = view.full_name;
            model.Email = view.email;
            model.Phone = view.phone;
            model.Address = view.address;

            model.Status = string.IsNullOrEmpty(view.status) ? "Active" : view.status;

            
            int gid;
            if (int.TryParse(view.SelectedGroupId, out gid))
                model.GroupId = gid == 0 ? (int?)null : gid;
            else
                model.GroupId = null;

            try
            {
                new ModelDataValidation().Validate(model);
                if (view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "Pet edited successfuly";
                }
                else //Add new model
                {
                    int newId = repository.Add(model);
                    view.customer_id = newId.ToString();
                    view.Message = "Pet added sucessfully";
                }
                view.IsSuccessful = true;
                LoadAllPetList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void DeleteSelectCustomer(object sender, EventArgs e)
        {
            try
            {
                var customer = (CustomerModel)customersBindingSource.Current;
                repository.Delete(customer.Customer_id);
                view.IsSuccessful = true;
                view.Message = "Customer deleted successfully";
                LoadAllPetList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not delete customer" + ex.Message;
            }
        }

        private void LoadSelectCustomerToEdit(object sender, EventArgs e)
        {
            var customer = (CustomerModel)customersBindingSource.Current;
            view.customer_id = customer.Customer_id.ToString();
            view.full_name = customer.Full_name;
            view.email = customer.Email;
            view.phone = customer.Phone;
            view.address = customer.Address;
            view.status = customer.Status; // map status to view

            // map group to view
            view.SelectedGroupId = customer.GroupId.HasValue ? customer.GroupId.Value.ToString() : "0";

            view.IsEdit = true;
        }

        private void AddCustomer(object sender, EventArgs e)
        {
            view.IsEdit = false;
            CleanviewFields(); 
        }
    }
}
