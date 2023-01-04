using System.Collections.Generic;

namespace Services
{
    public static class ServiceLocator
    {
        private static Dictionary<string, IService> _services;

        public static void Clear()
        {
            _services = null;
        }

        public static void AddService(IService service)
        {
            _services ??= new Dictionary<string, IService>();
            _services.Add(service.GetType().Name, service);
        }

        public static T GetService<T>() where T : class, IService => (T)_services[typeof(T).Name];
    }
}