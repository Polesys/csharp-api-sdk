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
    public class LabelTests
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
        public void Test_Label_CRUD()
        {
            #region Arrange
            //Add code to create required resources
            #endregion Arrange

            var connector = new LabelConnector();

            #region CREATE
            var newLabel = new Label()
            {
                Description = "TestLabel"
            };

            var createdLabel = connector.Create(newLabel);
            MyAssert.HasNoError(connector);
            Assert.AreEqual("TestLabel", createdLabel.Description);

            #endregion CREATE

            #region UPDATE

            createdLabel.Description = "UpdatedTestLabel";

            var updatedLabel = connector.Update(createdLabel); 
            MyAssert.HasNoError(connector);
            Assert.AreEqual("UpdatedTestLabel", updatedLabel.Description);

            #endregion UPDATE

            #region READ / GET
            //Not allowed to read single label
            #endregion READ / GET

            #region DELETE

            connector.Delete(createdLabel.Id);
            MyAssert.HasNoError(connector);

            #endregion DELETE

            #region Delete arranged resources
            //Add code to delete temporary resources
            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Find()
        {
            var connector = new LabelConnector();

            var existingCount = connector.Find().Entities.Count;

            var createdEntries = new List<Label>();
            //Add entries
            for (var i = 0; i < 5; i++)
            {
                var createdEntry = connector.Create(new Label() {Description = TestUtils.RandomString()});
                createdEntries.Add(createdEntry);
            }

            //Filter not supported
            var fullCollection = connector.Find();
            MyAssert.HasNoError(connector);

            Assert.AreEqual(existingCount + 5, fullCollection.Entities.Count);

            //Limit not supported
            
            //Delete entries
            foreach (var entry in createdEntries)
            {
                connector.Delete(entry.Id);
            }
        }
    }
}
