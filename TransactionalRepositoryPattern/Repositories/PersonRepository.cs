using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionalRepositoryPattern.Interfaces.Repositories;

namespace TransactionalRepositoryPattern.Repositories
{
    public class PersonRepository : TransactionalRepository, IPersonRepository
    {

        /// <summary>
        /// Performs a sql command on the TransactionalRepositorys transaction, this example doesn't take
        /// calling the Add method byt itself (outside of the ExecuteInTransaction scope) into account
        /// meaning that calling it in this way will result in no commit.
        /// </summary>
        /// <param name="person"></param>
        public void Add(Interfaces.Models.IPerson person)
        {
            var command = new SqlCommand("INSERT INTO Person(PersonId,Name) VALUES(@PersonId,@Name)", Trans.Connection, Trans);

            command.Parameters.AddWithValue("PersonId", person.PersonId);
            command.Parameters.AddWithValue("Name", person.Name);
            command.ExecuteNonQuery();
        }
    }
}
