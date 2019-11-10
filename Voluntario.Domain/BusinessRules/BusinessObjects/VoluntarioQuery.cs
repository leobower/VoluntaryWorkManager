using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.BusinessObjects
{
    public class VoluntarioQuery : IVoluntarioQuery
    {
        private Func<IList<IVoluntario>> _selectAll;
        private Func<IQueryable<IList<IVoluntario>>, IList<IVoluntario>> _selectFiltered;

        public Func<IList<IVoluntario>> SelectAll { get => _selectAll; set => _selectAll = value; }
        public Func<IQueryable<IList<IVoluntario>>, IList<IVoluntario>> SelectFiltered { get => _selectFiltered; set => _selectFiltered = value; }
    }
}
