using Bootcamp.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Repositorio
{
    public interface iPersonRepository
    {
        Task <int> Create(Person person); 
    }
}
