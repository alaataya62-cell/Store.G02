using Store.G02.ServicesAbstructure.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G02.ServicesAbstructure
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
    }
}
