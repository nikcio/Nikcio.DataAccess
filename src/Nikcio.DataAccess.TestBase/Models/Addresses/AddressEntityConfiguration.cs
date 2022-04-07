using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nikcio.DataAccess.TestBase.Models.Addresses {
    public class AddressEntityConfiguration : IEntityTypeConfiguration<Address> {
        public void Configure(EntityTypeBuilder<Address> builder) {
            builder.Property(p => p.StreetName).HasMaxLength(100);
        }
    }
}
