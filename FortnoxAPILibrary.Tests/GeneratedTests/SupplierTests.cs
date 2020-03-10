using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class SupplierTests
    {
        [TestInitialize]
        public void Init()
        {
            //Set global credentials for SDK
            //--- Open 'TestCredentials.resx' to edit the values ---\\
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;
        }

        [TestMethod]
        public void Test_Supplier_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new SupplierConnector();

            #region CREATE
            var newSupplier = new Supplier()
            {
                Name = "TestSupplier",
                Address1 = "TestStreet 1",
                Address2 = "TestStreet 2",
                ZipCode = "01010",
                City = "Testopolis",
                CountryCode = "SE", //CountryCode needs to be valid
                Email = "testSupplier@test.com",
                Active = false,
                Bank = "TestBank",
                Currency = "SEK",
                Phone1 = "01011111345",
            };

            var createdSupplier = connector.Create(newSupplier);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestSupplier", createdSupplier.Name);

            #endregion CREATE

            #region UPDATE

            createdSupplier.Name = "UpdatedSupplier";

            var updatedSupplier = connector.Update(createdSupplier); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedSupplier", updatedSupplier.Name);

            #endregion UPDATE

            #region READ / GET

            var retrievedSupplier = connector.Get(createdSupplier.SupplierNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedSupplier", retrievedSupplier.Name);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdSupplier.SupplierNumber);
            MyAssert.HasNoError(connector);

            retrievedSupplier = connector.Get(createdSupplier.SupplierNumber);
            Assert.AreEqual(null, retrievedSupplier, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var testKeyMark = TestUtils.RandomString();

            var connector = new SupplierConnector();
            var newSupplier = new Supplier()
            {
                Name = "TestSupplier",
                Address1 = "TestStreet 1",
                Address2 = "TestStreet 2",
                ZipCode = "01010",
                City = testKeyMark,
                CountryCode = "SE", //CountryCode needs to be valid
                Email = "testSupplier@test.com",
                Active = false,
                Bank = "TestBank",
                Currency = "SEK",
                Phone1 = "01011111345",
            };

            //Add entries
            for (var i = 0; i < 5; i++)
            {
                connector.Create(newSupplier);
            }

            //Apply base test filter
            connector.City = testKeyMark;
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, fullCollection.TotalResources);
            Assert.AreEqual(5, fullCollection.Entities.Count);
            Assert.AreEqual(1, fullCollection.TotalPages);

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);
            Assert.AreEqual(3, limitedCollection.TotalPages);

            //Delete entries
            foreach (var entry in fullCollection.Entities)
            {
                connector.Delete(entry.SupplierNumber);
            }

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }
    }
}
