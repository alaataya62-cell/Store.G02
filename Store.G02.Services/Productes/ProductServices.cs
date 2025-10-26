using AutoMapper;
using Store.G02.Domain.Contracts;
using Store.G02.Domain.Entity;
using Store.G02.Services.Mapping.Products;
using Store.G02.ServicesAbstructure.Products;
using Store.G02.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G02.Services.Productes
{
    public class ProductServices(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
      

        public async Task<IEnumerable<ProductResponse>> GetAllProductAnsyc()
        {
           var Product=await _unitOfWork.GetRepository<int,Product>().GetAllAsync();
          var result = _mapper.Map<IEnumerable<ProductResponse>>(Product);
            return result;

        }

        public async Task<ProductResponse> GetProductByIdAnsyc(int id)
        {
            var products = await _unitOfWork.GetRepository<int, ProductType>().GetAsync(id);
            var result = _mapper.Map<ProductResponse>(products);
            return result;
        }
        public async Task<IEnumerable<BrandTypeResponse>> GetAllBrandAnsyc()
        {
            var brans = await _unitOfWork.GetRepository<int, ProductBrand>().GetAllAsync();
            var result = _mapper.Map<IEnumerable< BrandTypeResponse>>(brans);
            return result;
        }
        public async Task<IEnumerable<BrandTypeResponse>> GetAlltypeAnsyc()
        {
            var Types = await _unitOfWork.GetRepository<int, ProductType>().GetAllAsync();
            var result = _mapper.Map<IEnumerable< BrandTypeResponse>>(Types);
            return result;
        }

    }
}
