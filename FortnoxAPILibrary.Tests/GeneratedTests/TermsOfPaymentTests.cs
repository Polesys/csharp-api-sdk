using System;
using System.Collections.Generic;
using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.GeneratedTests
{
    [TestClass]
    public class TermsOfPaymentTests
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
        public void Test_TermsOfPayment_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new TermsOfPaymentConnector();

            #region CREATE
            var newTermsOfPayment = new TermsOfPayment()
            {
                Code = "TST",
                Description = "TestPaymentTerms"
            };

            var createdTermsOfPayment = connector.Create(newTermsOfPayment);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestPaymentTerms", createdTermsOfPayment.Description);

            #endregion CREATE

            #region UPDATE

            createdTermsOfPayment.Description = "UpdatedTestPaymentTerms";

            var updatedTermsOfPayment = connector.Update(createdTermsOfPayment); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestPaymentTerms", updatedTermsOfPayment.Description);

            #endregion UPDATE

            #region READ / GET

            var retrievedTermsOfPayment = connector.Get(createdTermsOfPayment.Code);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestPaymentTerms", retrievedTermsOfPayment.Description);

            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTermsOfPayment.Code);
            MyAssert.HasNoError(connector);

            retrievedTermsOfPayment = connector.Get(createdTermsOfPayment.Code);
            Assert.AreEqual(null, retrievedTermsOfPayment, "Entity still exists after Delete!");

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            var connector = new TermsOfPaymentConnector();

            var existingCount = connector.Find().Entities.Count;
            var testKeyMark = TestUtils.RandomString();

            var createdEntries = new List<TermsOfPayment>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = connector.Create(new TermsOfPayment() { Code = TestUtils.RandomString(), Description = testKeyMark });
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingCount + 5, fullCollection.Entities.Count);
            Assert.AreEqual(5, fullCollection.Entities.Count(e => e.Description == testKeyMark));

            //Apply Limit
            connector.Limit = 2;
            var limitedCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingCount + 5, limitedCollection.TotalResources);
            Assert.AreEqual(2, limitedCollection.Entities.Count);

            //Delete entries
            foreach (var entry in createdEntries)
            {
                connector.Delete(entry.Code);
            }
        }
    }
}
