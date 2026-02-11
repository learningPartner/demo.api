using Microsoft.EntityFrameworkCore;

namespace demo.api.Models
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<StudentMaster> StudentMasters { get; set; }
        public DbSet<CityMaster> CityMasters { get; set; }

        public DbSet<CountryMaster> CountryMasters { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<DistrictMaster> DistrictMasters { get; set; }


        public DbSet<EmployeeBasic> EmployeeBasics { get; set; }
        public DbSet<EmployeeBank> EmployeeBanks { get; set; }

        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ProductImageModel> ProductImageModels { get; set; }
    }
}
