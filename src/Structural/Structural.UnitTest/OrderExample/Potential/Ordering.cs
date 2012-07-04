using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Structural.UnitTest.OrderExample.Interactors;

namespace Structural.UnitTest.OrderExample.Potential
{
    public enum OrderValidationStatus
    {
        Success,
        Failure
    }

    public class OrderValidationResult
    {
        public OrderValidationStatus Status { get; set; }
    }

    public class ValidateOrderRequest : ICommand<OrderSlip>
    {
        public object Execute(OrderSlip request)
        {
            return new OrderValidationResult{ Status = OrderValidationStatus.Success };
        }
    }

    public class ChargeUser : ICommand<OrderReceipt>
    {
        public object Execute(OrderReceipt request)
        {
            Console.WriteLine("charged user "+request.Total+" for order "+request.OrderNumber);
            return null;
        }
    }

    public class SubmitToFulfillment : ICommand<OrderReceipt>
    {
        public object Execute(OrderReceipt request)
        {
            Console.WriteLine("sent order "+request.OrderNumber+" to shipping");
            return null;
        }
    }

    public class GenerateReceipt : ICommand<OrderSlip>
    {
        public object Execute(OrderSlip request)
        {
            return new OrderReceipt {
                NumberOfItems = request.LineItems.Count(), 
                OrderNumber = 89432, 
                Total = 1243.40m 
            };
        }
    }
}
