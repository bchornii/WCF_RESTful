using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Wcf.DAL;
using Service = ServiceUtil;

namespace MyRESTService.Endpoints
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ProductService : IProductService
    {
        public bool AddProduct(Product product)
        {            
            return new Service.ProductService().AddProduct(product);                        
        }

        public List<Product> GetAllProducts()
        {
            //throw new System.ArgumentException("hello");
            return new Service.ProductService().GetAllProducts();                                            
        }
    }
}
