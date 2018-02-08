using FraudScanner.Core.Interfaces;
using FraudScanner.Mocks;
using FraudScanner.Web.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudScanner.Web.AppStart
{
    public class ServiceDependencies
    {

        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<TwilioSettings>(configuration); 

            //singletons for memory repositories
            //services.AddSingleton<ILookupServiceProvider, MockLookup>();
            //services.AddSingleton<ITranslator, MockTranslator>(); 
            services.AddSingleton<ITransactionMain, TransactionMainMocks>();
            services.AddSingleton<IRuleMain, RuleMainMocks>();

            services.AddSingleton<TransactionMainService, TransactionMainService>();
            services.AddSingleton<RuleMainService, RuleMainService>();
        }

    }
}
