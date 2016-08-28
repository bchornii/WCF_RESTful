using Sql.DAL.DbFactory;

namespace Sql.DAL.Converter
{
    public interface IRepository<T>
    {
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        protected int cmdTimeout = 60;
        protected DbFactory.DbFactory sqlFactory;
        public Repository()
        {
            sqlFactory = new SqlFactory();
        }                        
    }
}
