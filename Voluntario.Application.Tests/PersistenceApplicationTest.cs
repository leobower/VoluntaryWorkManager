using CentralSharedModel.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Voluntario.Application;
using Voluntario.Application.Persistence;
using Voluntario.Application.Tests;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class PersistenceApplicationTest : BaseTestClass, IRequest
    {
        [Test]
        public void AddTest()
        {
            if (Voluntario == null)
                Setup();
            IPersistenceApplication per = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager(base.Config)
                .GetCurrentIPersistenceApplicationImplementation();
            //per.Voluntario = Voluntario;
            per.VoluntarioSerialized = base.GetVoluntarioSerialized();
            string test = base.GetVoluntarioSerialized();
            per.RequestId = RequestId;
            per.Add();
            
        }

        [Test]
        public void UpdateTest()
        {
            //AddTest();
            IPersistenceApplication per = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager(base.Config)
                .GetCurrentIPersistenceApplicationImplementation();
            //per.Voluntario = Voluntario;
            per.VoluntarioSerialized = base.GetVoluntarioSerialized();
            per.RequestId = RequestId;

            Voluntario.Email = "leandro_vca@hotmail.com";
            per.Update();

        }

        [Test]
        public void DeleteTest()
        {
           // AddTest();
            IPersistenceApplication per = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager(base.Config)
                .GetCurrentIPersistenceApplicationImplementation();
            //per.Voluntario = Voluntario;
            per.VoluntarioSerialized = base.GetVoluntarioSerialized();
            per.RequestId = RequestId;
            per.Delete();
            
        }

    }
}