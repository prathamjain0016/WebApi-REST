using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Data;


namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieBookingController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public MovieBookingController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create/Edit

        [HttpPost]
        public JsonResult CreatedAndEdit(MovieBooking booking)
        {
            if(booking.id == 0) 
            {
                _dbContext.Bookings.Add(booking);
            }
            else
            {
                var bookingINDb = _dbContext.Bookings.Find(booking.id);

                if(bookingINDb == null)
                {
                    return new JsonResult(NotFound());
                }

                bookingINDb = booking;
            }

            _dbContext.SaveChanges();

            return new JsonResult(Ok(booking));
        }

        //get
        [HttpGet]
        public JsonResult Get(int id) 
        {
            var result = _dbContext.Bookings.Find(id);

            if(result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        //delete
        [HttpDelete]
        public JsonResult Delete(int id) 
        {
            var result = _dbContext.Bookings.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _dbContext.Bookings.Remove(result);
            _dbContext.SaveChanges();

            return new JsonResult(NoContent());
        }

        //getAll
        [HttpGet]

        public JsonResult GetAll()
        {
            var result = _dbContext.Bookings.ToList();

            return new JsonResult(Ok(result));      
        }
    }
}
