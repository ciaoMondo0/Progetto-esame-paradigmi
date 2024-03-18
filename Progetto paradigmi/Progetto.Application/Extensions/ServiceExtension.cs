using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Application.Services;
using Progetto_paradigmi.Progetto.Models.Context;
using Progetto_paradigmi.Progetto.Models.Repositories;
using Progetto_paradigmi.Progetto.Application.Interfaces;
using Progetto_paradigmi.Progetto.Application.Options;

namespace Progetto_paradigmi.Progetto.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
               conf.UseSqlServer(configuration.GetConnectionString("MyDbContext")));

            // Register repositories
            services.AddScoped<UtentiRepository>();
            services.AddScoped<DistributionListRepository>();
            services.AddScoped<UtentiService>();
            services.AddScoped<DistributionListService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<RecipientsRepository>();
            services.AddScoped<RecipientsListRepository>();

            services.AddOptions(configuration);

            return services;
        }


        private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //Prendo il singolo valore
            string host = configuration
                .GetValue<string>("EmailOption:Host");
            //Prendo un oggetto e lo bindo alla sezione una tantum
            var emailOption = new EmailOption();
            configuration.GetSection("EmailOption")
                .Bind(emailOption);
            //Pattern Options : Prendo l'oggetto e lo dichiaro come servizio
            services.Configure<EmailOption>(
                configuration.GetSection("EmailOption")
                );

            return services;
        }
    }

}

