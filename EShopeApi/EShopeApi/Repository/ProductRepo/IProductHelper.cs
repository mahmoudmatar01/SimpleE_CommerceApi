using EShopeApi.DTO;
using EShopeApi.Models;

namespace EShopeApi.Repository.ProductRepo
{
    public interface IProductHelper
    {

        public ICollection<Products> GetAll();
        public Products Getbyid(int id);
        public void DeleteProduct(int id);
        public Products UpdateProduct(int id, ProductDto product);
        public bool isExist(int id);
        public Products CreateProduct (ProductDto product);



    }
}
