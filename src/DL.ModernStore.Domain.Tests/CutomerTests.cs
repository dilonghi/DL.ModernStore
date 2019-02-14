using DL.ModernStore.Domain.Entities;
using DL.ModernStore.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.ModernStore.Domain.Tests
{
    [TestClass]
    public class CutomerTests
    {
        [TestMethod]
        [TestCategory("Customer - New Cutomer")]
        public void GivenAInvalidFirsNameShouldReturnANotification()
        {
           
            var name = new Name("", "Longhi");
            var document = new Document("900479400000");
            var email = new Email("diegolonmghi@gmail.com");
            var user = new User("dilonghi", "123456");
            var customer = new Customer(name, document, email,  null, user);

            Assert.IsFalse(customer.Valid);
        }


        [TestMethod]
        [TestCategory("Customer - New Cutomer")]
        public void GivenAInvalidLastNameShouldReturnANotification()
        {

            Assert.Fail();


        }

        [TestMethod]
        [TestCategory("Customer - New Cutomer")]
        public void GivenAInvalidEmailShouldReturnANotification()
        {

            Assert.Fail();


        }
    }
}
