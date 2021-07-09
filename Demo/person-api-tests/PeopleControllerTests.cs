using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using person_api;
using person_api.Controllers;

namespace person_api_tests
{
    public class PeopleControllerTests
    {
        PeopleController controller;

        [SetUp]
        public void Setup()
        {
            var provider = new FakePeopleProvider();
            controller = new PeopleController(provider);
        }

        [Test]
        public void GetPeople_ReturnsAllItems()
        {
            IEnumerable<Person> result = controller.Get();
            Assert.AreEqual(9, result.Count());
        }

        [Test]
        public void GetPerson_WithValidId_ReturnsPerson()
        {
            Person result = controller.Get(2);
            Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void GetPerson_WithInvalidId_ReturnsNull()
        {
            Person result = controller.Get(-10);
            Assert.IsNull(result);
        }
    }
}