using SS.Entities;
using SS.Interfaces.Data;

namespace SS.Data.Repositories
{
    public class ShopRepository : RepositoryBase<Shop, SomeShopsContext>, IShopRepository
    {
        public ShopRepository(SomeShopsContext context) : base(context)
        {
        }
    }
}
