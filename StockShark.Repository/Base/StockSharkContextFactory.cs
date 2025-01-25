using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StockShark.Repository.Base
{
    internal class StockSharkContextFactory : IDesignTimeDbContextFactory<StockSharkDbContext>
    {
        public StockSharkDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StockSharkDbContext>();
            optionsBuilder.UseSqlServer("Server = KPC\\MSSQLSERVER2019; Database=StockSharkDb;User Id = sa;Password=1234; MultipleActiveResultSets=true; Encrypt = false");

            return new StockSharkDbContext(optionsBuilder.Options);
        }
    }
}
