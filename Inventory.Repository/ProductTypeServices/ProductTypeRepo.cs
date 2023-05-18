using Inventory.Repository.Paging;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductTypeServices
{
    public class ProductTypeRepo: IProductTypeRepo
    {
        private ApplicationDBContext _context;
        public ProductTypeRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ProductTypeListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var productTypeList = _context.ProductTypes;
            var vm = productTypeList.ModelToView().AsQueryable();

            return await PaginatedList<ProductTypeListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
