namespace Technical_Assesment_Web.Models;

public class CustomerVM:BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    //------------------------------------------
    public IList<CustomerVM> Customers { get; set; }
    public CustomerVM Customer { get; set; }
    //--------------------------------------------
    public IList<CustomerVM> GetCustomerList()
    {
        Customers = new List<CustomerVM>();
        try
        {

            HttpResponseMessage response = GetResponse(Api_Address, ApiController_Customer);

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<IEnumerable<CustomerVM>>().Result;
                Customers = (IList<CustomerVM>)dataObjects;
            }

            response.EnsureSuccessStatusCode();

            return Customers;
        }
        catch (Exception)
        {
            //return Customers;
            throw;
        }
    }

    public CustomerVM GetSingleCustomer(int id)
    {
        Customer = new CustomerVM();
        try
        {
            HttpResponseMessage response = GetResponse(Api_Address, ApiController_Customer + "/" + id.ToString());

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<CustomerVM>().Result;
                Customer = dataObjects;
            }

            response.EnsureSuccessStatusCode();
            return Customer;
        }
        catch (Exception)
        {
            return Customer;
            throw;
        }
    }

    public int AddSingleCustomer(CustomerVM Customer)
    {
        CustomerVM obj = new CustomerVM();
        obj = Customer;

        try
        {
            Task<HttpResponseMessage> response = PostResponse(Api_Address, ApiController_Customer, obj);
            var dataObjects = response.Result.Content.ReadFromJsonAsync<CustomerVM>().Result;

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
    public void EditSingleCustomer(CustomerVM Customer)
    {
        try
        {
            Task<HttpResponseMessage> response = PutResponse(Api_Address, ApiController_Customer, Customer.Id.ToString(), Customer);

            if (response.IsCompleted)
            {

            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void DeleteSingleCustomer(int id)
    {
        try
        {
            HttpResponseMessage response = DeleteResponse(Api_Address, ApiController_Customer, id.ToString());

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
