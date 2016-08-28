using System.Collections.Generic;
using WCF = Wcf.DAL;
using Sql.DAL.Converter;
using ServiceUtil.Parser;
using System;

namespace ServiceUtil
{
    public interface IProductService
    {
        List<WCF.Product> GetAllProducts();
        bool AddProduct(WCF.Product product);
    }
    public class ProductService : IProductService
    {
        private IProductParser productParser;
        private IProductRepository productRepository;
        public ProductService()
        {
            productRepository = new ProductRepository() ;
            productParser = new ProductParser();
        }
        public List<WCF.Product> GetAllProducts()
        {            
            return productRepository.GetAllProducts()
                                   .ConvertAll(x => productParser.ToClientProduct(x));
        }

        public bool AddProduct(WCF.Product product)
        {
            return productRepository.AddProduct(productParser.ToServiceProduct(product));            
        }
    }
}
