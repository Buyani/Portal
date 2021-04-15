using Portal.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.Infrastructure.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        ISubjectRepository Subjects { get; }
        int Complete();
    }
}
