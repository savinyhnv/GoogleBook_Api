using System;
using System.Collections.Generic;

namespace TestTask.Creatio.Data.Entities
{
    public class City : BaseLookup
    {
        public Guid? CountryId { get; set; }

        public Country Country { get; set; }

        public Guid? RegionId { get; set; }

        public Region Region { get; set; }

        public Guid? TimeZoneId { get; set; }

        public TimeZone TimeZone { get; set; }
    }
}
