
using Inventory.Repository.BillTypeServices;
using Inventory.ViewModel.Bill;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class BillTypesController : Controller
    {
        private readonly IBillTypeRepo _billTypeRepo;

        public BillTypesController(IBillTypeRepo billTypeRepo)
        {
            _billTypeRepo = billTypeRepo;
        }
        [HttpGet]
        public IActionResult Index(int pageSize=10, int pageNumber=1)
        {
            var BillTypes = _billTypeRepo.GetAll(pageSize, pageNumber);
            return View(BillTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBillTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _billTypeRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = _billTypeRepo.GetById(Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(BillTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _billTypeRepo.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _billTypeRepo.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
