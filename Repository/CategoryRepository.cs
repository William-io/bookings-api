using System.Collections.Generic;
using Bookings.Data;
using Bookings.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookings.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
        public IEnumerable<Category> GetCategorysHotels()
        {
            return Get().Include(x => x.Hotels);
        }
    }

}