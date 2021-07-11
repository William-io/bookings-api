using Bookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Repository
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        IEnumerable<Hotel> GetHotelForPrice();
    }
}
