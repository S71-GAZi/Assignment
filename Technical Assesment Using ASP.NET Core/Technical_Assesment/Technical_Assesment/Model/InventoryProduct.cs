using EmployeeManagement.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Assesment.Model
{
    public class InventoryProduct
    {
        public int Id { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public Inventories Inventory { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public double Discount { get; set; }
    }
}
