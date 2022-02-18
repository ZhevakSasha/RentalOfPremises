using DataAccess.Entities;

namespace DataAccess.Repository.EFImplementation
{
    public class EFClientRepository : EFGenericRepository<Client>
    {
        public EFClientRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
