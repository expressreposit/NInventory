using Inventory.Repository.CustomerTypess;
using Inventory.Repository.VendorTypeService;
using Inventory.ViewModel.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class VendorTypeController : Controller
    {
        private readonly IVendorTypeRepo _vendorTypeRepo;
        public VendorTypeController(IVendorTypeRepo vendorTypeRepo)
        {
            _vendorTypeRepo = vendorTypeRepo;
        }
        [HttpGet]
        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            var CustomerTypes = _vendorTypeRepo.GetAll(pageSize, pageNumber);
            return View(CustomerTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVendorTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _vendorTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = _vendorTypeRepo.GetById(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(VendorTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _vendorTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _vendorTypeRepo.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
