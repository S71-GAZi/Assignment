using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Assesment_Web.Models;

public class InventoryProductVM:BaseModel
{
    public int Id { get; set; }
    public int InventoryId { get; set; }
    public InventoryVM Inventory { get; set; }
    public int ProductId { get; set; }
    public ProductVM Product { get; set; }
    public double Rate { get; set; }
    public double Qty { get; set; }
    public double Discount { get; set; }

    //------------------------------------------------
    public IList<InventoryProductVM> InventoryProducts { get; set; }
    public InventoryProductVM InventoryProduct { get; set; }

    private readonly ProductVM _productVM;
    public IList<ProductVM> Products { get; set; }

    private readonly CustomerVM _customerVM;
    public IList<CustomerVM> Customers { get; set; }
    //--------------------------------------------------

    public IList<InventoryProductVM> GetInventoryProductList()
    {
        InventoryProducts = new List<InventoryProductVM>();
        try
        {

            HttpResponseMessage response = GetResponse(Api_Address, ApiController_InventoryProducts);

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<InventoryProductVM>>().Result;
                InventoryProducts = (IList<InventoryProductVM>)dataObjects;
            }

            response.EnsureSuccessStatusCode();

            return InventoryProducts;
        }
        catch (Exception)
        {
            return InventoryProducts;
            throw;
        }
    }

    public InventoryProductVM GetSingleInventoryProduct(int id)
    {
        InventoryProduct = new InventoryProductVM();
        try
        {
            HttpResponseMessage response = GetResponse(Api_Address, ApiController_InventoryProducts + "/" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<InventoryProductVM>().Result;
                InventoryProduct = dataObjects;
            }

            response.EnsureSuccessStatusCode();
            return InventoryProduct;
        }
        catch (Exception)
        {
            return InventoryProduct;
            throw;
        }
    }

    public int AddSingleInventoryProduct(InventoryProductVM inventoryProduct)
    {
        InventoryProductVM obj = new InventoryProductVM();
        obj = inventoryProduct;

        try
        {
            Task<HttpResponseMessage> response = PostResponse(Api_Address, ApiController_InventoryProducts, obj);
            var dataObjects = response.Result.Content.ReadFromJsonAsync<InventoryProductVM>().Result;

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
    public void EditSingleInventoryProduct(InventoryProductVM inventoryProduct)
    {
        try
        {
            Task<HttpResponseMessage> response = PutResponse(Api_Address, ApiController_InventoryProducts, inventoryProduct.Id.ToString(), inventoryProduct);

            if (response.IsCompleted)
            {

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void DeleteSingleInventoryProduct(int id)
    {
        try
        {
            HttpResponseMessage response = DeleteResponse(Api_Address, ApiController_InventoryProducts, id.ToString());

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

    public IList<InventoryProductVM> GetFindInventoryProduct(string billNo)
    {
        InventoryProducts = new List<InventoryProductVM>();
        try
        {
            HttpResponseMessage response = GetResponse(Api_Address, ApiController_InventoryProducts + $"/GetInventoryProduct/{billNo}");

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<InventoryProductVM>>().Result;
                InventoryProducts = dataObjects.ToList();
            }

            response.EnsureSuccessStatusCode();
            return InventoryProducts;
        }
        catch (Exception)
        {
            return InventoryProducts;
            throw;
        }
    }
}
