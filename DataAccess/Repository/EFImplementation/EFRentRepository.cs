using DataAccess.DataAccess;
using DataAccess.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository.EFImplementation
{
    public class EFRentRepository : EFGenericRepository<Rent>
    {
        public EFRentRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
