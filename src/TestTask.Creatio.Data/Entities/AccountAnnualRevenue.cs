using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class AccountAnnualRevenue : BaseLookup
    {
        public int FromBaseCurrency { get; set; }

        public int ToBaseCurrency { get; set; }
    }
}
