using Microsoft.AspNetCore.Identity;

namespace Technical_Assesment_Web.Models;

public class ProductVM:BaseModel
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public double Rate { get; set; }

    //-----------------------------------------
    public IList<ProductVM> Products { get; set; }
    public ProductVM Product { get; set; }

    //--------------------------------------------

    public IList<ProductVM> GetProductList()
    {
        Products = new List<ProductVM>();
        try
        {

            HttpResponseMessage response = GetResponse(Api_Address, ApiController__Product);

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<ProductVM>>().Result;
                Products = (IList<ProductVM>)dataObjects;
            }

            response.EnsureSuccessStatusCode();

            return Products;
        }
        catch (Exception)
        {
            //return Products;
            throw;
        }
    }

    public ProductVM GetSingleProduct(int id)
    {
        Product = new ProductVM();
        try
        {
            HttpResponseMessage response = GetResponse(Api_Address, ApiController__Product + "/" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<ProductVM>().Result;
                Product = dataObjects;
            }

            response.EnsureSuccessStatusCode();
            return Product;
        }
        catch (Exception)
        {
            return Product;
            throw;
        }
    }

    public int AddSingleProduct(ProductVM Product)
    {
        ProductVM obj = new ProductVM();
        obj = Product;

        try
        {
            Task<HttpResponseMessage> response = PostResponse(Api_Address, ApiController__Product, obj);
            var dataObjects = response.Result.Content.ReadFromJsonAsync<ProductVM>().Result;

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
    public void EditSingleProduct(ProductVM Product)
    {
        try
        {
            Task<HttpResponseMessage> response = PutResponse(Api_Address, ApiController__Product, Product.Id.ToString(), Product);

            if (response.IsCompleted)
            {

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void DeleteSingleProduct(int id)
    {
        try
        {
            HttpResponseMessage response = DeleteResponse(Api_Address, ApiController__Product, id.ToString());

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
