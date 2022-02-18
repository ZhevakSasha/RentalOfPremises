using DataAccess.Entities;

namespace DataAccess.Repository.EFImplementation
{
    public class EFPaymentRepository : EFGenericRepository<Payment>
    {
        public EFPaymentRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
