using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationManager.Voluntario
{
    public interface ICentralSerializationManager<T>
    {
        string Serialize(T obj);
        T Deserialize(string obj);
    }
}
