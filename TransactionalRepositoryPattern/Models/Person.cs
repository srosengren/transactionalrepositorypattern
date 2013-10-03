using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionalRepositoryPattern.Interfaces.Models;

namespace TransactionalRepositoryPattern.Models
{
    public class Person : IPerson
    {
        public int PersonId { get; set; }

        public string Name { get; set; }
    }
}
