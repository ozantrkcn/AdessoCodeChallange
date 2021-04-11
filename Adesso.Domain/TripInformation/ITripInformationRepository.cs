using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adesso.Domain.TripInformation
{
    public interface ITripInformationRepository : IGenericRepository<TripInformation>
    {
        IEnumerable<TripInformation> GetTripInfoByFromAndTo(string From, string To);
        TripInformation GetPublishedTrip(int Id);
        IEnumerable<TripInformation> GetMyTrips (int CreatedBy);
        TripInformation GetMyTripById (int Id, int CreatedBy);

    }
}
