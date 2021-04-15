using Portal.Data.Entities;
using Portal.Data.Infrastructure.Abstractions;
using Portal.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.Repository.Implementations
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(PortalDataContext context): base(context)
        { }
    }
}
