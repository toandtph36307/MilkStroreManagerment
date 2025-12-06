using System;
using System.Windows.Forms;

namespace QLPhongTro.FunctionForms.OverViewForm.View
{
    public interface ICustomerView
    {
         string customer_id { get; set; }
         string full_name { get; set; }
         string email { get; set; }
         string phone { get; set; }
         string address { get; set; }
         string status { get; set; }



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

        void SetCustomerListBindingSource(BindingSource CustomerList);
        void Show();

    }
}
