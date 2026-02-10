using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    internal class CartItem
    {
        public int InventoryId { get; set; }
        public string MedicineName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
