using CrossCutting.IoCManager.BaseClasses;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.SerializationManager;

namespace CrossCutting.IoCManager.Voluntario.SerializationManager
{
    public class SerializationIoCManager : BaseIoCManager<ICentralSerializationManager<IVoluntario>>
    {
        private readonly string _currentJSonImplementation = "JSon";

        public ICentralSerializationManager<IVoluntario> GetJSonCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentJSonImplementation);
        }
    }
}
