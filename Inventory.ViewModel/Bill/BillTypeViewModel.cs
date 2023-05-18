using Inventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Bill
{
    public class BillTypeViewModel
    {
        public int BillTypeId { get; set; }
        public string BillTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public BillTypeViewModel(BillType model)
        {
            BillTypeId = model.BillTypeId;
            BillTypeName = model.BillTypeName;
            Description = model.Description;
        }
    }
}
