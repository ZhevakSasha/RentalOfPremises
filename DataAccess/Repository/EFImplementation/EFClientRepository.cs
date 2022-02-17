
using DataAccess.DataAccess;
using DataAccess.Entityes;

namespace DataAccess.Repository.EFImplementation
{
    public class EFClientRepository : EFGenericRepository<Client>
    {
        public EFClientRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
