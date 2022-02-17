using DataAccess.DataAccess;
using DataAccess.Repository.EFImplementation;
using System;

namespace DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private DataBaseContext _context;

        private EFClientRepository clientRepository;
        private EFOutletRepository outletRepository;
        private EFPaymentRepository paymentRepository;
        private EFRentRepository rentRepository;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public EFClientRepository Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new EFClientRepository(_context);
                return clientRepository;
            }
        }

        public EFOutletRepository Outlets
        {
            get
            {
                if (outletRepository == null)
                    outletRepository = new EFOutletRepository(_context);
                return outletRepository;
            }
        }

        public EFPaymentRepository Payments
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new EFPaymentRepository(_context);
                return paymentRepository;
            }
        }

        public EFRentRepository Rents
        {
            get
            {
                if (rentRepository == null)
                    rentRepository = new EFRentRepository(_context);
                return rentRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
