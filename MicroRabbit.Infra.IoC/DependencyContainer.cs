using MediatR;
using MicroRabbit.Account.Application.Interfaces;
using MicroRabbit.Account.Application.Services;
using MicroRabbit.Account.Domain.CommandHandlers;
using MicroRabbit.Account.Domain.Commands;
using MicroRabbit.Account.Domain.EventHandlers;
using MicroRabbit.Account.Domain.Events;
using MicroRabbit.Asset.Application.Interfaces;
using MicroRabbit.Asset.Application.Services;
using MicroRabbit.Asset.Data.Context;
using MicroRabbit.Asset.Domain.CommandHandlers;
using MicroRabbit.Asset.Domain.Commands;
using MicroRabbit.Asset.Domain.EventHandlers;
using MicroRabbit.Asset.Domain.Events;
using MicroRabbit.Discovery.Application.Interfaces;
using MicroRabbit.Discovery.Application.Services;
using MicroRabbit.Discovery.Domain.CommandHandlers;
using MicroRabbit.Discovery.Domain.Commands;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddLogging();  //enable logging

            //Subscriptions
            services.AddTransient<StartAssetScanEventHandler>();
            services.AddTransient<Discovery.Domain.EventHandlers.DiscoveryProcessStartEventHandler>();
            services.AddTransient<Discovery.Domain.EventHandlers.AssetScanCompletedEventHandler>();
            services.AddTransient<Discovery.Domain.EventHandlers.AssetScanFailedEventHandler>();

            services.AddTransient<StartAccountScanEventHandler>();
            services.AddTransient<Discovery.Domain.EventHandlers.AccountScanCompletedEventHandler>();
            services.AddTransient<Discovery.Domain.EventHandlers.AccountScanFailedEventHandler>();



            //Domain Events
            services.AddTransient<IEventHandler<StartAssetScanEvent>, StartAssetScanEventHandler>();
            services.AddTransient<IEventHandler<StartAccountScanEvent>, StartAccountScanEventHandler>();
            services.AddTransient<IEventHandler<Discovery.Domain.Events.DiscoveryProcessStartEvent>, Discovery.Domain.EventHandlers.DiscoveryProcessStartEventHandler>();

            services.AddTransient<IEventHandler<Discovery.Domain.Events.AssetScanCompletedEvent>, Discovery.Domain.EventHandlers.AssetScanCompletedEventHandler>();
            services.AddTransient<IEventHandler<Discovery.Domain.Events.AssetScanFailedEvent>, Discovery.Domain.EventHandlers.AssetScanFailedEventHandler>();

            services.AddTransient<IEventHandler<Discovery.Domain.Events.AccountScanCompletedEvent>, Discovery.Domain.EventHandlers.AccountScanCompletedEventHandler>();
            services.AddTransient<IEventHandler<Discovery.Domain.Events.AccountScanFailedEvent>, Discovery.Domain.EventHandlers.AccountScanFailedEventHandler>();
            
            //Domain Asset Commands
            services.AddTransient<IRequestHandler<CreateAssetScanCompletedCommand, bool>, AssetScanCompletedCommandHandler>();
            services.AddTransient<IRequestHandler<CreateAssetScanFailedCommand, bool>, AssetScanFailedCommandHandler>();
            services.AddTransient<IRequestHandler<CreateAccountScanCompletedCommand, bool>, AccountScanCompletedCommandHandler>();
            services.AddTransient<IRequestHandler<CreateAccountScanFailedCommand, bool>, AccountScanFailedCommandHandler>();

            services.AddTransient<IRequestHandler<CreateDiscoveryProcessStartCommand, bool>, DiscoveryProcessStartCommandHandler>();

            //Application Services
            services.AddTransient<IDiscoveryService,DiscoveryService>();
            services.AddTransient<IAssetService, AssetService>();
            services.AddTransient<IAccountService, AccountService>();

            //Data
            //services.AddTransient<IAssetRepository, AssetRepository>();
            //services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<AssetDbContext>();            
        }
    }
}
