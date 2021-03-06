﻿using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.SerializationManager;

namespace Voluntario.Application.Persistence
{
    public interface IPersistenceApplication : IDisposable
    {
        IVoluntario Voluntario { get; set; }
        string VoluntarioSerialized { set; }

        string RequestId { get; set; }
        void Add();
        void Update();
        void Delete();
        //void Dispose();
    }
}
