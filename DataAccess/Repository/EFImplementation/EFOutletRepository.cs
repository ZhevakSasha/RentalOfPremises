using DataAccess.DataAccess;
using DataAccess.Entityes;

namespace DataAccess.Repository.EFImplementation
{
    public class EFOutletRepository : EFGenericRepository<Outlet>
    {
        public EFOutletRepository(DataBaseContext context) : base (context)
        {

        }
    }
}
