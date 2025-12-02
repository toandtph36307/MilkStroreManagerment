
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLPhongTro.FunctionForms.CustomerForm.Models;
using QLPhongTro.FunctionForms.CustomerForm._Repositories;
using QLPhongTro.FunctionForms.CustomerForm.View;

namespace QLPhongTro.FunctionForms.CustomerForm.Presenters
{
    public class CustomerGroupPresenter
    {
        private readonly ICustomerGroupView _view;
        private readonly ICustomerGroupRepository _repository;
        private readonly BindingSource _groupsBindingSource;
        private IEnumerable<CustomerGroupModel> _groupList;

        public CustomerGroupPresenter(ICustomerGroupView view, ICustomerGroupRepository repository)
        {
            _groupsBindingSource = new BindingSource();
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _view.SearchEvent += SearchGroup;
            _view.AddNewEvent += AddGroup;
            _view.EditEvent += LoadSelectGroupToEdit;
            _view.DeleteEvent += DeleteSelectGroup;
            _view.SaveEvent += SaveGroup;
            _view.CancelEvent += CancelAction;

            _view.SetGroupListBindingSource(_groupsBindingSource);

            LoadAllGroupList();

            _view.Show();
        }

        private void LoadAllGroupList()
        {
            _groupList = _repository.GetAll();
            _groupsBindingSource.DataSource = _groupList;
        }

        private void SearchGroup(object sender, EventArgs e)
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            _groupList = emptyValue ? _repository.GetAll() : _repository.GetByValue(_view.SearchValue);
            _groupsBindingSource.DataSource = _groupList;
        }

        private void CleanViewFields()
        {
            _view.group_id = "0";
            _view.name = string.Empty;
            _view.description = string.Empty;
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void SaveGroup(object sender, EventArgs e)
        {
            var model = new CustomerGroupModel
            {
                GroupId = Convert.ToInt32(_view.group_id),
                Name = _view.name,
                Description = _view.description,
                CreatedAt = DateTime.Now
            };

            try
            {
                if (_view.IsEdit)
                {
                    _repository.Edit(model);
                    _view.Message = "Group edited successfully";
                }
                else
                {
                    _repository.Add(model);
                    _view.Message = "Group added successfully";
                }

                _view.IsSuccessful = true;
                LoadAllGroupList();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void DeleteSelectGroup(object sender, EventArgs e)
        {
            try
            {
                var current = (CustomerGroupModel)_groupsBindingSource.Current;
                if (current == null) throw new InvalidOperationException("No group selected.");
                _repository.Delete(current.GroupId);
                _view.IsSuccessful = true;
                _view.Message = "Group deleted successfully";
                LoadAllGroupList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error occurred, could not delete group: " + ex.Message;
            }
        }

        private void LoadSelectGroupToEdit(object sender, EventArgs e)
        {
            var current = (CustomerGroupModel)_groupsBindingSource.Current;
            if (current == null) return;
            _view.group_id = current.GroupId.ToString();
            _view.name = current.Name;
            _view.description = current.Description;
            _view.IsEdit = true;
        }

        private void AddGroup(object sender, EventArgs e)
        {
            _view.IsEdit = false;
        }
    }
}