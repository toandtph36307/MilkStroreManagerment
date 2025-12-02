
using System;
using System.Windows.Forms;

namespace QLPhongTro.FunctionForms.CustomerForm.View
{
    public interface ICustomerGroupView
    {
        string group_id { get; set; }
        string name { get; set; }
        string description { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetGroupListBindingSource(BindingSource groupList);
        void Show();
    }
}