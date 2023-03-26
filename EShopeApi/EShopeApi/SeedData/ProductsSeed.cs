using EShopeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopeApi.SeedData
{
    public static class ProductsSeed
    {

        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                
                new Products
                {
                    ProductId= 1,
                    ProductName="Apple watch",
                    ProductBrand="Apple",
                    Price=9750,
                    ProductCount=17
                }
                
                );
            modelBuilder.Entity<Products>().HasData(

                new Products
                {
                    ProductId = 2,
                    ProductName = "iphone 13",
                    ProductBrand = "Apple",
                    Price = 19750,
                    ProductCount = 13
                }

                );
            modelBuilder.Entity<Products>().HasData(

                new Products
                {
                    ProductId = 3,
                    ProductName = "Headphone",
                    ProductBrand = "Apple",
                    Price = 850,
                    ProductCount = 20
                }

                );
        }

    }
}
