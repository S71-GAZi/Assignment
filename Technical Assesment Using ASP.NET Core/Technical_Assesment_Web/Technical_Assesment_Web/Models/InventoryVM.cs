using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Technical_Assesment_Web.Models;

public class InventoryVM:BaseModel
{
    public int Id { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string BillNo { get; set; }
    public int CustomersId { get; set; }
    public CustomerVM Customers { get; set; }
    public double TotalDiscount { get; set; }
    public double TotalBillAmount { get; set; }
    public double DueAmount { get; set; }
    public double PaidAmount { get; set; }

    //-----------------------------------------------
    public IList<InventoryVM> Inventories { get; set; }
    public InventoryVM Inventory { get; set; }
    public string TempDate { get; set; }
    //----------------------------------------------

    public IList<InventoryVM> GetInventoryList()
    {
        Inventories = new List<InventoryVM>();
        try
        {

            HttpResponseMessage response = GetResponse(Api_Address, ApiController_Inventories);

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<InventoryVM>>().Result;
                Inventories = (IList<InventoryVM>)dataObjects;
            }

            response.EnsureSuccessStatusCode();

            return Inventories;
        }
        catch (Exception)
        {
            //return Inventorys;
            throw;
        }
    }

    public InventoryVM GetSingleInventory(int id)
    {
        Inventory = new InventoryVM();
        try
        {
            HttpResponseMessage response = GetResponse(Api_Address, ApiController_Inventories + "/" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<InventoryVM>().Result;
                Inventory = dataObjects;
            }

            response.EnsureSuccessStatusCode();
            return Inventory;
        }
        catch (Exception)
        {
            return Inventory;
            throw;
        }
    }

    public int AddSingleInventory(InventoryVM Inventory)
    {
        InventoryVM obj = new InventoryVM();
        obj = Inventory;
        
        try
        {
            Task<HttpResponseMessage> response = PostResponse(Api_Address, ApiController_Inventories, obj);
            var dataObjects = response.Result.Content.ReadFromJsonAsync<InventoryVM>().Result;

            if (response.IsCompleted)
            {

            }

            return dataObjects.Id;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
    public void EditSingleInventory(InventoryVM Inventory)
    {
        try
        {
            Task<HttpResponseMessage> response = PutResponse(Api_Address, ApiController_Inventories, Inventory.Id.ToString(), Inventory);

            if (response.IsCompleted)
            {

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void DeleteSingleInventory(int id)
    {
        try
        {
            HttpResponseMessage response = DeleteResponse(Api_Address, ApiController_Inventories, id.ToString());

            if (response.IsSuccessStatusCode)
            {

            }
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
