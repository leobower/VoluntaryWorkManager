using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IoCManager.BaseClasses
{
    public  abstract class BaseIoCManager<T>
    {
        protected T GetCurrentImplementation(string currentImplementation)
        {
            object obj = null;
            foreach (var type in typeof(T).Assembly.DefinedTypes)
            {
                if (type.IsClass && type.FullName.EndsWith(currentImplementation))
                {
                    obj = (T)Assembly.Load(typeof(T).Assembly.FullName).CreateInstance(type.FullName);
                    break;
                }
            }
            return (T)obj;
        }
    }
}
