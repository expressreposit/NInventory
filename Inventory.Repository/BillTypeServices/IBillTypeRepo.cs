using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillTypeServices
{
    public interface IBillTypeRepo
    {
        List<BillTypeListViewModel> GetAll(int pageSize, int pageNumber);
        void Add(CreateBillTypeViewModel model);
        void Update(BillTypeViewModel model);
        void Delete(int Id);
        BillTypeViewModel GetById(int Id);
    }
}
