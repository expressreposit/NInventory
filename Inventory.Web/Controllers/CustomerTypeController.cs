using Inventory.Repository.CustomerTypess;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class CustomerTypeController : Controller
    {
        private readonly ICustomerTypeRepo _customerTypeRepo;

        public CustomerTypeController(ICustomerTypeRepo customerTypeRepo)
        {
            _customerTypeRepo = customerTypeRepo;
        }

        [HttpGet]
        public  IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var CustomerTypes =  _customerTypeRepo.GetAll(pageSize, pageNumber);
            return View(CustomerTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCustomerTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = _customerTypeRepo.GetById(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(CustomerTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _customerTypeRepo.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
