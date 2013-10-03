using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionalRepositoryPattern.Interfaces.Repositories
{
    public interface ITransactionalRepository: IDisposable
    {
        void ExecuteInTransaction(Action a);
    }
}
