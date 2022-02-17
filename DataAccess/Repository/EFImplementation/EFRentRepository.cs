using DataAccess.DataAccess;
using DataAccess.Entityes;

namespace DataAccess.Repository.EFImplementation
{
    public class EFRentRepository : EFGenericRepository<Rent>
    {
        public EFRentRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
