using System.Data;

namespace vue_cback_gregslist.Repositories
{
    public abstract class DbContext
    {
        protected readonly IDbConnection _db;

        public DbContext(IDbConnection db)
        {
            _db = db;
        }
    }
}