using AutoMapper;
using EmployeeManagement.Model;
using EmployeeManagement.Model.DTO;
using Technical_Assesment.Model;
using Technical_Assesment.Model.DTO;

namespace EmployeeManagement.Helper
{
    public class ApplicationMapper: Profile
    {
            public ApplicationMapper()
            {
                CreateMap<Inventories, Inventory_DTO>().ReverseMap();
                CreateMap<InventoryProduct, InventoryProduct_DTO>().ReverseMap();
                
            }
       
    }
}
