using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Structural.UnitTest.OrderExample.Interactors;

namespace Structural.UnitTest
{
    [TestFixture]
    public class When_fulfilling_use_cases
    {
        [Test]
        public void Should_provide_orchestration()
        {
            var order = new OrderSlip { 
                CustomerId = 432, 
                LineItems = new Dictionary<int, int> { 
                    { 123, 1 }, 
                    { 654, 2 } 
                } 
            };

            var orderPlacer = new PlaceOrder();

            var receipt = Interactions.Run<OrderSlip>(orderPlacer, order) as OrderReceipt;

            Assert.That(receipt.OrderNumber, Is.GreaterThan(0));
            Assert.That(receipt.Total, Is.EqualTo(1243.40m));
            Assert.That(receipt.NumberOfItems, Is.EqualTo(2));
        }
    }
}
