using EShopeApi.DBContext;
using EShopeApi.DTO;
using EShopeApi.Models;

namespace EShopeApi.Repository.ProductRepo
{
    public class ProductHelper:IProductHelper
    {

        //private instance 
        private readonly DataContext _context;

        //public Constructor
        public ProductHelper(DataContext context)
        {
            _context = context;
        }

        //Methods implementation
        public Products CreateProduct(ProductDto product)
        {
            try
            {
                Products newproduct = new Products
                {
                    Price= product.Price,
                    ProductBrand=product.ProductBrand,
                    ProductCount= product.ProductCount,
                    ProductName= product.ProductName,
                    ProductDescription= product.ProductDescription,
                    
                };
                _context.Products.Add(newproduct);
                _context.SaveChanges();

                return newproduct;
            }
            catch (Exception ex)
            {
                return null!;
            }
        }

        public void DeleteProduct(int id)
        {
            Products product=_context.Products.Where(p=>p.ProductId==id).FirstOrDefault()!;
            _context.Products.Remove(product!);
            _context.SaveChanges();
        }

        public ICollection<Products> GetAll()
        {
            try
            {
                List<Products> products = (from obj in _context.Products
                                           orderby obj.ProductId select obj).ToList();
                return products;

            }
            catch (Exception ex)
            {
                return null!;
            }
        }

        public Products Getbyid(int id)
        {
            Products product=(from obj in _context.Products
                              where obj.ProductId==id 
                              select obj).FirstOrDefault()!;
            return product;
        }

        public bool isExist(int id)
        {
            return _context.Products.Any(p=>p.ProductId== id);
        }

        public Products UpdateProduct(int id, ProductDto product)
        {
            Products newproduct = (from obj in _context.Products
                                where obj.ProductId == id
                                select obj).FirstOrDefault()!;

            newproduct.ProductBrand = product.ProductBrand;
            newproduct.ProductName= product.ProductName;
            newproduct.ProductCount= product.ProductCount;
            newproduct.ProductDescription= product.ProductDescription;
            newproduct.Price= product.Price;
            _context.SaveChanges();
            return newproduct;
        }
    }
}
