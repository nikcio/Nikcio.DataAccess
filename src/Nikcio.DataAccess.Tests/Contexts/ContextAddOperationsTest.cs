using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nikcio.DataAccess.TestBase.Models.Addresses;
using Nikcio.DataAccess.TestBase.Models.Houses;
using Nikcio.DataAccess.Tests.Bases;

namespace Nikcio.DataAccess.Tests.Contexts {
    [TestClass]
    public class ContextAddOperationsTest : ContextTestBase {

        [TestMethod]
        public void Context_Add_House_Simple() {
            var house = new House {
                Windows = 1,
                Doors = 2,
            };
            var testContext = CreateContext();
            var expectedHousesCount = 1;

            testContext.Houses?.Add(house);

            testContext.Context.SaveChanges();

            var houses = testContext.Houses?.ToList();

            Assert.IsNotNull(houses);
            Assert.AreEqual(expectedHousesCount, houses?.Count);
            Assert.AreEqual(house.Windows, houses?[0].Windows);
            Assert.AreEqual(house.Doors, houses?[0].Doors);
        }

        [TestMethod]
        public void Context_Add_House_Relations() {
            var house = new House {
                Windows = 1,
                Doors = 2,
                Address = new Address {
                    StreetName = "Street 1"
                }
            };
            var testContext = CreateContext();
            var expectedHousesCount = 1;

            testContext.Houses?.Add(house);

            testContext.Context.SaveChanges();

            var houses = testContext.Houses?.ToList();

            Assert.IsNotNull(houses);
            Assert.AreEqual(expectedHousesCount, houses?.Count);
            Assert.AreEqual(house.Windows, houses?[0].Windows);
            Assert.AreEqual(house.Doors, houses?[0].Doors);
            Assert.AreEqual(house.Address.StreetName, houses?[0].Address?.StreetName);
        }

        [TestMethod]
        public async Task Context_Add_House_SimpleAsync() {
            var house = new House {
                Windows = 1,
                Doors = 2,
            };
            var testContext = CreateContext();
            var expectedHousesCount = 1;

            if (testContext.Houses == null) throw new NullReferenceException("Houses is null");

            await testContext.Houses.AddAsync(house);

            await testContext.Context.SaveChangesAsync();

            var houses = await testContext.Houses.ToListAsync();

            Assert.IsNotNull(houses);
            Assert.AreEqual(expectedHousesCount, houses?.Count);
            Assert.AreEqual(house.Windows, houses?[0].Windows);
            Assert.AreEqual(house.Doors, houses?[0].Doors);
        }

        [TestMethod]
        public async Task Context_Add_House_RelationsAsync() {
            var house = new House {
                Windows = 1,
                Doors = 2,
                Address = new Address {
                    StreetName = "Street 1"
                }
            };
            var testContext = CreateContext();
            var expectedHousesCount = 1;

            if (testContext.Houses == null) throw new NullReferenceException("Houses is null");

            await testContext.Houses.AddAsync(house);

            await testContext.Context.SaveChangesAsync();

            var houses = testContext.Houses?.ToList();

            Assert.IsNotNull(houses);
            Assert.AreEqual(expectedHousesCount, houses?.Count);
            Assert.AreEqual(house.Windows, houses?[0].Windows);
            Assert.AreEqual(house.Doors, houses?[0].Doors);
            Assert.AreEqual(house.Address.StreetName, houses?[0].Address?.StreetName);
        }

    }
}
