using Sql.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sql.DAL.Converter
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        bool AddProduct(Product product);
        bool DeleteProduct(int id);
        bool UpdateProduct(Product product);
    }
    public class ProductRepository : Repository<ProductRepository>, IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (var conn = sqlFactory.GetDbConnection())
            {
                using (var cmd = sqlFactory.GetDbCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllProducts";
                    cmd.CommandTimeout = cmdTimeout;

                    conn.Open();

                    using (IDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            products.Add(new Product
                            {
                                ProductId = Convert.ToInt32(rdr["productid"]),
                                ProductName = rdr["productname"].ToString(),
                                SupplierId =  Convert.ToInt32(rdr["supplierid"]),
                                CategoryId =  Convert.ToInt32(rdr["categoryid"]),
                                UnitPrice = Convert.ToDecimal(rdr["unitprice"]),
                                Discounted = Convert.ToBoolean(rdr["discontinued"])
                            });
                        }
                    }
                }
            }
            return products;
        }
        public Product GetProduct(int id)
        {
            return null;            
        }
        public bool UpdateProduct(Product product)
        {
            return false;
        }
        public bool AddProduct(Product product)
        {
            int res = 0;
            using (var conn = sqlFactory.GetDbConnection())
            {
                using (var cmd = sqlFactory.GetDbCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpsertProduct";
                    cmd.CommandTimeout = cmdTimeout;

                    cmd.Parameters.Add(sqlFactory.CreateInParameter("@ProductId", DbType.Int32, product.ProductId));
                    cmd.Parameters.Add(sqlFactory.CreateInParameter("@ProductName", DbType.String, product.ProductName));
                    cmd.Parameters.Add(sqlFactory.CreateInParameter("@SupplierId", DbType.Int32, product.SupplierId));
                    cmd.Parameters.Add(sqlFactory.CreateInParameter("@CategoryId", DbType.Int32, product.CategoryId));
                    cmd.Parameters.Add(sqlFactory.CreateInParameter("@UnitPrice", DbType.Decimal, product.UnitPrice));
                    cmd.Parameters.Add(sqlFactory.CreateInParameter("@Discounted", DbType.Boolean, product.Discounted));

                    conn.Open();

                    res = cmd.ExecuteNonQuery();                                                     
                }
            }
            return res < 0 ? false : true;
        }

        public bool DeleteProduct(int id)
        {
            return false;
        }
    }
}
