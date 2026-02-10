using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    internal class Session
    {
        public static int UserId { get; set; }
        public static int PatientId { get; set; }
        public static int DoctorId { get; set; }
        public static int PharmacistId { get; set; }
        public static int AdminId { get; set; }
        public static string Role { get; set; }
        public static List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
