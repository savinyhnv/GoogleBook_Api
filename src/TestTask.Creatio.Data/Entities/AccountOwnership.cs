using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class AccountOwnership : BaseLookup
    {
        public Guid? CountryId { get; set; }

        public Country Country { get; set; }
    }
}
