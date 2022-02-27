using System;
using System.Collections.Generic;

namespace TowerDefense
{
    public class ServiceLocatorSingleton
    {
        private static ServiceLocatorSingleton _instance;

        public static ServiceLocatorSingleton Instance => _instance ?? (_instance = new ServiceLocatorSingleton());

        private Dictionary<Type, object> _services;

        private ServiceLocatorSingleton()
        {
            _services = new Dictionary<Type, object>();
        }

        public void RegisterService<T>(T service)
        {
            Type serviceType = typeof(T);
            _services.Add(serviceType, service);
        }

        public T GetService<T>()
        {
            Type serviceType = typeof(T);

            if (!_services.TryGetValue(serviceType, out var service))
                throw new Exception($"Service with type {serviceType} not registered");

            return (T)service;
        }

        public void ClearServices()
        {
            _services.Clear();
        }
    }
}