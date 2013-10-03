using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionalRepositoryPattern.Models;
using TransactionalRepositoryPattern.Services;

namespace TransactionalRepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonService personService = new PersonService();

            personService.WillCommit(new Person[] { new Person{Name = "Commit: p1"},new Person { Name = "Commit: p2"}});

            personService.WillRollback(new Person[] { new Person { Name = "Rollback: p1" }, new Person { Name = "Rollback: p2" } });
        }
    }
}
