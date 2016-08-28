using WCF = Wcf.DAL;
using SQLd = Sql.DAL.Model;
using System;

namespace ServiceUtil.Parser
{
    public interface IParser<T> { }
    public class Parser<T> : IParser<T> { }

    public interface IProductParser
    {
        WCF.Product ToClientProduct(SQLd.Product prod);
        SQLd.Product ToServiceProduct(WCF.Product prod);
    }
    public class ProductParser : Parser<ProductParser>, IProductParser
    {
        public SQLd.Product ToServiceProduct(WCF.Product prod)
        {
            return new SQLd.Product
            {
                ProductId = prod.ProductId,
                ProductName = prod.ProductName,
                SupplierId = prod.SupplierId,
                CategoryId = prod.CategoryId,
                UnitPrice = prod.UnitPrice,
                Discounted = prod.Discounted
            };
        }

        WCF.Product IProductParser.ToClientProduct(SQLd.Product prod)
        {
            return new WCF.Product
            {
                ProductId = prod.ProductId,
                ProductName = prod.ProductName,
                SupplierId = prod.SupplierId,
                CategoryId = prod.CategoryId,
                UnitPrice = prod.UnitPrice,
                Discounted = prod.Discounted
            };
        }        
    }
}
