using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.Interfaces
{
    public interface IVoluntarioQuery
    {
        Func<IList<IVoluntario>> SelectAll { get; set; }
        Func<IQueryable<IList<IVoluntario>>, IList<IVoluntario>> SelectFiltered { get; set; }
    }
}
