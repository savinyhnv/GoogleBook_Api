using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class Country : BaseImageLookup
    {
        public string BillingInfo { get; set; }

        public Guid? TimeZoneId { get; set; }

        public TimeZone TimeZone { get; set; }

        public string Code { get; set; }

        public string Alpha2Code { get; set; }
    }
}
