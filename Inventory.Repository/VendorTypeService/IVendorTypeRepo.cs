using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.VendorTypeService
{
    public interface IVendorTypeRepo
    {
        List<VendorTypeViewModel> GetAll(int pageSize, int pageNumber);
        void Add(CreateVendorTypeViewModel model);
        void Update(VendorTypeViewModel model);
        void Delete(int Id);
        VendorTypeViewModel GetById(int Id);
    }
}
