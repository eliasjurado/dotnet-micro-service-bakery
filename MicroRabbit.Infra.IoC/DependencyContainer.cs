using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.EventsHandlers;
using MicroRabbit.Transfer.Domain.Interfaces;
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

            //Subscriptions
            services.AddTransient<TransferEventHandler>();
            services.AddTransient<TransferProductionEventHandler>();


            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();
            services.AddTransient<IEventHandler<TransferCreatedProductionEvent>, TransferProductionEventHandler>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            services.AddTransient<IRequestHandler<CreateTransferProductionCommand, bool>, TransferCommandProductionHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IProductionService, ProductionService>();
            services.AddTransient<ITransferService, TransferService>();
            services.AddTransient<ITransferProductionService, TransferProductionService>();
            services.AddTransient<IBakerySaleService, BakerySaleService>();
            services.AddTransient<IBakeryInventoryService, BakeryInventoryService>();

            //Respository
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<ITransferProductionRepository, TransferProductionRepository>();
            services.AddTransient<IBakeryRepository, BakeryRepository>();

            //Context
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
            services.AddTransient<BakeryDbContext>();

            //Bakery
        }
    }
}
