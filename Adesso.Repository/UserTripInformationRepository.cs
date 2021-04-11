using Adesso.Domain;
using Adesso.Domain.TripInformation;
using Adesso.Domain.UserTripInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adesso.Repository
{
    public class UserTripInformationRepository : GenericRepository<UserTripInformation>, IUserTripInformationRepository
    {
        public UserTripInformationRepository(TripInfoDbContext context) : base(context)
        {

        }
    }
}
