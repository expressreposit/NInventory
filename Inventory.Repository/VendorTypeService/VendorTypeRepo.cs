using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.VendorTypeService
{
    public class VendorTypeRepo : IVendorTypeRepo
    {
        private ApplicationDBContext _context;
        public VendorTypeRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Add(CreateVendorTypeViewModel vm)
        {
            var billType = new CreateVendorTypeViewModel().Convert(vm);
            _context.VendorTypes.Add(billType);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var model = _context.VendorTypes.Find(Id);
            if (model != null)
            {
                _context.VendorTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public List<VendorTypeViewModel> GetAll(int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<VendorTypeViewModel> vmList = new List<VendorTypeViewModel>();
            try
            {
                int ExcludeRecord = ((pageSize * pageNumber) - pageSize);
                var customerTypeList = _context.VendorTypes
                    .Skip(ExcludeRecord).Take(pageSize).ToList();
                totalCount = _context.VendorTypes.ToList().Count();
                vmList = ConvertModelToViewModelList(customerTypeList);

            }
            catch (Exception ex) { throw; }

            return vmList;
        }

        public VendorTypeViewModel GetById(int Id)
        {
            var model = _context.VendorTypes.Find(Id);
            var vm = new VendorTypeViewModel(model);
            return vm;
        }

        public void Update(VendorTypeViewModel vm)
        {
            var model = _context.VendorTypes.Where(x => x.VendorTypeId == vm.VendorTypeId).FirstOrDefault();
            if (model != null)
            {
                model.VendorTypeName = vm.VendorTypeName;
                model.Description = vm.Description;
                _context.VendorTypes.Add(model);
            }
            _context.SaveChanges();
        }
        private List<VendorTypeViewModel> ConvertModelToViewModelList(List<VendorType> modelList)
        {
            return modelList.Select(x => new VendorTypeViewModel(x)).ToList();
        }
    }
}
