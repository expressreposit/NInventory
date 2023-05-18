using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerTypess
{
    public interface ICustomerTypeRepo
    {
        List<CustomerTypeListViewModel> GetAll(int pageSize, int pageNumber);
        void Add(CreateCustomerTypeViewModel model);
        void Update(CustomerTypeViewModel model);
        void Delete(int Id);
        CustomerTypeViewModel GetById(int Id);
    }
}
