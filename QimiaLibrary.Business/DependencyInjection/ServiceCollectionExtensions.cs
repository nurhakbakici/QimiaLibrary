using Microsoft.Extensions.DependencyInjection;
using QimiaLibrary.Business.Abstractions;
using QimiaLibrary.Business.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QimiaLibrary.Business.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection servicesCollection)
    {
        AddManagers(servicesCollection);
        AddMediatRHandlers(servicesCollection);
        AddAutoMapper(servicesCollection);

        return servicesCollection;
    }

    private static void AddMediatRHandlers(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

    private static void AddManagers(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<IWorkerManager, WorkerManager>();
        servicesCollection.AddScoped<IBookManager, BookManager>();
        servicesCollection.AddScoped<IReservationManager, ReservationManager>();        
    }

    private static void AddAutoMapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
