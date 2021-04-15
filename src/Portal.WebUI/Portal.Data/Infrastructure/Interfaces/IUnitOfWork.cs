using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        int Complete();
    }
}
