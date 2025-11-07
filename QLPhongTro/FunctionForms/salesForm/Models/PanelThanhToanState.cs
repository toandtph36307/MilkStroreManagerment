using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.FunctionForms.salesForm.Models
{
    public class PanelThanhToanState
    {
        public string TotalMoney { get; set; }
        public string Discount { get; set; }
        public string TotalAfterDiscount { get; set; }
        public string CusPay { get; set; }
        public string CashChange { get; set; }
        public string Customers { get; set; }
        public int? SelectedCustomerId { get; set; }
    }
}
