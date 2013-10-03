using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionalRepositoryPattern.Interfaces.Services;
using TransactionalRepositoryPattern.Repositories;

namespace TransactionalRepositoryPattern.Services
{
    public class PersonService:IPersonService
    {
        /// <summary>
        /// Flawlessly executes an action on the repository and commits when the action is completed
        /// </summary>
        /// <param name="persons"></param>
        public void WillCommit(IEnumerable<Interfaces.Models.IPerson> persons)
        {
            using (var repo = new PersonRepository())
            {
                repo.ExecuteInTransaction(() =>
                {
                    foreach (var person in persons)
                    {
                        repo.Add(person);
                    }
                });
            }
        }

        /// <summary>
        /// Executes an action on the repository, but simulates a exception which should result in rollback of
        /// every sql command performed in the action.
        /// </summary>
        /// <param name="persons"></param>
        public void WillRollback(IEnumerable<Interfaces.Models.IPerson> persons)
        {
            using (var repo = new PersonRepository())
            {
                repo.ExecuteInTransaction(() =>
                {
                    foreach (var person in persons)
                    {
                        repo.Add(person);
                    }
                    throw new Exception();
                });
            }
        }
    }
}
