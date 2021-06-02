using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using System.Diagnostics.CodeAnalysis;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Infra.Repositories
{
    [ExcludeFromCodeCoverage]
    public static class MongoDbPersistence
    {
        private static void ConfigureMap()
        {
            BsonClassMapper.Instance.Register<LegalPerson>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.CNPJ);
                map.MapMember(x => x.CNPJ).SetIsRequired(true);
            });

            BsonClassMapper.Instance.Register<NaturalPerson>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.CPF);
                map.MapMember(x => x.CPF).SetIsRequired(true);
            });

            BsonClassMapper.Instance.Register<Product>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
            });

            BsonClassMapper.Instance.Register<Order>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
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
