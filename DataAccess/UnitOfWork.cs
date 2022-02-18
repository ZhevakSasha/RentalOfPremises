using DataAccess.Repository.EFImplementation;
using System;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataBaseContext _context;

        private EFClientRepository _clientRepository;
        private EFOutletRepository _outletRepository;
        private EFPaymentRepository _paymentRepository;
        private EFRentRepository _rentRepository;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public EFClientRepository Clients => _clientRepository ??= new EFClientRepository(_context);

        public EFOutletRepository Outlets => _outletRepository ??= new EFOutletRepository(_context);

        public EFPaymentRepository Payments => _paymentRepository ??= new EFPaymentRepository(_context);

        public EFRentRepository Rents => _rentRepository ??= new EFRentRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this._disposed = true;
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
