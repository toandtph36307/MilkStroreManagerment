using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.FunctionForms.salesForm.Models
{
    public class CustomerSuggestion
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"[{CustomerId}] {FullName} - {Phone}";
        }
    }
}
