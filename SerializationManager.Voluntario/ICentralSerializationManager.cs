using System;
using System.Collections.Generic;
using System.Text;

namespace Voluntario.SerializationManager
{
    public interface ICentralSerializationManager<T>
    {
        string Serialize(T obj);
        T Deserialize(string obj);
    }
}
