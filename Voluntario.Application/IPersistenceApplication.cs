using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application.Persistence
{
    public interface IPersistenceApplication
    {
        IVoluntario Voluntario { get; set; }
        string RequestId { get; set; }
        void Add();
        void Update();
        void Delete();
        void Dispose();
    }
}
