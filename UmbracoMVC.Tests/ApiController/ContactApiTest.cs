using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UmbracoMVC.Models;

namespace UmbracoMVC.ApiController.Tests
{
    [TestClass()]
    public class ContactApiTest
    {
        ContactApiController _contactApi;
        [TestInitialize]
        public void Initiate()
        {
            _contactApi = new ContactApiController();
        }
        [TestMethod()]
        public void GetAll()
        {
            var rs = _contactApi.GetAll();
            Assert.IsTrue(rs is List<ContactFormViewModel>);
        }
    }
}