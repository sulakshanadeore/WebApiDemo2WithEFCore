using Microsoft.EntityFrameworkCore;

namespace WebApiDemo2.Models
{
    


    public class NorthwindDataContext : DbContext
    {
        public NorthwindDataContext(DbContextOptions<NorthwindDataContext> options) : base(options)
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }
    }

}
