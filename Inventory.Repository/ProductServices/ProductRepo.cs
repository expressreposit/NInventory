using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.ProductServices
{
    public class ProductRepo: IProductRepo
    {
        private ApplicationDBContext _context;
        public ProductRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PaginatedList<ProductListViewModel>> GetAll(int pageSize, int pageNumber)
        {
            var productList = _context.Product;
            var vm = productList.ModelToView().AsQueryable();

            return await PaginatedList<ProductListViewModel>.CreateAsync(vm, pageSize, pageNumber);
        }
    }
}
