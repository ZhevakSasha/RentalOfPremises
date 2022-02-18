using DataAccess.Entities;

namespace DataAccess.Repository.EFImplementation
{
    public class EFOutletRepository : EFGenericRepository<Outlet>
    {
        public EFOutletRepository(DataBaseContext context) : base (context)
        {

        }
    }
}
