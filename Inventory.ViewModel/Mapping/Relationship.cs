using Inventory.Models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Mapping
{
    public static class Relationship
    {
        public static IEnumerable<CustomerTypeListViewModel> ModelToView(this IEnumerable<Inventory.Models.CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> list = new List<CustomerTypeListViewModel>();
            foreach (var ct in customerType)
            {
                list.Add(new CustomerTypeListViewModel()
                {
                    CustomerTypeId = ct.CustomerTypeId,
                    CustomerTypeName = ct.CustomerTypeName,
                    Description = ct.Description
                });
            }
            return list;
        }

        public static IEnumerable<CustomerListViewModel> ModelToView(this IEnumerable<Inventory.Models.Customer> customers)
        {
            List<CustomerListViewModel> list = new List<CustomerListViewModel>();
            foreach (var ct in customers)
            {
                list.Add(new CustomerListViewModel()
                {
                    CustomerId = ct.CustomerId,
                    CustomerName = ct.CustomerName,
                    CustomerTypeId = ct.CustomerTypeId,
                    Address = ct.Address,
                    City = ct.City,
                    State = ct.State,
                    ZipCode = ct.ZipCode,
                    Email = ct.Email,
                    Phone = ct.Phone,
                    ContactPerson = ct.ContactPerson
                });
            }
            return list;
        }

        public static IEnumerable<BillTypeListViewModel> ModelToView(this IEnumerable<Inventory.Models.BillType> billTypes)
        {
            List<BillTypeListViewModel> list = new List<BillTypeListViewModel>();
            foreach (var ct in billTypes)
            {
                list.Add(new BillTypeListViewModel()
                {
                    BillTypeId = ct.BillTypeId,
                    BillTypeName = ct.BillTypeName,
                    Description = ct.Description
                });
            }
            return list;
        }
        public static IEnumerable<BillListViewModel> ModelToView(this IEnumerable<Inventory.Models.Bill> Bills)
        {
            List<BillListViewModel> list = new List<BillListViewModel>();
            foreach (var ct in Bills)
            {
                list.Add(new BillListViewModel()
                {
                    BillId = ct.BillId,
                    BillName = ct.BillName,
                    GoodsReceivedNoteId = ct.GoodsReceivedNoteId,
                    VenderDoNumber = ct.VenderDoNumber,
                    VendorInvoiceNumber = ct.VendorInvoiceNumber,
                    BillDate = ct.BillDate,
                    BillDueDate = ct.BillDueDate,
                    BillTypeId = ct.BillTypeId
                });
            }
            return list;
        }
        public static IEnumerable<ProductListViewModel> ModelToView(this IEnumerable<Inventory.Models.Product> Products)
        {
            List<ProductListViewModel> list = new List<ProductListViewModel>();
            foreach (var ct in Products)
            {
                list.Add(new ProductListViewModel()
                {
                    ProductId=ct.ProductId,
                    ProductName = ct.ProductName,
                    ProductCode=ct.ProductCode,
                    BarCode=ct.BarCode,
                    Description=ct.Description,
                    ProductImage=ct.ProductImage,
                    MeasureUnitId=ct.MeasureUnitId,
                    BuyingPrice=ct.BuyingPrice,
                    SellingPrice=ct.SellingPrice,
                    BranchId = ct.BranchId,
                    CurrencyId=ct.CurrencyId
                });
            }
            return list;
        }
        public static IEnumerable<ProductTypeListViewModel> ModelToView(this IEnumerable<Inventory.Models.ProductType> ProductTypes)
        {
            List<ProductTypeListViewModel> list = new List<ProductTypeListViewModel>();
            foreach (var ct in ProductTypes)
            {
                list.Add(new ProductTypeListViewModel()
                {
                    ProductTypeId = ct.ProductTypeId,
                    ProductTypeName=ct.ProductTypeName,
                    Description=ct.Description
                });
            }
            return list;
        }

    }
}
