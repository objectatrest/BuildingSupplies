using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Structural.UnitTest.OrderExample.Potential;

namespace Structural.UnitTest.OrderExample.Interactors
{
    /// <summary>
    /// the request or input into the PlaceOrder interactor
    /// </summary>
    public class OrderSlip
    {
        public int CustomerId { get; set; }
        public Dictionary<int, int> LineItems { get; set; }
    }

    /// <summary>
    /// The output of the placeorder interactor
    /// </summary>
    public class OrderReceipt
    {
        public int OrderNumber { get; set; }
        public decimal Total { get; set; }
        public int NumberOfItems { get; set; }
    }

    /// <summary>
    /// Main interactor for the place order use case
    /// </summary>
    public class PlaceOrder : IInteract<OrderSlip>
    {
        public object Run(OrderSlip request)
        {
            var validationStatus = Cmds.ExecuteCommand(new ValidateOrderRequest(), request) as OrderValidationResult;

            var accountStatus = Queries.ExecuteQuery(new GetAccountStatus(),
                new CustomerSelector
                {
                    CustomerId = request.CustomerId
                }) as CustomerAccountStatus;

            if (validationStatus.Status == OrderValidationStatus.Success &&
                accountStatus.Status == AccountStatus.Open)
            {
                var receipt = Cmds.ExecuteCommand(new GenerateReceipt(), request) as OrderReceipt;

                Cmds.ExecuteCommand(new ChargeUser(), receipt);

                Cmds.ExecuteCommand(new SubmitToFulfillment(), receipt);

                return receipt;
            }
            else
            {
                return new OrderReceipt { Total = 0m, NumberOfItems = 0, OrderNumber = -1 };
            }
        }
    }
}
