using Adesso.Domain.TripInformation;
using Adesso.Domain.UserTripInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ITripInformationRepository TripInformation { get; }
        IUserTripInformationRepository UserTripInformation { get; }
        int Complete();
    }
}
