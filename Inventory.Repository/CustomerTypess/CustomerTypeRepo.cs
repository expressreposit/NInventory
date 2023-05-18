using Inventory.Models;
using Inventory.Repository.Paging;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repository.CustomerTypess
{
    public class CustomerTypeRepo : ICustomerTypeRepo
    {
        private ApplicationDBContext _context;
        public CustomerTypeRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Add(CreateCustomerTypeViewModel vm)
        {
            var model = new CreateCustomerTypeViewModel().Convert(vm);
            _context.CustomerTypes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var model = _context.CustomerTypes.Find(Id);
            if (model != null)
            {
                _context.CustomerTypes.Remove(model);
            }
            _context.SaveChanges();
        }

        public List<CustomerTypeListViewModel> GetAll(int pageSize, int pageNumber)
        {
            int totalCount = 0;
            List<CustomerTypeListViewModel> vmList = new List<CustomerTypeListViewModel>();
            try
            {
                int ExcludeRecord = ((pageSize * pageNumber) - pageSize);
                var customerTypeList = _context.CustomerTypes
                    .Skip(ExcludeRecord).Take(pageSize).ToList();
                totalCount = _context.CustomerTypes.ToList().Count();
                vmList = ConvertModelToViewModelList(customerTypeList);

            }
            catch(Exception ex) { throw; }
            return vmList;
        }

        public void Update(CustomerTypeViewModel vm)
        {
            var model = _context.CustomerTypes.Where(x => x.CustomerTypeId == vm.CustomerTypeId).FirstOrDefault();
            if (model != null)
            {
                model.CustomerTypeName = vm.CustomerTypeName;
                model.Description = vm.Description;
                _context.CustomerTypes.Add(model);
            }
            _context.SaveChanges();
        }
        public CustomerTypeViewModel GetById(int Id)
        {
            var model = _context.CustomerTypes.Find(Id);
            var vm = new CustomerTypeViewModel(model);
            return vm;
        }

        private List<CustomerTypeListViewModel> ConvertModelToViewModelList(List<CustomerType> modelList)
        {
            return modelList.Select(x => new CustomerTypeListViewModel(x)).ToList();
        }
    }
}
