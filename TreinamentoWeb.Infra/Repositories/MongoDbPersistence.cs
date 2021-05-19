﻿using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Infra.Repositories
{
    public static class MongoDbPersistence
    {
        private static void ConfigureMap()
        {
            BsonClassMap.RegisterClassMap<LegalPerson>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.CNPJ);
                map.MapMember(x => x.CNPJ).SetIsRequired(true);
            });
        }

        public static void Configure()
        {
            ConfigureMap();

            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };

            ConventionRegistry.Register("Mongo Convention", pack, t => true);
        }
    }
}
