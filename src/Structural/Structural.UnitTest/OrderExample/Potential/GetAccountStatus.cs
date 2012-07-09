using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Structural.UnitTest.OrderExample.Potential
{
    public class CustomerSelector
    {
        public int CustomerId { get; set; }
    }

    public class CustomerAccountStatus
    {
        public AccountStatus Status { get; set; }

        public int CustomerId { get; set; }
    }

    public enum AccountStatus
    {
        Open,
        Closed
    }

    public class GetAccountStatus : IQuery<CustomerSelector>
    {
        public object Execute(CustomerSelector request)
        {
            return new CustomerAccountStatus {CustomerId=request.CustomerId, Status=AccountStatus.Open };
        }
    }
}
