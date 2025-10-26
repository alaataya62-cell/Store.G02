using Microsoft.EntityFrameworkCore;
using Store.G02.Domain.Contracts;
using Store.G02.Domain.Entity;
using Store.G02.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Store.G02.Persistence
{
    public class DbInitialize (StoreDbContext _context) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Any())
                await _context.Database.MigrateAsync();

            if ( !_context.ProductBrands.Any())
            {
               
                var branddata =  File.ReadAllText(@"../Infrastructure\Store.G02.Persistence\Data\DataSeeding\brands.json");
                var brand = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);
                if (brand is not null && brand.Count > 0)
                {
                    await _context.ProductBrands.AddRangeAsync(brand);
                }
            }

           if (!_context.ProductTypes.Any())
            {
                var typedata = File.ReadAllText(@"../Infrastructure\Store.G02.Persistence\Data\DataSeeding\types.json");
                var type = JsonSerializer.Deserialize<List<ProductType>>(typedata);
                if (type is not null && type.Count > 0)
                {
                    await _context.ProductTypes.AddRangeAsync(type);
                }
            }
            if (!_context.Products.Any())
            {
                var productdata = File.ReadAllText(@"../Infrastructure\Store.G02.Persistence\Data\DataSeeding\products.json");
                var product = JsonSerializer.Deserialize<List<Product>>(productdata);
                if (product is not null && product.Count > 0)
                {
                    await _context.Products.AddRangeAsync(product);
                }
            }
            _context.SaveChangesAsync();
        }

            
        
        //Data seeding 
    }
}
