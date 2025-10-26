using Store.G02.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G02.ServicesAbstructure.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProductAnsyc();
        Task<ProductResponse> GetProductByIdAnsyc(int Id);
        Task<IEnumerable<BrandTypeResponse>> GetAllBrandAnsyc();

        Task<IEnumerable<BrandTypeResponse>> GetAlltypeAnsyc();
    }
}
