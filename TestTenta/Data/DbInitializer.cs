using TestTenta.Models;

namespace TestTenta.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext dbContext)
        {
            var tv = new ProductCategory
            {
                Name = "TV"
            };
            var dvd = new ProductCategory
            {
                Name = "DVD"
            };
            var vhs = new ProductCategory
            {
                Name = "VHS"
            };
            dbContext.Categories.AddRange(tv, dvd, vhs);
            dbContext.SaveChanges();
            }
        }
}
