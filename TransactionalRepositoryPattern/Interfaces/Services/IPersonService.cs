using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionalRepositoryPattern.Interfaces.Models;

namespace TransactionalRepositoryPattern.Interfaces.Services
{
    public interface IPersonService
    {
        void WillCommit(IEnumerable<IPerson> persons);
        void WillRollback(IEnumerable<IPerson> persons);
    }
}
