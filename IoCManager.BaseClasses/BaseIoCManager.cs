using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace CrossCutting.IoCManager.BaseClasses
{
    public  abstract class BaseIoCManager<T>
    {
        private IConfiguration _conf;

        private const string CONST_CONSTRAINT_NAMESPACE = "IoCManager";
        private const string CONST_INVALID_ACCESS = "Invalid Base Class Access";

        public IConfiguration Config { get => _conf; }

        public BaseIoCManager()
        {

        }

        public BaseIoCManager(IConfiguration conf)
        {
            _conf = conf;

            Type tipo = this.GetType();
            if (!tipo.Namespace.Contains(CONST_CONSTRAINT_NAMESPACE))
                throw new Exception(CONST_INVALID_ACCESS);
        }

        private string GetValueConfigFileForCurrentInterface()
        {
            Type currentType = typeof(T);
            string ret = "";
            ret = _conf[currentType.Name];

            return ret;
        }


        protected T GetCurrentImplementation(string currentImplementation = null)
        {
            object obj = null;
            if (String.IsNullOrEmpty(currentImplementation))
                currentImplementation = GetValueConfigFileForCurrentInterface();

            if (!String.IsNullOrEmpty(currentImplementation))
            {
                foreach (var type in typeof(T).Assembly.DefinedTypes)
                {
                    if (type.IsClass && type.FullName.EndsWith(currentImplementation))
                    {
                        obj = (T)Assembly.Load(typeof(T).Assembly.FullName).CreateInstance(type.FullName);
                        break;
                    }
                }
            }
            else
            {
                throw new Exception("Problema no gerenciador de IoC");
            }

            return (T)obj;
        }

        protected T GetCurrentImplementationWithParameters(object[] args, string currentImplementation = null)
        {
            if (args == null)
                throw new ArgumentNullException("args");

            if (String.IsNullOrEmpty(currentImplementation))
                currentImplementation = GetValueConfigFileForCurrentInterface();

            object obj = null;

            foreach (var type in typeof(T).Assembly.DefinedTypes)
            {
                if (type.IsClass && type.FullName.EndsWith(currentImplementation))
                {
                    obj = (T)Activator.CreateInstance(type, args);
                    break;
                }
            }
            return (T)obj;
        }
    }
}
