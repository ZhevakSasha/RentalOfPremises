﻿using DataAccess.DataAccess;
using DataAccess.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository.EFImplementation
{
    public class EFOutletRepository : EFGenericRepository<Outlet>
    {
        public EFOutletRepository(DataBaseContext context) : base (context)
        {

        }
    }
}
