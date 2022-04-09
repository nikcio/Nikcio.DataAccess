using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nikcio.DataAccess.Tests.Contexts {
    [TestClass]
    public class ContextUpdateOperationsTest : ContextAddOperationsTest {

        [TestMethod]
        public void Context_Update_House_Simple() {
            var newDoorsValue = 100;

            Context_Add_House_Simple();

            var testContext = CreateContext();

            Assert.IsNotNull(testContext.Houses);

            var house = testContext.Houses.FirstOrDefault();

            Assert.IsNotNull(house);

            house.Doors = newDoorsValue;

            testContext.Context.SaveChanges();

            var updatedHouse = testContext.Houses.FirstOrDefault();

            Assert.IsNotNull(updatedHouse);
            Assert.AreEqual(newDoorsValue, updatedHouse.Doors);
        }

        [TestMethod]
        public void Context_Update_House_Relations() {
            var newAddressName = "New Name";

            Context_Add_House_Relations();

            var testContext = CreateContext();

            Assert.IsNotNull(testContext.Houses);

            var house = testContext.Houses.Include(house => house.Address).FirstOrDefault();

            Assert.IsNotNull(house);
            Assert.IsNotNull(house.Address);

            house.Address.StreetName = newAddressName;

            testContext.Context.SaveChanges();

            var updatedHouse = testContext.Houses.Include(house => house.Address).FirstOrDefault();

            Assert.IsNotNull(updatedHouse);
            Assert.IsNotNull(updatedHouse.Address);
            Assert.AreEqual(newAddressName, updatedHouse.Address.StreetName);
        }

        [TestMethod]
        public async Task Context_Update_House_SimpleAsync() {
            var newDoorsValue = 100;

            await Context_Add_House_SimpleAsync();

            var testContext = CreateContext();

            Assert.IsNotNull(testContext.Houses);

            var house = await testContext.Houses.FirstOrDefaultAsync();

            Assert.IsNotNull(house);

            house.Doors = newDoorsValue;

            await testContext.Context.SaveChangesAsync();

            var updatedHouse = await testContext.Houses.FirstOrDefaultAsync();

            Assert.IsNotNull(updatedHouse);
            Assert.AreEqual(newDoorsValue, updatedHouse.Doors);
        }

        [TestMethod]
        public async Task Context_Update_House_RelationsAsync() {
            var newAddressName = "New Name";

            await Context_Add_House_RelationsAsync();

            var testContext = CreateContext();

            Assert.IsNotNull(testContext.Houses);

            var house = await testContext.Houses.Include(house => house.Address).FirstOrDefaultAsync();

            Assert.IsNotNull(house);
            Assert.IsNotNull(house.Address);

            house.Address.StreetName = newAddressName;

            await testContext.Context.SaveChangesAsync();

            var updatedHouse = await testContext.Houses.Include(house => house.Address).FirstOrDefaultAsync();

            Assert.IsNotNull(updatedHouse);
            Assert.IsNotNull(updatedHouse.Address);
            Assert.AreEqual(newAddressName, updatedHouse.Address.StreetName);
        }

    }
}
