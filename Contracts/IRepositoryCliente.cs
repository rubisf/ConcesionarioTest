using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        int GetId(Cliente cli);
    }
}
