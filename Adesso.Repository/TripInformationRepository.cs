using Adesso.Domain;
using Adesso.Domain.TripInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adesso.Repository
{
    public class TripInformationRepository : GenericRepository<TripInformation>, ITripInformationRepository
    {
        public TripInformationRepository(TripInfoDbContext context) : base(context)
        {

        }

        public IEnumerable<TripInformation> GetTripInfoByFromAndTo(string From,string To)
        {
            return _context.TripInformations.Where(x => x.From == From && x.To== To && x.IsPublished);
        }
        public TripInformation GetPublishedTrip(int Id)
        {
            return _context.TripInformations.Where(x => x.Id == Id && x.IsPublished).FirstOrDefault();
        }

        public IEnumerable<TripInformation> GetMyTrips(int CreatedBy)
        {
            return _context.TripInformations.Where(x => x.CreatedBy == CreatedBy);
        }
        public TripInformation GetMyTripById (int Id, int CreatedBy)
        {
            return _context.TripInformations.Where(x => x.Id == Id && x.CreatedBy == CreatedBy).FirstOrDefault();
        }
    }
}
