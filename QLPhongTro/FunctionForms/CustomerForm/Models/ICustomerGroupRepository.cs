
using System.Collections.Generic;

namespace QLPhongTro.FunctionForms.CustomerForm.Models
{
    public interface ICustomerGroupRepository
    {
        void Add(CustomerGroupModel model);
        void Edit(CustomerGroupModel model);
        void Delete(int id);
        IEnumerable<CustomerGroupModel> GetAll();
        IEnumerable<CustomerGroupModel> GetByValue(string value);
    }
}