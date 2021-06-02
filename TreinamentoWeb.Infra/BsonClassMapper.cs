using MongoDB.Bson.Serialization;
using System;
using System.Diagnostics.CodeAnalysis;

namespace TreinamentoWeb.Infra
{
    [ExcludeFromCodeCoverage]
    public sealed class BsonClassMapper
    {

        private static BsonClassMapper instance = null;

        private static readonly object _lock = new object();

        public static BsonClassMapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BsonClassMapper();
                }
                return instance;
            }
        }

        public BsonClassMapper Register<T>(Action<BsonClassMap<T>> classMapInitializer)
        {
            lock (_lock)
            {
                if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                {
                    BsonClassMap.RegisterClassMap<T>(classMapInitializer);
                }
            }
            return this;
        }
    }
}
