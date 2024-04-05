using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

public static  class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
    public static void RegisterService<T>(T service)
    {
        var type = typeof(T);
        Assert.IsFalse(_services.ContainsKey(type),
                       $"Service {type} already registered");

        _services.Add(type, service);
    }

    public static T GetService<T>()
    {
        var type = typeof(T);
        if (!_services.TryGetValue(type, out var service))
        {
            throw new Exception($"Service {type} not found");
        }

        return (T)service;
    }

}
