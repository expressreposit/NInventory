using Inventory.Repository.Paging;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerServices
{
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDBContext _context;
        public CustomerRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<CustomerListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var customerList = _context.Customers;
            var vm = customerList.ModelToView().AsQueryable();

            return await PaginatedList<CustomerListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
