using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Wcf.DAL;

namespace MyRESTService.Endpoints
{
    [ServiceContract]    
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json
                                 , UriTemplate = "GetAllProducts")]
        List<Product> GetAllProducts();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json
                                  , ResponseFormat = WebMessageFormat.Json
                                  , UriTemplate = "AddProduct")]                
        bool AddProduct(Product product);
    }
}
