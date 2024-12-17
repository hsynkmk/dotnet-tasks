using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IApplicationUserRepository ApplicationUser { get; }
    }
}
