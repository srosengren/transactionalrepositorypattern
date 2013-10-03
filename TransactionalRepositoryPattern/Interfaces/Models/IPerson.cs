using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionalRepositoryPattern.Interfaces.Models
{
    public interface IPerson
    {
        int PersonId { get; set; }
        string Name { get; set; }
    }
}
