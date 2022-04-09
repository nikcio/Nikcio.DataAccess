using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nikcio.DataAccess.Tests.Contexts {
    [TestClass]
    public class ContextRemoveOperationsTest : ContextAddOperationsTest {

        [TestMethod]
        public void Context_Remove_House_Simple() {
            var expectedHousesCount = 0;

            Context_Add_House_Simple();

            var testContext = CreateContext();

            var house = testContext.Houses?.FirstOrDefault();
            Assert.IsNotNull(house);

            testContext.Houses?.Remove(house);
            testContext.Context.SaveChanges();

            var houses = testContext.Houses?.ToList();

            Assert.IsNotNull(houses);
            Assert.AreEqual(expectedHousesCount, houses.Count);
        }

        [TestMethod]
        public void Context_Remove_House_Relations() {
            var expectedHousesCount = 0;
            var expectedAddressesCount = 1;

            Context_Add_House_Relations();

            var testContext = CreateContext();

            var house = testContext.Houses?.FirstOrDefault();
            Assert.IsNotNull(house);

            testContext.Houses?.Remove(house);
            testContext.Context.SaveChanges();

            var houses = testContext.Houses?.ToList();
            var addresses = testContext.Addresses?.ToList();

            Assert.IsNotNull(houses);
            Assert.IsNotNull(addresses);
            Assert.AreEqual(expectedHousesCount, houses.Count);
            Assert.AreEqual(expectedAddressesCount, addresses.Count);
        }

        [TestMethod]
        public async Task Context_Remove_House_SimpleAsync() {
            var expectedHousesCount = 0;

            await Context_Add_House_SimpleAsync();

            var testContext = CreateContext();

            Assert.IsNotNull(testContext.Houses);

            var house = await testContext.Houses.FirstOrDefaultAsync();
            Assert.IsNotNull(house);

            testContext.Houses?.Remove(house);
            await testContext.Context.SaveChangesAsync();

            Assert.IsNotNull(testContext.Houses);

            var houses = await testContext.Houses.ToListAsync();

            Assert.IsNotNull(houses);
            Assert.AreEqual(expectedHousesCount, houses.Count);
        }

        [TestMethod]
        public async Task Context_Remove_House_RelationsAsync() {
            var expectedHousesCount = 0;
            var expectedAddressesCount = 1;

            await Context_Add_House_RelationsAsync();

            var testContext = CreateContext();

            Assert.IsNotNull(testContext.Houses);

            var house = await testContext.Houses.FirstOrDefaultAsync();
            Assert.IsNotNull(house);

            testContext.Houses?.Remove(house);
            await testContext.Context.SaveChangesAsync();

            Assert.IsNotNull(testContext.Houses);
            Assert.IsNotNull(testContext.Addresses);
            var houses = await testContext.Houses.ToListAsync();
            var addresses = await testContext.Addresses.ToListAsync();

            Assert.IsNotNull(houses);
            Assert.IsNotNull(addresses);
            Assert.AreEqual(expectedHousesCount, houses.Count);
            Assert.AreEqual(expectedAddressesCount, addresses.Count);
        }

    }
}
