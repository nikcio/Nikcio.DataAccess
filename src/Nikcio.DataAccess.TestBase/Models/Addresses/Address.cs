using Nikcio.DataAccess.Models;
using Nikcio.DataAccess.TestBase.Models.Houses;

namespace Nikcio.DataAccess.TestBase.Models.Addresses {
    public class Address : IGenericId {
        public int Id { get; set; }
        public string? StreetName { get; set; }
        public virtual ICollection<House>? Houses { get; set; }
    }
}
