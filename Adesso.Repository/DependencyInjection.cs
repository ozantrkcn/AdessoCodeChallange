using Adesso.Domain;
using Adesso.Domain.TripInformation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using Adesso.Domain.UserTripInformation;

namespace Adesso.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<ITripInformationRepository, TripInformationRepository>();
            services.AddTransient<IUserTripInformationRepository, UserTripInformationRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<TripInfoDbContext>(opt => opt.UseSqlServer("Server=localhost;Database=CarShareApp;Trusted_Connection=True;"));
            return services;
        }
    }
}
