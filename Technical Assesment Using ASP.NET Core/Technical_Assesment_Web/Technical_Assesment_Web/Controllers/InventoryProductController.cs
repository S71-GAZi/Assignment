using Microsoft.AspNetCore.Mvc;
using Technical_Assesment_Web.Models;

namespace Technical_Assesment_Web.Controllers;
public class InventoryProductController : Controller
{
    public IActionResult Index()
    {
        var model = new InventoryProductVM();
        var productModel = new ProductVM();
        var customerModel = new CustomerVM();
        ViewBag.Products = productModel.GetProductList();
        ViewBag.Customers = customerModel.GetCustomerList();
        ViewBag.PurchaseDate = DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
        return View(model);
    }

    public JsonResult GetProductInfo(int proId)
    {
        var model = new ProductVM();
        model.GetSingleProduct(proId);
        return Json(model); 
    }

    public IActionResult SaveInventory(InventoryVM inventory, List<InventoryProductVM> inventoryProducts)
    {
        var inventoryProductModel = new InventoryProductVM();
        var inventoryModel = new InventoryVM();
        if (inventory.BillNo == null)
        {
            inventory.BillNo = "BN-" + Guid.NewGuid().ToString().Substring(0,5).ToUpper();
        }
        var inventoryId = inventoryModel.AddSingleInventory(inventory);
        foreach (var ip in inventoryProducts)
        {
            ip.InventoryId = inventoryId;
            inventoryProductModel.AddSingleInventoryProduct(ip);
        }

        return Json(1);
    }

    public JsonResult GetInventoryProducts(string billNo)
    {
        var model = new InventoryProductVM();
        model.GetFindInventoryProduct(billNo);
        foreach (var ip in model.InventoryProducts)
        {
            ip.Inventory.TempDate = ip.Inventory.AttendanceDate.ToString("yyyy-MM-dd");
        }
        return Json(model);
    }
}
