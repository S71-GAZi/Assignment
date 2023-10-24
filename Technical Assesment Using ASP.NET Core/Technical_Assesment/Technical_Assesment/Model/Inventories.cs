using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Model
{
    public class Inventories
    {
        //
        [Key]
        public int Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        [Required]
        public string  BillNo { get; set; }
        
        [ForeignKey("Customers")]
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        
        public double TotalDiscount { get; set; }
        public double TotalBillAmount { get; set; }
        public double DueAmount { get; set; }
        public double PaidAmount { get; set; }
    }
}
