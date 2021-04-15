using Portal.Data.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortalDataContext _context;
        public UnitOfWork(PortalDataContext context)
        {
            _context = context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
