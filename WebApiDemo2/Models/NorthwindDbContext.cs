using Microsoft.EntityFrameworkCore;
using WebApiDemo2.Areas.Suppliers.Models;

namespace WebApiDemo2.Models
{
    


    public class NorthwindDataContext : DbContext
    {
        public NorthwindDataContext(DbContextOptions<NorthwindDataContext> options) : base(options)
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<SuppModel> Suppliers { get; set; }
    }

}
