using SS.Entities;
using SS.Interfaces.Data;

namespace SS.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product, SomeShopsContext>, IProductRepository
    {
        public ProductRepository(SomeShopsContext context) : base(context)
        {
        }
    }
}
