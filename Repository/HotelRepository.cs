using Bookings.Data;
using Bookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookings.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Hotel> GetHotelForPrice()
        {
            return Get().OrderBy(c => c.Price).ToList();
        }
    }
}
