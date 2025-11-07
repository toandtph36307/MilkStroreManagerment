using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.FunctionForms.salesForm.Models
{
    public class ProductSuggestion
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"[{ProductId}] {Name} - {Price:N0}đ - SL: {Quantity}";
        }
    }
}
