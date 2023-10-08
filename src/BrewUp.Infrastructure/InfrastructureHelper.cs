using BrewUp.Infrastructure.AzureServicebus;
using BrewUp.Infrastructure.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Eventstore;
using Muflone.Saga.Persistence.MongoDb;

namespace BrewUp.Infrastructure;

public static class InfrastructureHelper
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        MongoDbSettings mongoDbSettings,
        ServiceBusSettings serviceBusSettings,
        string eventStoreConnectionString)
    {
        services.AddMongoDb(mongoDbSettings);
        services.AddMongoSagaStateRepository(new MongoSagaStateRepositoryOptions(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName));
        services.AddMufloneEventStore(eventStoreConnectionString);
        services.AddAzureServiceBus(serviceBusSettings);

        return services;
    }
}