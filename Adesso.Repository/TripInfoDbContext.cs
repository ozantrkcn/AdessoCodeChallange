using Adesso.Domain.TripInformation;
using Adesso.Domain.UserTripInformation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Repository
{
    public class TripInfoDbContext : DbContext
    {
        public TripInfoDbContext(DbContextOptions<TripInfoDbContext> options) : base(options)
        { }

        public DbSet<TripInformation> TripInformations { get; set; }
        public DbSet<UserTripInformation> UserTripInformation { get; set; }

    }
}
