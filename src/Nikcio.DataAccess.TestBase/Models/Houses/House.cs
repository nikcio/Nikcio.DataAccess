using Nikcio.DataAccess.Models;
using Nikcio.DataAccess.TestBase.Models.Addresses;

namespace Nikcio.DataAccess.TestBase.Models.Houses {
    public class House : IGenericId {
        public int Id { get; set; }
        public int Windows { get; set; }
        public int Doors { get; set; }
        public Address? Address { get; set; }
    }
}
