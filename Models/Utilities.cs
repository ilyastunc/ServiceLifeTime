using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLifeTime.Models
{
    public interface IUtilitySingleton
    {
        string Key { get; set; }
        string Name {get; set;}
    }

    public interface IUtilityTransient
    {
        string Key { get; set; }
        string Name {get; set;}
    }

    public interface IUtilityScoped
    {
        string Key { get; set; }
        string Name {get; set;}
    }

    public class UtilitySingleton : IUtilitySingleton
    {
        public UtilitySingleton() => Key = Guid.NewGuid().ToString();

        public string Key { get; set; }
        public string Name { get; set; } = nameof(UtilitySingleton);
    }

    public class UtilityTransient : IUtilityTransient
    {
        public UtilityTransient() => Key = Guid.NewGuid().ToString();

        public string Key { get; set; }
        public string Name { get; set; } = nameof(UtilityTransient);
    }

    public class UtilityScoped : IUtilityScoped
    {
        public UtilityScoped() => Key = Guid.NewGuid().ToString();

        public string Key { get; set; }
        public string Name { get; set; } = nameof(UtilityScoped);
    }
}