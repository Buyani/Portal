using Portal.Data.Infrastructure.Interfaces;
using Portal.Data.Repository.Implementations;
using Portal.Data.Repository.Interfaces;
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
            Subjects = new SubjectRepository(_context);
        }
        public ISubjectRepository Subjects { get; private set; }
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
