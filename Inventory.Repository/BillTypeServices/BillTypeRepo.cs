using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Inventory.ViewModel.Vendor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.BillTypeServices
{
    public class BillTypeRepo : IBillTypeRepo
    {
        private ApplicationDBContext _context;
        public BillTypeRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public List<BillTypeListViewModel> GetAll(int pageSize, int pageNumber)
        {
            var billTypeList =  _context.BillTypes;
            var vm =  billTypeList.ModelToView().AsQueryable();

            int totalCount = 0;
            List<BillTypeListViewModel> vmList = new List<BillTypeListViewModel>();
            try
            {
                int ExcludeRecord = ((pageSize * pageNumber) - pageSize);
                var BillTypesTypeList = _context.BillTypes
                    .Skip(ExcludeRecord).Take(pageSize).ToList();
                totalCount = _context.BillTypes.ToList().Count();
                vmList = ConvertModelToViewModelList(BillTypesTypeList);

            }
            catch (Exception ex) { throw; }
            return vmList;
        }

        public void Add(CreateBillTypeViewModel model)
        {
            var billType = model.ViewModel();
            _context.BillTypes.Add(billType);
            _context.SaveChangesAsync();
        }

        public  void Update(BillTypeViewModel vm)
        {
            var model = _context.BillTypes.Where(x => x.BillTypeId == vm.BillTypeId).FirstOrDefault();
            if (model != null)
            {
                model.BillTypeName = vm.BillTypeName;
                model.Description = vm.Description;
                _context.BillTypes.Add(model);
            }
            _context.SaveChanges();
        }

        public  void Delete(int Id)
        {
            var model = _context.BillTypes.Find(Id);
            if (model != null)
            {
                _context.BillTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public   BillTypeViewModel GetById(int Id)
        {
            var model = _context.BillTypes.Find(Id);
            var vm =  new BillTypeViewModel(model);
            return vm;
        }
        private List<BillTypeListViewModel> ConvertModelToViewModelList(List<BillType> modelList)
        {
            return modelList.Select(x => new BillTypeListViewModel(x)).ToList();
        }
    }
}
