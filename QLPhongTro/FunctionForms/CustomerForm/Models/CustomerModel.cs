using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QLPhongTro.FunctionForms.OverViewForm.Models
{
    public class CustomerModel
    {
        private int customer_id;
        private string full_name;
        private string email;
        private string phone;
        private string address;
        private string status;

        [DisplayName("Customer ID")]
        public int Customer_id { get => customer_id; set => customer_id = value; }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Customer name is requerid")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Customer name must be between 3 and 50 characters")]
        public string Full_name { get => full_name; set => full_name = value; }

        [DisplayName("Customer Email")]
        [Required(ErrorMessage = "Customer Email is requerid")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Customer Email must be between 3 and 50 characters")]
        public string Email { get => email; set => email = value; }

        [DisplayName("Customer Phone")]
        [Required(ErrorMessage = "Customer Phone is requerid")]
        [StringLength(13, MinimumLength = 0, ErrorMessage = "Customer Phone must be between 0 and 13 characters")]
        public string Phone { get => phone; set => phone = value; }

        [DisplayName("Customer Address")]
        [Required(ErrorMessage = "Customer Address colour is requerid")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Customer Address must be between 0 and 500 characters")]
        public string Address { get => address; set => address = value; }

        [DisplayName("Status")]
        [StringLength(10)]
        public string Status { get => status; set => status = value; }
    }
}
