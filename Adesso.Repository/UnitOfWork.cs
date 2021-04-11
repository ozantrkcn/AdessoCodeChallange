using Adesso.Domain;
using Adesso.Domain.TripInformation;
using Adesso.Domain.UserTripInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TripInfoDbContext _context;
        public ITripInformationRepository TripInformation { get; }

        public IUserTripInformationRepository UserTripInformation { get; }

        public UnitOfWork(TripInfoDbContext tripInfoDbContext,
            ITripInformationRepository tripInformationRepository
            , IUserTripInformationRepository userTripInformation)
        {
            this._context = tripInfoDbContext;

            this.TripInformation = tripInformationRepository;
            this.UserTripInformation = userTripInformation;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
