using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionalRepositoryPattern.Interfaces.Models;

namespace TransactionalRepositoryPattern.Interfaces.Repositories
{
    public interface IPersonRepository : ITransactionalRepository
    {
        void Add(IPerson person);
    }
}
