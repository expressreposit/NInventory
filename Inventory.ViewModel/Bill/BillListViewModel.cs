using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory.ViewModel.Bill
{
    public class BillListViewModel
    {
        public int BillId { get; set; }
        [Display(Name = "Bill / Invoice Number")]
        public string BillName { get; set; }
        [Display(Name = "GRN")]

        public int GoodsReceivedNoteId { get; set; }
        [Display(Name = "Vendor Delivery Order")]

        public string VenderDoNumber { get; set; }
        [Display(Name = "Vendor Bill / Invoice")]

        public string VendorInvoiceNumber { get; set; }
        [Display(Name = "Bill Date")]

        public DateTimeOffset BillDate { get; set; }
        [Display(Name = "Bill Due Date")]

        public DateTimeOffset BillDueDate { get; set; }
        [Display(Name = "Bill Type")]
        public int BillTypeId { get; set; }
        public BillListViewModel()
        {
            
        }
        public BillListViewModel(Inventory.Models.Bill model)
        {
            BillId = model.BillId;
            BillName = model.BillName;
            GoodsReceivedNoteId = model.GoodsReceivedNoteId;
            VendorInvoiceNumber = model.VendorInvoiceNumber;
            VenderDoNumber = model.VenderDoNumber;
            BillDate = model.BillDate;
            BillDueDate= model.BillDueDate;
            BillTypeId= model.BillTypeId;

        }
    }
    
}
