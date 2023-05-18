using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillServices
{
    public class BillRepo : IBillRepo
    {
        private ApplicationDBContext _context;
        public BillRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public  List<BillListViewModel> GetAll(int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<BillListViewModel> vmList = new List<BillListViewModel>();
            try
            {
                int ExcludeRecord = ((pageSize * pageNumber) - pageSize);
                var BillsTypeList = _context.Bills
                    .Skip(ExcludeRecord).Take(pageSize).ToList();
                totalCount = _context.Bills.ToList().Count();
                vmList = ConvertModelToViewModelList(BillsTypeList);

            }
            catch (Exception ex) { throw; }

            return vmList;
        }
        private List<BillListViewModel> ConvertModelToViewModelList(List<Bill> modelList)
        {
            return modelList.Select(x => new BillListViewModel(x)).ToList();
        }


    }
}
