using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class Region : BaseLookup
    {
        public Guid? CountryId { get; set; }

        public Country Country { get; set; }

        public Guid? TimeZoneId { get; set; }

        public TimeZone TimeZone { get; set; }

        public string Code { get; set; }
    }
}
