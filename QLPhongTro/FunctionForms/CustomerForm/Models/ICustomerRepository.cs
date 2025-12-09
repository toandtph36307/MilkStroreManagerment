using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.FunctionForms.OverViewForm.Models
{
    public interface ICustomerRepository
    {
        
        int Add(CustomerModel customerModel);
        void Edit(CustomerModel customerModel);
        void Delete(int id);
        IEnumerable<CustomerModel> GetAll();
        IEnumerable<CustomerModel> GetByValue(string value);
        IEnumerable<CustomerModel> GetByGroup(int groupId);
    }
}
