using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model.DTO
{
    public class Inventory_DTO
    {

  
        public int Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        [Required]
        public string BillNo { get; set; }
        public int CustomersId { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalBillAmount { get; set; }
        public double DueAmount { get; set; }
        public double PaidAmount { get; set; }
    }
}
