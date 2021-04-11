using Adesso.Domain;
using Adesso.Domain.TripInformation;
using Adesso.Domain.UserTripInformation;
using AdessoRideShareAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public TripController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<TripInformation> AddTrip(TripModel model)
        {
            var tripEntity = new TripInformation
            {
                Explanation = model.Explanation,
                From = model.From,
                To = model.To,
                Date = model.Date,
                SeatCount = model.SeatCount,
                CreatedBy = model.CreatedBy
            };

            try
            {
                await _unitOfWork.TripInformation.Add(tripEntity);
                _unitOfWork.Complete();
                return tripEntity;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        [HttpPost]
        public IActionResult PublishUnPublishTrip(int Id,int CreatedBy)
        {

            var tripEntity = _unitOfWork.TripInformation.GetMyTripById(Id, CreatedBy);
            if (tripEntity == null)
            {
                return NotFound();

            }
            tripEntity.IsPublished = !tripEntity.IsPublished;

            try
            {
                _unitOfWork.TripInformation.Update(tripEntity);
                _unitOfWork.Complete();
                return Ok(tripEntity);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        public IEnumerable<TripInformation> GetTrip(SearchTripModel stp)
        {

            var tripEntity = _unitOfWork.TripInformation.GetTripInfoByFromAndTo(stp.From, stp.To);
            return tripEntity;

        }

        [HttpPost]
        public IActionResult RegisterToTrip(int Id, int userId)
        {

            var tripEntity = _unitOfWork.TripInformation.GetPublishedTrip(Id);
            
            if (tripEntity == null)
            {
                return NotFound();

            }
            
            if (tripEntity.SeatCount == 0)
            {
                return Problem("No Seat Left.");
            }

            tripEntity.SeatCount = tripEntity.SeatCount - 1;
            try
            {
                var userTripInfo = new UserTripInformation
                {
                    TripId = Id,
                    UserId = userId
                };
                _unitOfWork.UserTripInformation.Add(userTripInfo);

                _unitOfWork.TripInformation.Update(tripEntity);
                _unitOfWork.Complete();
                return Ok(tripEntity);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
    }
}
