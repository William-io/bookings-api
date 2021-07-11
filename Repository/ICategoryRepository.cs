using System.Collections.Generic;
using Bookings.Models;

namespace Bookings.Repository
{
    interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetCategorysHotels();

    }

}