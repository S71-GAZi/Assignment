using EmployeeManagement.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Assesment.Model.DTO
{
    public class InventoryProduct_DTO
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public double Discount { get; set; }
    }
}
