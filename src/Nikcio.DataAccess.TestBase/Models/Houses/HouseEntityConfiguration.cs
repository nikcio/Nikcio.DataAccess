using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nikcio.DataAccess.TestBase.Models.Houses {
    public class HouseEntityConfiguration : IEntityTypeConfiguration<House> {
        public void Configure(EntityTypeBuilder<House> builder) {
        }
    }
}
