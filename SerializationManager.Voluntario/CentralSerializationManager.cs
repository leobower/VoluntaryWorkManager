using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace SerializationManager.Voluntario
{

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }

    public class CentralSerializationManager : ICentralSerializationManager<IVoluntario>
    {
        private readonly JsonSerializerSettings _settings;  

        public CentralSerializationManager()
        {
            _settings = new JsonSerializerSettings();
            _settings.ContractResolver = new LowercaseContractResolver();
        }


        public IVoluntario Deserialize(string obj)
        {
            throw new NotImplementedException();
        }

        public string Serialize(IVoluntario obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, _settings);
        }
    }
}
