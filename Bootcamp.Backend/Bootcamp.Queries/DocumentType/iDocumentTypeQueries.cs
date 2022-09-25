using Bootcamp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Queries.DocumentType
{
    public interface iDocumentTypeQueries
    {
        Task<IEnumerable<DocumentTypeViewModel>> GetAll();
        //Metodo asincrono que devuelve una lista
    }
}
